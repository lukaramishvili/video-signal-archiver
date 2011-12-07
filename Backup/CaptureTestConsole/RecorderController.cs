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
    public partial class RecorderController : Form
    {
        public RecorderController()
        {
            InitializeComponent();
        }
        //
        private static string sMainDir = "C:\\";
        //
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
                sShemdegiGadacemisSaxeli = arrBoloStriqonisMonacemebi[4].Substring(arrBoloStriqonisMonacemebi[4].LastIndexOf('\\') + 1);
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

        public static string add_zeros(string s)
        {
            return s.Length > 1 ? s : "0" + s;
        }

        private void RecorderController_Load(object sender, EventArgs e)
        {
            ////VideoCaptureController capturer = new VideoCaptureController();
            //
            System.Timers.Timer timerResetCheckOrNot = new System.Timers.Timer(3000);
            timerResetCheckOrNot.Elapsed += delegate(object senderTimer, ElapsedEventArgs eTimer)
            {
                string sAxaliGadacemisSaxeli;
                DateTime dtAxaliGadacemisDackebisDro;
                if (true == nextCSVResult(out sAxaliGadacemisSaxeli, out dtAxaliGadacemisDackebisDro))
                {
                    //
                    string sGadacemaName = (0 < sAxaliGadacemisSaxeli.IndexOf("_"))
                        ? sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.IndexOf("_"))
                        //:"undefined";
                        : sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.LastIndexOf(".")).Replace(" ", "");
                    //call capture
                    VideoCaptureController.StartRecording(sPrepareAndReturnFileDestination(sGadacemaName, dtAxaliGadacemisDackebisDro));
                    //
                }
                else
                {
                    //Console.WriteLine("don't stop capturing");
                }
            };
            timerResetCheckOrNot.Start();
            //
        }

        //creates needed folders and returns formatted file name
        private string sPrepareAndReturnFileDestination(string sGadacemaName, DateTime dtAxaliGadacemisDackebisDro)
        {
            string sDirName = sMainDir + dtAxaliGadacemisDackebisDro.Year + "\\";
            if (false == Directory.Exists(sDirName))
            {
                Directory.CreateDirectory(sDirName);
            }
            sDirName += add_zeros(dtAxaliGadacemisDackebisDro.Month.ToString()) + "\\";
            if (false == Directory.Exists(sDirName))
            {
                Directory.CreateDirectory(sDirName);
            }
            sDirName += add_zeros(dtAxaliGadacemisDackebisDro.Day.ToString()) + "\\";
            if (false == Directory.Exists(sDirName))
            {
                Directory.CreateDirectory(sDirName);
            }
            return sDirName + add_zeros(dtAxaliGadacemisDackebisDro.Hour.ToString())
                           + "-" + add_zeros(dtAxaliGadacemisDackebisDro.Minute.ToString())
                           + "-" + sGadacemaName
                           + ".avi";
        }

        private void btnStopAndStart_Click(object sender, EventArgs e)
        {
            if (0 < txtNextGadacemaName.Text.Length)
            {
                VideoCaptureController.StartRecording(sPrepareAndReturnFileDestination(txtNextGadacemaName.Text, DateTime.Now));
            }
        }
    }
}
