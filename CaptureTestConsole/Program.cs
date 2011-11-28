using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;
using DirectX.Capture;
using System.Timers;

namespace CaptureTestConsole
{
    public static class VideoCaptureController
    {
        private static Capture capture = null;
        //this line throws exception
        private static Filters filters = new Filters();

        public static bool StartRecording(string sFileName)
        {
            //if (null != capture)
            {
                //if (true == capture.Capturing)
                {
                    //capture.Stop();
                }
            }
            //capture = new Capture(filters.VideoInputDevices[0], null);
            //capture.CaptureComplete += new EventHandler(OnCaptureComplete);
            //capture.Filename = sFileName;
            //capture.Start();
            return true;
        }
        private static void OnCaptureComplete(object sender, EventArgs e)
        {
        }
    }
    class Program
    {
        public static CultureInfo CultureProvider = CultureInfo.InvariantCulture;
        //
        private static int unLineCountLastTime = 0;
        private static string sGadacemisSaxeliLastTime = "";
        /// <summary>
        /// amocmebs CSV fails, aris tu ara axali gadacemis chanaceri
        /// </summary>
        /// <returns>abrunebs true-s tu axali gadacema daicko, tuarada false-s.</returns>
        public static bool nextCSVResult(out string sShemdegiGadacemisSaxeli
                                        , out DateTime dtAxaliGadacemisDackebisDro)
        {
            string[] lsAllLines = File.ReadAllLines("../OAStudioLog20111101.csv");
            if (lsAllLines.Length > unLineCountLastTime && sGadacemisSaxeliLastTime != lsAllLines[lsAllLines.Length - 1].Split(',')[4])
            {
                unLineCountLastTime = lsAllLines.Length;
                string[] arrBoloStriqonisMonacemebi = lsAllLines[lsAllLines.Length - 1].Split(',');
                sGadacemisSaxeliLastTime = arrBoloStriqonisMonacemebi[4];
                //todo guess name from arrBoloStriqonisMonacemebi[4]
                sShemdegiGadacemisSaxeli = arrBoloStriqonisMonacemebi[4].Substring(arrBoloStriqonisMonacemebi[4].LastIndexOf('\\'));
                dtAxaliGadacemisDackebisDro = DateTime.ParseExact(arrBoloStriqonisMonacemebi[5] + " " + arrBoloStriqonisMonacemebi[6]
                                                                    , @"dd\/M\/yyyy HH:mm:ss"
                                                                    , CultureProvider);
                return true;
            }
            else
            {
                sShemdegiGadacemisSaxeli = null;
                dtAxaliGadacemisDackebisDro = DateTime.Now;
                return false;
            }
        }
        static void Main(string[] args)
        {
            //VideoCaptureController capturer = new VideoCaptureController();
            //
            System.Timers.Timer timerResetCheckOrNot = new System.Timers.Timer(3000);
            timerResetCheckOrNot.Elapsed += delegate(object sender, ElapsedEventArgs e)
            {
                string sAxaliGadacemisSaxeli;
                DateTime dtAxaliGadacemisDackebisDro;
                if (true == nextCSVResult(out sAxaliGadacemisSaxeli, out dtAxaliGadacemisDackebisDro))
                {
                    Console.WriteLine("new capture {0} at {1}", sAxaliGadacemisSaxeli, dtAxaliGadacemisDackebisDro);
                    //call capture
                    //move file related code to StartCapture?
                    if (false == Directory.Exists("C:\\" + sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.LastIndexOf("."))))
                    {
                    }
                    VideoCaptureController.StartRecording("C:\\" + sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.LastIndexOf(".")) + "\\" + sAxaliGadacemisSaxeli);
                    //
                }
                else
                {
                    Console.WriteLine("don't stop capturing");
                }
            };
            timerResetCheckOrNot.Start();
            Console.ReadLine();
            //
        }
    }
}
