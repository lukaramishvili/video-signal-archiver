using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Globalization;

namespace CaptureTestConsole
{
    class Program
    {
        public static CultureInfo CultureProvider = CultureInfo.InvariantCulture;
        //
        public static int unLineCountLastTime = 0;
        /// <summary>
        /// amocmebs CSV fails, aris tu ara axali gadacemis chanaceri
        /// </summary>
        /// <returns>abrunebs true-s tu axali gadacema daicko, tuarada false-s.</returns>
        public static bool nextCSVResult(out string sShemdegiGadacemisSaxeli
                                        , out DateTime dtAxaliGadacemisDackebisDro)
        {
            string[] lsAllLines = File.ReadAllLines("../OAStudioLog20111101.csv");
            if (lsAllLines.Length > unLineCountLastTime)
            {
                unLineCountLastTime = lsAllLines.Length;
                string[] arrBoloStriqonisMonacemebi = lsAllLines[lsAllLines.Length - 1].Split(',');
                //todo guess name from arrBoloStriqonisMonacemebi[4]
                sShemdegiGadacemisSaxeli = arrBoloStriqonisMonacemebi[4];
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
            while (true)
            {
                string sAxaliGadacemisSaxeli;
                DateTime dtAxaliGadacemisDackebisDro;
                if (true == nextCSVResult(out sAxaliGadacemisSaxeli, out dtAxaliGadacemisDackebisDro))
                {
                    Console.WriteLine("new capture {0} at {1}", sAxaliGadacemisSaxeli, dtAxaliGadacemisDackebisDro);
                }
                else
                {
                    Console.WriteLine("don't stop capturing");
                }
                Thread.Sleep(3000);
            }
        }
    }
}
