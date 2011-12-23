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
using System.Net;
using System.Net.Cache;

namespace CaptureTestConsole
{
    public partial class RecorderController : Form
    {
        public RecorderController()
        {
            InitializeComponent();
        }
        //
        private static string sMainDir = "V:\\";
        //
        public static CultureInfo CultureProvider = CultureInfo.InvariantCulture;
        //
        public static MySqlConnection sqlConn = new MySqlConnection("Server=localhost;Database=imedi_db;Uid=root;Pwd=hard3ord;");
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
            //string[] lsAllLines = File.ReadAllLines(File.ReadAllText(VideoCaptureController.sFileContainingInfoAboutCSVFilePath));

            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create("ftp://92.241.90.13/" + "OAStudioLog"
                                                                                        + DateTime.Now.Year.ToString()
                                                                                        + RecorderController.add_zeros(DateTime.Now.Month.ToString())
                                                                                        + RecorderController.add_zeros(DateTime.Now.Day.ToString())
                                                                                        + ".csv");
            ftp.Credentials = new NetworkCredential("log", "log");
            ftp.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);//nocachenostore?
            try
            {
                System.Net.FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();
                StreamReader csv = new StreamReader(resp.GetResponseStream(), Encoding.ASCII);
                //
                string[] lsAllLines = csv.ReadToEnd().Replace("\r", "").Split('\n');
                //
                int lastValidLineNum = lsAllLines.Length - 1;
                while ("" == lsAllLines[lastValidLineNum]
                    || lsAllLines[lastValidLineNum].Split(',').Length < 7
                    || "On Air Studio terminated" == lsAllLines[lastValidLineNum].Split(',')[6]
                    || (lsAllLines[lastValidLineNum].Split(',').Length > 7 && "Playback Stopped" == lsAllLines[lastValidLineNum].Split(',')[7])
                    || !(lsAllLines[lastValidLineNum].LastIndexOf(',') > lsAllLines[lastValidLineNum].IndexOf(','))
                    || !("RED" == lsAllLines[lastValidLineNum].Split(',')[1] || "PLAY" == lsAllLines[lastValidLineNum].Split(',')[1] || "NEWS PLAY" == lsAllLines[lastValidLineNum].Split(',')[1])
                    )
                {
                    if (0 > lastValidLineNum)
                    {
                        Console.WriteLine("CSV File not valid. Press any key to exit!");
                        Console.ReadLine();
                        Application.Exit();
                        break;
                    }
                    lastValidLineNum--;
                }
                if (lsAllLines.Length > unLineCountLastTime
                    && sGadacemisSaxeliLastTime != lsAllLines[lastValidLineNum].Split(',')[4])
                {
                    unLineCountLastTime = lsAllLines.Length;
                    string[] arrBoloStriqonisMonacemebi = lsAllLines[lastValidLineNum].Split(',');
                    sGadacemisSaxeliLastTime = TrimFileNameFromUnwantedChars(arrBoloStriqonisMonacemebi[4]);
                    //todo guess name from arrBoloStriqonisMonacemebi[4]
                    sShemdegiGadacemisSaxeli
                        = TrimFileNameFromUnwantedChars(
                                arrBoloStriqonisMonacemebi[4].Substring(arrBoloStriqonisMonacemebi[4].LastIndexOf('\\') + 1));
                    try
                    {
                        dtAxaliGadacemisDackebisDro = DateTime.ParseExact(arrBoloStriqonisMonacemebi[5] + " " + arrBoloStriqonisMonacemebi[6]
                            //, @"dd\/M\/yyyy HH:mm:ss"
                                                                        , @"M\/dd\/yyyy HH:mm:ss"
                                                                        , CultureProvider);
                    }
                    catch (FormatException)
                    {
                        dtAxaliGadacemisDackebisDro = DateTime.ParseExact(arrBoloStriqonisMonacemebi[5] + " " + arrBoloStriqonisMonacemebi[6]
                            //, @"dd\/M\/yyyy HH:mm:ss"
                                                                        , @"dd\/M\/yyyy HH:mm:ss"
                                                                        , CultureProvider);
                    }
                    return true;
                }
                else
                {
                    sShemdegiGadacemisSaxeli = null;
                    dtAxaliGadacemisDackebisDro = DateTime.Now;
                    return false;
                }
            }
            catch (WebException)
            {
                sShemdegiGadacemisSaxeli = null;
                dtAxaliGadacemisDackebisDro = DateTime.Now;
                Console.WriteLine("CSV File not found for current day. ");
                return false;
            }
        }

        public static string TrimFileNameFromUnwantedChars(string s)
        {
            string ret = s;
            ret = ret.Replace(" ", "");
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                ret = ret.Replace(c.ToString(), "");
            }
            return ret;
        }

        //cvlis parametrs bazidan camogebuli saxelit, tu DateTime.Now() droistvis aris [fOnlyForName = 1] chanaceri bazashi
        public static bool ChangeParamIfInDBIsGadacemaOnlyForName(ref string sParamGadacemaName)
        {
            bool fAnythingFound = false;
            MySqlCommand select = new MySqlCommand("SELECT * FROM Gadacema WHERE dttStartTime < NOW() "
                                                    + " AND dttEndTime > NOW() "
                                                    + " AND fUseOnlyForName = 1 " + " ;"
                                                  , sqlConn);
            MySqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                sParamGadacemaName = (string)reader["sGadacemisSaxeli"];
                fAnythingFound = true;
            }
            reader.Close();
            return fAnythingFound;
        }

        /// <summary>
        /// Pseudocode, but structure is correct, only modify variable names and SQL command text
        /// </summary>
        /// <param name="GadacemisSaxeli"></param>
        /// <param name="dttStartTime"></param>
        /// <returns></returns>
        public static bool isThereGadacemebiForNow(string sNowPlaying, out string GadacemisSaxeli, out DateTime dttStartTime)
        {
            bool recordsFound = false;
            GadacemisSaxeli = "";
            dttStartTime = DateTime.Now;
            //
            MySqlCommand select = new MySqlCommand("SELECT * FROM Gadacema WHERE dttStartTime < NOW() "
                                                    + " AND dttEndTime > NOW() "
                                                    + " AND sGadacemisSaxeli != '" + sNowPlaying.Replace("'", "").Replace("\"", "") + "' "
                                                    + " AND fUseOnlyForName = 0 " + " ;"
                                                  , sqlConn);
            MySqlDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                if (sNowPlaying != (string)reader["sGadacemisSaxeli"])
                {
                    recordsFound = true;
                    GadacemisSaxeli = (string)reader["sGadacemisSaxeli"];
                    dttStartTime = (DateTime)reader["dttStartTime"];
                    //dttEndTime = (DateTime)reader["dttEndTime"];
                }
                break;
            }
            reader.Close();
            return recordsFound;
        }

        public static string add_zeros(string s)
        {
            return s.Length > 1 ? s : "0" + s;
        }

        private void RecorderController_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            ////VideoCaptureController capturer = new VideoCaptureController();
            //
            System.Timers.Timer timerResetCheckOrNot = new System.Timers.Timer(3000);
            string sLastDatabaseOrCSVGadacemaName = "";
            timerResetCheckOrNot.Elapsed += delegate(object senderTimer, ElapsedEventArgs eTimer)
            {
                if ((DateTime.Now.Hour >= 3) && (DateTime.Now.Hour < 7))
                {
                    //don't record between 03:00 AM and 07:00 AM
                    VideoCaptureController.StopRecording();
                    return;
                }
                string sAxaliGadacemisSaxeli;
                DateTime dtAxaliGadacemisDackebisDro;
                if (true == nextCSVResult(out sAxaliGadacemisSaxeli, out dtAxaliGadacemisDackebisDro))
                {
                    //
                    string sGadacemaName = (0 < sAxaliGadacemisSaxeli.IndexOf("_"))
                        ? sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.IndexOf("_"))
                        //:"undefined";
                        : (0 < sAxaliGadacemisSaxeli.IndexOf("."))
                            ? sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.LastIndexOf("."))
                            : sAxaliGadacemisSaxeli;
                    ChangeParamIfInDBIsGadacemaOnlyForName(ref sGadacemaName);
                    sLastDatabaseOrCSVGadacemaName = sGadacemaName;
                    //call capture
                    VideoCaptureController.StartRecording(sPrepareAndReturnFileDestination(sGadacemaName, dtAxaliGadacemisDackebisDro));
                    //
                }
                else if (true == isThereGadacemebiForNow(sGadacemisSaxeliLastTime, out sAxaliGadacemisSaxeli, out dtAxaliGadacemisDackebisDro)
                    && sLastDatabaseOrCSVGadacemaName != sAxaliGadacemisSaxeli)
                {
                    //
                    //string sGadacemaName = (0 < sAxaliGadacemisSaxeli.IndexOf("_"))
                    //    ? sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.IndexOf("_"))
                    //    //:"undefined";
                    //    : sAxaliGadacemisSaxeli.Substring(0, sAxaliGadacemisSaxeli.LastIndexOf(".")).Replace(" ", "");
                    string sGadacemaName = sAxaliGadacemisSaxeli;
                    sLastDatabaseOrCSVGadacemaName = sGadacemaName;
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
            sqlConn.Open();
            //
            txtPathToCSV.Text = File.ReadAllText(VideoCaptureController.sFileContainingInfoAboutCSVFilePath);
            //
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            sqlConn.Close();
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
                           + "-" + add_zeros(dtAxaliGadacemisDackebisDro.Second.ToString())
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

        private void btnChooseCSVFile_Click(object sender, EventArgs e)
        {
            dlgChooseCSVFile.ShowDialog();
        }

        private void dlgChooseCSVFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (File.Exists(dlgChooseCSVFile.FileName))
            {
                string[] arrsNewCSVContents = File.ReadAllLines(dlgChooseCSVFile.FileName);
                if (6 > arrsNewCSVContents[0].Count(w => ',' == w))
                {
                    MessageBox.Show("არჩეულ ფაილში მინიმუმ 6 სვეტი უნდა იყოს!");
                    e.Cancel = true;
                }
                else
                {
                    //file is valid
                    VideoCaptureController.EnsureWeHaveAFileWithCSVPathInIt(dlgChooseCSVFile.FileName);
                    txtPathToCSV.Text = dlgChooseCSVFile.FileName;
                }
            }
            else
            {
                MessageBox.Show("მოხდა შეცდომა. ფაილი არ არსებობს!");
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            VideoCaptureController.StopRecording();
        }
    }
}
