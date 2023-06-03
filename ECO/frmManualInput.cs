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

    public partial class frmManualInput : Form
    {
        private frmCheckAttendance m_Parent;
        public DateTime ditdit;
        public int empID;
        public string timr1;
        public string timr2;
        public string timr3;
        public string timr4;

        public frmManualInput(frmCheckAttendance frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void frmManualInput_Load(object sender, EventArgs e)
        {
            loadcombo(empID, ditdit);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Add this Input?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                CheckOpen.cons();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM attendance WHERE datein='" + ditdit.ToString("yyyy-MM-dd") + "' AND empID=" + empID, msqlcon.con);
                da.Fill(dt);
                string selected = "";
                if (cboSelect.Text == "Time In 1")
                {
                    selected = "TimeIn1";
                }
                else if (cboSelect.Text == "Time Out 1")
                {
                    selected = "TimeOut1";
                }
                else if (cboSelect.Text == "Time In 2")
                {
                    selected = "TimeIn2";
                }
                else if (cboSelect.Text == "Time Out 2")
                {
                    selected = "TimeOut2";
                }
                if (cboSelect.Text == "")
                {
                    MessageBox.Show("Please Select A Column to Manually Log", "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE attendance SET " + selected + "='" + dtpTime.Value.ToString("h:mm tt") + "' WHERE dateIn='" + ditdit.ToString("yyyy-MM-dd") + "' AND empID=" + empID, msqlcon.con);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show(dtpTime.Value.ToLongTimeString());
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO attendance(Day, DateIn, EmpID, " + selected + ") VALUES('" + ditdit.DayOfWeek.ToString() + "','" + ditdit.ToString("yyyy-MM-dd") + "'," + empID + ",'" + dtpTime.Value.ToString("h:mm tt") + "')", msqlcon.con);
                        cmd.ExecuteNonQuery();
                        // MessageBox.Show(dtpTime.Value.ToLongTimeString());
                    }
                    loadcombo(empID, ditdit);
                    m_Parent.LoadList();
                }
            }
            
            
        }

        public void loadcombo(int iID, DateTime dit)
        {
            cboSelect.Items.Clear();
            CheckOpen.cons();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT dateIn, empID, timeIn1, TimeOut1, TimeIn2, TimeOut2 FROM attendance WHERE empID=" + empID + " AND dateIn='" + dit.ToString("yyyy-MM-dd") + "'", msqlcon.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                timr1 = dt.Rows[0][2].ToString();
                timr2 = dt.Rows[0][3].ToString();
                timr3 = dt.Rows[0][4].ToString();
                timr4 = dt.Rows[0][5].ToString();
            }
            else
            {
                timr1 = "";
                timr2 = "";
                timr3 = "";
                timr4 = "";
               
            }
            //MessageBox.Show(timr1);
            //MessageBox.Show(timr2);
            //MessageBox.Show(timr3);
            //MessageBox.Show(timr4);
            if (timr1 == "" || timr1 == null)
            {
                cboSelect.Items.Add("Time In 1");
            }

            if (timr2 == "" || timr2 == null)
            {
                cboSelect.Items.Add("Time Out 1");
            }

            if (timr3 == "" || timr3 == null)
            {
                cboSelect.Items.Add("Time In 2");
            }

            if (timr4 == "" || timr4 == null)
            {
                cboSelect.Items.Add("Time Out 2");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
