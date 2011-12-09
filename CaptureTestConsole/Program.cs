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
using MySql.Data.MySqlClient;

namespace CaptureTestConsole
{
    public static class VideoCaptureController
    {
        private static Capture capture = null;
        private static Filters filters = new Filters();

        public static string sFileContainingInfoAboutCSVFilePath = "../csvfilepath.txt";
        //
        public static bool StartRecording(string sFileName)
        {
            if (null != capture)
            {
                //no need to ckeck, capture.Stop() will work anyway
                if (true == capture.Capturing)
                {
                    capture.Stop();
                    capture.Dispose();
                }
            }
            capture = new Capture(filters.VideoInputDevices[0], null);
            capture.CaptureComplete += new EventHandler(OnCaptureComplete);
            capture.Filename = sFileName;
            capture.Start();
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
                File.WriteAllText(sFileContainingInfoAboutCSVFilePath, sNewCSVPath ?? "../OAStudioLog20111101.csv");
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
