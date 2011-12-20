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
            capture.Start();
            sCurrentRecordingFileName = sFileName;
            Console.WriteLine("new capture {0}", sFileName);
            return true;
        }

        private static void OnCaptureComplete(object sender, EventArgs e)
        {
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
                                                                                        +".csv");
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
                        System.Diagnostics.Process convert = System.Diagnostics.Process.Start(@"c:\Program Files\WinFF\ffmpeg.exe", " -i "
                            + sCurrentRecordingFileName
                            + " -ar 44100 "
                            + " -y "
                            + sCurrentRecordingFileName.Substring(0, sCurrentRecordingFileName.LastIndexOf("."))
                            + ".flv");
                        convert.Exited += new EventHandler(delegate(object sender, EventArgs e)
                        {
                            if (File.Exists(sCurrentRecordingFileName))
                            {
                                File.Delete(sCurrentRecordingFileName);
                            }
                        });
                    }
                    //
                }
            }
            //
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
