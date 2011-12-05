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
    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RecorderController frmRecorderController = new RecorderController();
            Application.EnableVisualStyles();
            Application.Run(frmRecorderController);
        }
    }
}
