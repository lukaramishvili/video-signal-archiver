using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;
using DirectX.Capture;
using System.Timers;
using System.Windows.Forms;
using System.Net;

namespace CaptureTestConsole
{
    public static class VideoCaptureController
    {
        private static Capture capture = null;
        private static Filters filters = new Filters();

        public static string sCurrentRecordingFileName = "";

        public static string sFileContainingInfoAboutCSVFilePath = "../csvfilepath.txt";
        //
        public static bool StartRecording(string sFileName)
        {
            //stoprecording does everything neccessary
            VideoCaptureController.StopRecording();
            //
            capture = new Capture(filters.VideoInputDevices[0], null);
            capture.CaptureComplete += new EventHandler(OnCaptureComplete);
            capture.Filename = sFileName;
            try
            {
                capture.Start();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Videokabeli dakavebulia. Gtxovt scadot tavidan!");
                capture.Dispose();
                return false;
            }
            sCurrentRecordingFileName = sFileName;
            Console.WriteLine("new capture {0}", sFileName);
            return true;
        }

        private static void OnCaptureComplete(object sender, EventArgs e)
        {
        }

        public static bool fIsRecording()
        {
            if (null != capture)
            {
                return capture.Capturing;
            }
            else
            {
                return false;
            }
        }

        public static bool EnsureWeHaveAFileWithCSVPathInIt(string sNewCSVPath = null)
        {
            if (null != sNewCSVPath && false == File.Exists(sNewCSVPath))
            {
                return false;
            }
            if (false == File.Exists(sFileContainingInfoAboutCSVFilePath))
            {
                File.WriteAllText(sFileContainingInfoAboutCSVFilePath, sNewCSVPath ?? "../OAStudioLog"
                                                                                        + DateTime.Now.Year.ToString()
                                                                                        + RecorderController.add_zeros(DateTime.Now.Month.ToString())
                                                                                        + RecorderController.add_zeros(DateTime.Now.Day.ToString())
                                                                                        + ".csv");
                return true;
            }
            else
            {
                if (null != sNewCSVPath)
                {
                    File.WriteAllText(sFileContainingInfoAboutCSVFilePath, sNewCSVPath);
                }
                return true;
            }
        }

        public static void StopRecording()
        {
            if (null != capture)
            {
                //no need to ckeck, capture.Stop() will work anyway
                if (true == capture.Capturing)
                {
                    capture.Stop();
                    capture.Dispose();
                    if ("" != sCurrentRecordingFileName)
                    {
                        string sFlvOutputName = sCurrentRecordingFileName.Substring(0, sCurrentRecordingFileName.LastIndexOf(".")) + ".flv";
                        System.Diagnostics.Process convert = new System.Diagnostics.Process();
                        convert.StartInfo
                            = new System.Diagnostics.ProcessStartInfo
                                (@"c:\Program Files\WinFF\ffmpeg.exe", " -i "
                            + "\"" + sCurrentRecordingFileName + "\""
                            + " -ar 44100 "
                            + " -b 1250k "
                            + " -r 25 "
                            + " -ab 128k "
                            + " -y "
                            + "\"" + sFlvOutputName + "\"");
                        convert.EnableRaisingEvents = true;
                        convert.Exited += new EventHandler(delegate(object sender, EventArgs e)
                        {
                            //droebit, vtvirtavt FLV-s chaceris morchenistanave
                            FTPUploader upl = new FTPUploader(sFlvOutputName);
                            upl.UploadFileToFTP();
                            //Thread thrUpload = new Thread(new ThreadStart(upl.UploadFileToFTP));
                            //thrUpload.SetApartmentState(ApartmentState.STA);
                            //thrUpload.Start();
                        });
                        convert.Start();
                    }
                    //
                }
            }
            //
        }
    }

    class FTPUploader
    {
        private string sFileNameToUpload = "";

        public FTPUploader(string argsFileName)
        {
            sFileNameToUpload = argsFileName;
        }

        public void UploadFileToFTP()
        {
            Thread.Sleep(1000);
            if (File.Exists(sFileNameToUpload))
            {
                // Get the object used to communicate with the server.
                FileInfo fileVideo = new FileInfo(sFileNameToUpload);
                DirectoryInfo parentDay = new DirectoryInfo(fileVideo.DirectoryName);
                DirectoryInfo parentMonth = Directory.GetParent(parentDay.FullName);
                DirectoryInfo parentYear = Directory.GetParent(parentMonth.FullName);
                FtpWebRequest request
                    = (FtpWebRequest)WebRequest.Create("ftp://92.241.90.24/videofiles/"
                    + parentYear.Name + "-"
                    + parentMonth.Name + "-"
                    + parentDay.Name + "-"
                    + fileVideo.Name
                    + "");// (");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("vdupl", "z4grzlmn");

                // Copy the contents of the file to the request stream.
                try
                {
                    BinaryReader sourceStream = new BinaryReader(File.Open(sFileNameToUpload, FileMode.Open));
                    byte[] fileContents = new byte[sourceStream.BaseStream.Length];
                    for (int readPos = 0; readPos < fileContents.Length; readPos++)
                    {
                        fileContents[readPos] = sourceStream.ReadByte();
                    }
                    sourceStream.Close();
                    request.ContentLength = fileContents.Length;

                    Stream requestStream = request.GetRequestStream();

                    Console.WriteLine("Upload File {0} Started. ", sFileNameToUpload);

                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    Console.WriteLine("Upload File {0} Complete, status {1}", sFileNameToUpload, response.StatusDescription);

                    response.Close();
                    //delete source file after uploading
                    try
                    {
                        File.Delete(sFileNameToUpload.Replace("flv", "avi"));
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Cannot delete file {0}, it is used by another process. ", sFileNameToUpload.Replace("flv", "avi"));
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Faili dakavebulia. Gtxovt scadot tavidan. ");
                }
            }
        }
    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            VideoCaptureController.EnsureWeHaveAFileWithCSVPathInIt();

            RecorderController frmRecorderController = new RecorderController();
            Application.EnableVisualStyles();
            Application.Run(frmRecorderController);
        }
    }
}
