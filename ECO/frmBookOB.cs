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
    public partial class frmBookOB : Form
    {
        List<int> arrEmpID;
        private frmOfficialBusiness m_Parent;
        public int selID;
        public frmBookOB(frmOfficialBusiness frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboNames.Text == "" || txtID.Text == "" || txtDestination.Text == "")
            {
                MessageBox.Show("Please enter necessary data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (MessageBox.Show("Save OB?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.Yes)
                {
                    CheckOpen.cons();
                    if (this.Text == "Book OB")
                    { 
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO officialbusiness(empID, DateFrom, DateTo, Destination) VALUES(" + arrEmpID[cboNames.SelectedIndex] + ",'" + dtpFrom.Value.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.ToString("yyyy-MM-dd") + "','" + txtDestination.Text.Replace("'","''") + "')", msqlcon.con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("OB has been Booked", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_Parent.loadOB();
                        this.Close();
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE officialbusiness SET DateFrom='" + dtpFrom.Value.ToString("yyyy-MM-dd") + "', DateTo='" + dtpTo.Value.ToString("yyyy-MM-dd") + "',Destination='" + txtDestination.Text.Replace("'","''") + "'", msqlcon.con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("OB has been Modified", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_Parent.loadOB();
                        this.Close();
                    }
                   
                }
            }

        }

        public void loadnames()
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT empID, LastName, FirstName, MiddleInitial FROM emp WHERE empstat='Employed'", msqlcon.con);
            da.Fill(dt);
            cboNames.Items.Clear();
            arrEmpID = new List<int>();
            if (dt.Rows.Count > 0)
            {
                for (int x =0; x <= dt.Rows.Count - 1; x++)
                {
                    arrEmpID.Add((int)dt.Rows[x][0]);
                    cboNames.Items.Add(dt.Rows[x][1].ToString() + ", " + dt.Rows[x][2].ToString() + " " + dt.Rows[x][2].ToString() + ".");
                }
                
            }
        }

        private void cboNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text =  arrEmpID[cboNames.SelectedIndex].ToString();
        }
    }
}
