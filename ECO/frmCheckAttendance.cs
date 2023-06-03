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
   
    public partial class frmCheckAttendance : Form
    {
        public int daysinm;
        public List<int> attnID;
        //public DateTime deyt;
        private frmManualInput _ManIn;
        public frmCheckAttendance()
        {
            InitializeComponent();
            _ManIn = new frmManualInput(this);
        }

        private void frmCheckAttendance_Load(object sender, EventArgs e)
        {
            loadyear();
        }

        public void LoadAttendance(int indexID)
        {
            lvwListTime.Items.Clear();

            CheckOpen.cons();
            //for (int x)
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT DateIn, Day, TimeIn1, TimeOut1, TimeIn2, TimeOut2 FROM attendance WHERE empID=" + indexID + "", msqlcon.con);
            da.Fill(dt);
        }

        public void loadyear()
        {
            cboYear.Items.Clear();
            for (int x = 2015; x <= DateTime.Now.Year; x++)
            {
                cboYear.Items.Add(x);
            }
        }

        public void loadDays(int year, int month)
        {
            cboFrom.Items.Clear();
            cboTo.Items.Clear();
            
             daysinm = DateTime.DaysInMonth(year, month);
            for (int x = 1; x <= daysinm; x++)
            {
                cboFrom.Items.Add(x);
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDays(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            }
            catch
            {

            }
           
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadDays(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            }
            catch
            {

            }
        }

        private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTo.Items.Clear();
            for (int x = Convert.ToInt32(cboFrom.Text); x <= daysinm; x++)
            {
                cboTo.Items.Add(x);
            }
        }

        private void btnLoadAtt_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        public void LoadList()
        {
            if (cboFrom.Text == "" || cboTo.Text == "" || cboYear.Text == "" || cboMonth.Text == "")
            {
                MessageBox.Show("Please Select Dates", "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CheckOpen.cons();
                lvwListTime.Items.Clear();

                for (int x = Convert.ToInt32(cboFrom.Text); x <= Convert.ToInt32(cboTo.Text); x++)
                {
                    DataTable dt = new DataTable();
                    dt.Rows.Clear();
                    dt.Clear();
                    ListViewItem lst = new ListViewItem();
                    DateTime deyt = Convert.ToDateTime(cboYear.Text + "-" + (cboMonth.SelectedIndex + 1).ToString("0#") + "-" + x.ToString("0#"));

                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT attendanceID, Day, TimeIn1, TimeOut1, TimeIn2, TimeOut2 FROM attendance WHERE DateIn='" + deyt.ToString("yyyy-MM-dd") + "' AND empID=" + txtID.Text, msqlcon.con);
                    da.Fill(dt);
                    lst.Text = deyt.ToString("MMMM dd, yyyy");
                    lst.SubItems.Add(deyt.DayOfWeek.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        //lst.SubItems.Add(dt.Rows[0][1].ToString());
                        lst.SubItems.Add(dt.Rows[0][2].ToString());
                        lst.SubItems.Add(dt.Rows[0][3].ToString());
                        lst.SubItems.Add(dt.Rows[0][4].ToString());
                        lst.SubItems.Add(dt.Rows[0][5].ToString());
                        lvwListTime.Items.Add(lst);
                    }
                    else
                    {
                        //lst.SubItems.Add("");
                        lst.SubItems.Add("");
                        lst.SubItems.Add("");
                        lst.SubItems.Add("");
                        lst.SubItems.Add("");
                        lvwListTime.Items.Add(lst);
                    }

                }
            }
            
        }
        private void btnInput_Click(object sender, EventArgs e)
        {
            if (lvwListTime.SelectedItems.Count > 0)
            {
                
                _ManIn.empID = Convert.ToInt32(txtID.Text);
                _ManIn.ditdit = Convert.ToDateTime(lvwListTime.FocusedItem.Text);
                _ManIn.lblDate.Text = lvwListTime.FocusedItem.Text;
                _ManIn.StartPosition = FormStartPosition.CenterScreen;
                _ManIn.ShowDialog();
            }
           
           // frmManualInput manIn = new frmManualInput();
        }

        private void lvwListTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwListTime.SelectedItems.Count > 0)
            {
                DataTable dtC = new DataTable();
                MySqlDataAdapter daC = new MySqlDataAdapter("SELECT * FROM timesheet WHERE empID=" + txtID.Text + " AND tDate='" + Convert.ToDateTime(lvwListTime.FocusedItem.Text).ToString("yyyy-MM-dd") + "'", msqlcon.con);
                daC.Fill(dtC);
                if (dtC.Rows.Count > 0)
                {
                    btnInput.Visible = false;
                }
                else
                {
                    string strDay = lvwListTime.FocusedItem.SubItems[1].Text;
                    //MessageBox.Show(strDay);
                    if (strDay == "Saturday" || strDay == "Sunday")
                    {
                        btnInput.Visible = false;
                    }
                    else
                    {
                        if (Convert.ToDateTime(lvwListTime.FocusedItem.Text) > DateTime.Now.Date)
                        {
                            btnInput.Visible = false;
                        }
                        else
                        {
                            CheckOpen.cons();
                            DataTable dt = new DataTable();
                            MySqlDataAdapter da = new MySqlDataAdapter("SELECT  TimeIn1, TimeOut1, TimeIn2, TimeOut2 FROM attendance WHERE datein='" + Convert.ToDateTime(lvwListTime.FocusedItem.Text).ToString("yyyy-MM-dd") + "' AND empID=" + txtID.Text, msqlcon.con);
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string t1 = dt.Rows[0][0].ToString();
                                string t2 = dt.Rows[0][1].ToString();
                                string t3 = dt.Rows[0][2].ToString();
                                string t4 = dt.Rows[0][3].ToString();
                                if (t1 == "" || t2 == "" || t3 == "" || t4 == "")
                                {
                                    btnInput.Visible = true;
                                }
                                else
                                {
                                    btnInput.Visible = false;
                                }
                            }
                            else
                            {
                                btnInput.Visible = true;
                            }
                        }


                    }
                }
            }
           
        }
    }
}
