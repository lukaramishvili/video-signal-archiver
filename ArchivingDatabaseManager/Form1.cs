using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.IO;

namespace ArchivingDatabaseManager
{
    public partial class frmGadacemebisMartva : Form
    {
        public frmGadacemebisMartva()
        {
            InitializeComponent();
        }

        public static string add_zeros(string s)
        {
            return s.Length > 1 ? s : "0" + s;
        }
        //
        public static CultureInfo CultureProvider = CultureInfo.InvariantCulture;
        //

        public static MySqlConnection sqlConn = new MySqlConnection("Server=localhost;Database=imedi_db;Uid=root;Pwd=hard3ord;");

        public void LoadChosenDayFromDatabase()
        {
            dgvDgisPrograma.Rows.Clear();
            dgvDgisPrograma.Enabled = false;
            DateTime dtSel = dttChooseDay.Value;
            MySqlCommand cmdLoadDay
                = new MySqlCommand("SELECT TIME(dttStartTime), TIME(dttEndTime), sGadacemisSaxeli, fUseOnlyForName "
                                    + " FROM gadacema "
                                    + " WHERE DATE(dttStartTime) = '"
                                    + dtSel.Year.ToString() + "-"
                                    + add_zeros(dtSel.Month.ToString())
                                    + "-" + add_zeros(dtSel.Day.ToString()) + "' ;"
                                , sqlConn);
            MySqlDataReader rdr = cmdLoadDay.ExecuteReader();
            while (rdr.Read())
            {
                /*object[] rows = new object[rdr.FieldCount];
                rdr.GetValues(rows);
                dgvDgisPrograma.Rows.Add(rows);*/
                DateTime dbdttStartTime = DateTime.Parse(rdr[0].ToString());
                DateTime dbdttEndTime = DateTime.Parse(rdr[1].ToString());
                string dbsGadacemisSaxeli = rdr[2].ToString();
                int dbfUseOnlyForName = Int32.Parse(rdr[3].ToString());
                dgvDgisPrograma.Rows.Add(new object[]{
                    //  dbdttStartTime.ToString(@"dd-MM-yyyy HH:mm:ss", CultureProvider)
                    //, dbdttEndTime.ToString(@"dd-MM-yyyy HH:mm:ss", CultureProvider)
                      dbdttStartTime.ToString(@"HH:mm:ss", CultureProvider)
                    , dbdttEndTime.ToString(@"HH:mm:ss", CultureProvider)
                    , dbsGadacemisSaxeli
                    , dbfUseOnlyForName
                });
            }
            rdr.Close();
            dgvDgisPrograma.Enabled = true;
        }

        public bool SaveChosenDayToDatabase(DateTime dtSel)
        {
            bool retVal = true;
            //
            //DateTime dtSel = dttChooseDay.Value;
            MySqlTransaction transactionUpdateDay = sqlConn.BeginTransaction();
            //
            MySqlCommand removeOlds
                = new MySqlCommand("DELETE FROM gadacema WHERE DATE(dttStartTime) = '"
                    + dtSel.Year.ToString() + "-" + add_zeros(dtSel.Month.ToString())
                    + "-" + add_zeros(dtSel.Day.ToString())
                    + "' ;"
                , sqlConn, transactionUpdateDay);
            removeOlds.ExecuteNonQuery();
            //
            foreach (DataGridViewRow xRow in dgvDgisPrograma.Rows)
            {
                if(false == xRow.IsNewRow){
                try
                {
                    DateTime xStartTime = DateTime.ParseExact(xRow.Cells[0].Value.ToString(), @"HH:mm:ss"/*@"dd-MM-yyyy HH:mm:ss"*/, CultureProvider);
                    DateTime xEndTime = DateTime.ParseExact(xRow.Cells[1].Value.ToString(), @"HH:mm:ss"/*@"dd-MM-yyyy HH:mm:ss"*/, CultureProvider);
                    string xGadacemisSaxeli = xRow.Cells[2].Value.ToString();
                    string xUseOnlyForName = (xRow.Cells[3].Value ?? "False").ToString();
                    foreach (char invalidChar in Path.GetInvalidFileNameChars())
                    {
                        xGadacemisSaxeli = xGadacemisSaxeli.Replace(invalidChar.ToString(), "");
                    }
                    MySqlCommand cmdInsertGadacema
                        = new MySqlCommand("INSERT INTO `imedi_db`.`gadacema`"
                            + "(`sGadacemisSaxeli`,"
                            + "`dttStartTime`,"
                            + "`dttEndTime`,"
                            + "`fUseOnlyForName`)"
                            + "  VALUES "
                            + " ( "
                            + " '" + xGadacemisSaxeli + "', "
                            //+ " '" + xStartTime.ToString(@"yyyy-MM-dd HH:mm:ss", CultureProvider) + "', "
                            + " '" + dtSel.ToString(@"yyyy-MM-dd", CultureProvider) + " " + xStartTime.ToString(@"HH:mm:ss", CultureProvider) + "', "
                            //+ " '" + xEndTime.ToString(@"yyyy-MM-dd HH:mm:ss", CultureProvider) + "', "
                            + " '" + dtSel.ToString(@"yyyy-MM-dd", CultureProvider) + " " + xEndTime.ToString(@"HH:mm:ss", CultureProvider) + "', "
                            + " '" + (("True"==xUseOnlyForName.ToString())?1:0) + "' "
                            + ");"
                        , sqlConn, transactionUpdateDay);
                    cmdInsertGadacema.ExecuteNonQuery();
                }
                catch (FormatException)
                {
                    retVal = false;
                    break;
                }
                catch (NullReferenceException)
                {
                    retVal = false;
                    break;
                }
            }
            }
            if (true == retVal)
            {
                transactionUpdateDay.Commit();
                LoadChosenDayFromDatabase();
            }
            else
            {
                transactionUpdateDay.Rollback();
            }
            return retVal;
        }

        private void dttChooseDay_ValueChanged(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("დაუმახსოვრებელი ცვლილებები დაიკარგება. გსურთ გააგრძელოთ?", "დადასტურება", MessageBoxButtons.YesNo))
            {
                LoadChosenDayFromDatabase();
            }
        }

        private void btnSaveGadacemebiToDatabase_Click(object sender, EventArgs e)
        {
            if (true == SaveChosenDayToDatabase(dttChooseDay.Value))
            {
                MessageBox.Show("გადაცემების სიის მონაცემთა ბაზაში შენახვა წარმატებით დასრულდა!");
            }
            else
            {
                MessageBox.Show("მონაცემების შენახვა არ მოხერხდა. გთხოვთ გაასწოროთ შეცდომები და სცადოთ თავიდან!");
            }
        }

        private void frmGadacemebisMartva_Load(object sender, EventArgs e)
        {
            sqlConn.Open();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            LoadChosenDayFromDatabase();
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            sqlConn.Close();
        }

        private void btnCopyToTomorrow_Click(object sender, EventArgs e)
        {
            if (true == SaveChosenDayToDatabase(dttChooseDay.Value.AddDays(1)))
            {
                MessageBox.Show("გადაცემების სიის მონაცემთა ბაზაში შენახვა წარმატებით დასრულდა!");
            }
            else
            {
                MessageBox.Show("მონაცემების შენახვა არ მოხერხდა. გთხოვთ გაასწოროთ შეცდომები და სცადოთ თავიდან!");
            }
        }

        private void btnCopyToNextWeek_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 7; i++)
            {
                if (true == SaveChosenDayToDatabase(dttChooseDay.Value.AddDays(i)))
                {
                    MessageBox.Show("გადაცემები შენახულია " + dttChooseDay.Value.AddDays(i).ToString() + "–სთვის!");
                }
                else
                {
                    MessageBox.Show("მონაცემების შენახვა არ მოხერხდა. გთხოვთ გაასწოროთ შეცდომები და სცადოთ თავიდან!");
                }
            }
        }
    }
}
