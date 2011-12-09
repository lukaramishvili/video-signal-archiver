using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ArchivingDatabaseManager
{
    public partial class frmGadacemebisMartva : Form
    {
        public frmGadacemebisMartva()
        {
            InitializeComponent();
        }
        public static MySqlConnection sqlConn = new MySqlConnection("Server=localhost;Database=imedi_db;Uid=root;Pwd=hard3ord;");

        public void LoadChosenDayFromDatabase()
        {
            MessageBox.Show(String.Format("Load database for day {0}", dttChooseDay.Value));
        }

        public bool SaveChosenDayToDatabase()
        {
            MessageBox.Show(String.Format("If entered datetime da gadacemis saxeli is correctly formatted,\n"
                                            + "Then save gadacemebis database for day {0}", dttChooseDay.Value));
            return true;
        }

        private void dttChooseDay_ValueChanged(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("დაუმახსოვრებელი ცვლილებები დაიკარგება. გსურთ გააგრძელოთ?", "დადასტურება", MessageBoxButtons.YesNo))
            {
                MessageBox.Show("სხვა დღეს ვირჩევთ!");
            }
        }

        private void btnSaveGadacemebiToDatabase_Click(object sender, EventArgs e)
        {
            if (true == SaveChosenDayToDatabase())
            {
                MessageBox.Show("გადაცემების სიის მონაცემთა ბაზაში შენახვა წარმატებით დასრულდა!");
            }
            else
            {
                MessageBox.Show("მონაცემების შენახვა არ მოხერხდა. გთხოვთ გაასწოროთ შეცდომები და სცადოთ თავიდან!");
            }
        }
    }
}
