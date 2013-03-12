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
            //capture.FrameSize = new System.Drawing.Size(360, 288);
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
                        //////////////// CONVERT & UPLOAD .FLV
                        string sFlvOutputName = sCurrentRecordingFileName.Substring(0, sCurrentRecordingFileName.LastIndexOf(".")) + ".flv";
                        System.Diagnostics.Process convertFlv = new System.Diagnostics.Process();
                        convertFlv.StartInfo
                            = new System.Diagnostics.ProcessStartInfo
                                (@"c:\Program Files\WinFF\ffmpeg.exe", " -i "
                            + "\"" + sCurrentRecordingFileName + "\""
                            + " -ar 44100 "
                            + " -b 1250k "
                            + " -r 25 "
                            + " -ab 128k "
                            + " -y "
                            + "\"" + sFlvOutputName + "\"");
                        convertFlv.EnableRaisingEvents = true;
                        convertFlv.Exited += new EventHandler(delegate(object sender, EventArgs e)
                        {
                            if (convertFlv.ExitCode != 0)
                            {
                                //if ffmpeg failed, then there will be no flv/jpg and we won't delete avi or try to upload flv/jpeg
                                Console.WriteLine("Konvertirebisas moxda shecdoma {0}.", convertFlv.ExitCode);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Konvertireba dasrulda shedegit {0}.", convertFlv.ExitCode);
                            }
                            //avtvirtavt tu ara damokidebulia checkbox-is mier 
                            //RecorderController.fUploadToFTP-shi chaceril cvladze
                            if (RecorderController.fUploadToFTP)
                            {
                                //droebit, vtvirtavt FLV-s chaceris morchenistanave
                                FTPUploader uplFlv = new FTPUploader(sFlvOutputName);
                                uplFlv.UploadFileToFTP();
                            }
                            else
                            {
                                File.Delete(sFlvOutputName.Replace("flv", "avi"));
                                File.Delete(sFlvOutputName.Replace("flv", "jpg"));
                            }
                            //Thread thrUpload = new Thread(new ThreadStart(upl.UploadFileToFTP));
                            //thrUpload.SetApartmentState(ApartmentState.STA);
                            //thrUpload.Start();
                            //////////////// CONVERT & UPLOAD .JPG WHEN .FLV is done
                            string sJpegOutputName = sCurrentRecordingFileName.Substring(0, sCurrentRecordingFileName.LastIndexOf(".")) + ".jpg";
                            System.Diagnostics.Process convertJpeg = new System.Diagnostics.Process();
                            convertJpeg.StartInfo
                                = new System.Diagnostics.ProcessStartInfo
                                    (@"c:\Program Files\WinFF\ffmpeg.exe", " -i "
                                + "\"" + sFlvOutputName + "\""
                                + " -vframes 1 "
                                + " -ss 00:00:06 "
                                + " -f image2 "
                                + "\"" + sJpegOutputName + "\"");
                            convertJpeg.EnableRaisingEvents = true;
                            convertJpeg.Exited += new EventHandler(delegate(object senderJpeg, EventArgs eJpeg)
                            {
                                if (RecorderController.fUploadToFTP)
                                {
                                    //droebit, vtvirtavt JPG-s chaceris morchenistanave
                                    FTPUploader uplJpeg = new FTPUploader(sJpegOutputName);
                                    uplJpeg.UploadFileToFTP();
                                }
                            });
                            //
                            convertJpeg.Start();
                        });
                        convertFlv.Start();
                        //end
                    }
                    //
                }
            }
            //
        }

        public static void SaveTestCodecFiles()
        {
            DirectX.Capture.Filters arrF = new Filters();
            int i = 0;
            System.Timers.Timer t = new System.Timers.Timer(10000);
            t.Elapsed += new ElapsedEventHandler(delegate(object sender, ElapsedEventArgs e)
            {
                if (null != capture && !capture.Stopped)
                {
                    capture.Stop();
                }
                if (i >= arrF.VideoCompressors.Count)
                {
                    t.Stop();
                    Console.WriteLine("codec test complete");
                    return;
                }
                capture = new Capture(filters.VideoInputDevices[0], null);
                capture.VideoCompressor = arrF.VideoCompressors[i];
                //capture.FrameSize = new System.Drawing.Size(360, 288);

                if (!Directory.Exists(@"V:\codecs"))
                {
                    Directory.CreateDirectory(@"V:\codecs");
                }
                StartRecording(@"V:\codecs\" + "index-" + i + "-" + arrF.VideoCompressors[i].Name + ".avi");
                //
                i++;
            });
            t.Start();
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
            string ftpHost = "92.241.90.24";
            string ftpUser = "vdupl";
            string ftpPass = "z4grzlmn";
            string ftpConfPath = "C:\\videorecorder.config";
            if (File.Exists(ftpConfPath))
            {
                string[] confLines = File.ReadAllLines(ftpConfPath);
                if (confLines.Length >= 3)
                {
                    ftpHost = confLines[0];
                    ftpUser = confLines[1];
                    ftpPass = confLines[2];
                }
            }
            //
            Thread.Sleep(1000);
            if (File.Exists(sFileNameToUpload))
            {
                // Get the object used to communicate with the server.
                FileInfo fileVideo = new FileInfo(sFileNameToUpload);
                DirectoryInfo parentDay = new DirectoryInfo(fileVideo.DirectoryName);
                DirectoryInfo parentMonth = Directory.GetParent(parentDay.FullName);
                DirectoryInfo parentYear = Directory.GetParent(parentMonth.FullName);
                FtpWebRequest request
                    = (FtpWebRequest)WebRequest.Create("ftp://" + ftpHost + "/videofiles/"
                    + parentYear.Name + "-"
                    + parentMonth.Name + "-"
                    + parentDay.Name + "-"
                    + fileVideo.Name
                    + "");// (");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(ftpUser, ftpPass);

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
                catch (System.Net.WebException)
                {
                    Console.WriteLine("FTP Servertan kavshirisas moxda shecdoma. ");
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
