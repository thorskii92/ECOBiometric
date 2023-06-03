using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ECO
{
    public partial class frmFormula : Form
    {
        public frmFormula()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Save Formulas?","Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CheckOpen.cons();
                MySqlCommand cmdDaily = new MySqlCommand("UPDATE tblFormula SET Formula='" + txtDailyRate.Text + "' WHERE formulaID=1", msqlcon.con);
                cmdDaily.ExecuteNonQuery();
                MySqlCommand cmdGross = new MySqlCommand("UPDATE tblFormula SET Formula='" + txtGrossSalary.Text + "' WHERE formulaID=2", msqlcon.con);
                cmdGross.ExecuteNonQuery();
                MySqlCommand cmdWorkHrs = new MySqlCommand("UPDATE tblFormula SET Formula='" + txtWorkingHours.Text + "' WHERE formulaID=3", msqlcon.con);
                cmdWorkHrs.ExecuteNonQuery();
                MySqlCommand cmdNonTax = new MySqlCommand("UPDATE tblFormula SET Formula='" + txtNonTax.Text + "' WHERE formulaID=4", msqlcon.con);
                cmdNonTax.ExecuteNonQuery();
                MySqlCommand cmdNetSalary = new MySqlCommand("UPDATE tblFormula SET Formula='" + txtNetSalary.Text + "' WHERE formulaID=5", msqlcon.con);
                cmdNetSalary.ExecuteNonQuery();
                MySqlCommand cmdPreTaxSalary = new MySqlCommand("UPDATE tblFormula SET Formula='" + txtPreTaxSalary.Text + "' WHERE formulaID=6", msqlcon.con);
                cmdPreTaxSalary.ExecuteNonQuery();
                MessageBox.Show("Formula has been saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public void loadformula()
        {
            CheckOpen.cons();
            DataTable dtFormula = new DataTable();
            dtFormula.Clear();
            MySqlDataAdapter daDaily = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE formulaID=1", msqlcon.con);
            daDaily.Fill(dtFormula);
            txtDailyRate.Text = dtFormula.Rows[0][0].ToString();
            dtFormula.Clear();

            MySqlDataAdapter daGross = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE formulaID=2", msqlcon.con);
            daGross.Fill(dtFormula);
            txtGrossSalary.Text = dtFormula.Rows[0][0].ToString();
            dtFormula.Clear();

            MySqlDataAdapter daWorkHrs = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE formulaID=3", msqlcon.con);
            daWorkHrs.Fill(dtFormula);
            txtWorkingHours.Text = dtFormula.Rows[0][0].ToString();
            dtFormula.Clear();

            MySqlDataAdapter daNonTax = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE formulaID=4", msqlcon.con);
            daNonTax.Fill(dtFormula);
            txtNonTax.Text = dtFormula.Rows[0][0].ToString();
            dtFormula.Clear();

            MySqlDataAdapter daNetSalary = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE formulaID=5", msqlcon.con);
            daNetSalary.Fill(dtFormula);
            txtNetSalary.Text = dtFormula.Rows[0][0].ToString();
            dtFormula.Clear();

            MySqlDataAdapter daPreTaxSalary = new MySqlDataAdapter("SELECT Formula FROM tblFormula WHERE formulaID=6", msqlcon.con);
            daPreTaxSalary.Fill(dtFormula);
            txtPreTaxSalary.Text = dtFormula.Rows[0][0].ToString();
            dtFormula.Clear();
        }

        private void frmFormula_Load(object sender, EventArgs e)
        {
            loadformula();
        }
    }
}
