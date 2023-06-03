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
    public partial class frmHolidaySettings : Form
    {
        private frmAddEdHoliday _EdNewHoliday;
        private List<int> arrHolID;
        public frmHolidaySettings()
        {
            InitializeComponent();
            //loadholiday();
            _EdNewHoliday = new frmAddEdHoliday(this);
            
        }

        private void frmHolidaySettings_Load(object sender, EventArgs e)
        {
            loadholidaylist();
        }

        public void loadholidaylist()
        {
            //MessageBox.Show("");
            CheckOpen.cons();
            
            //dtH.Clear();
            lvwHoliday.Items.Clear();

            MySqlDataAdapter daH = new MySqlDataAdapter("SELECT * FROM holidays", msqlcon.con);
            DataTable dtH = new DataTable();
            daH.Fill(dtH);
            //MessageBox.Show(dtH.Rows.Count.ToString());
            if (dtH.Rows.Count > 0)
            {
                arrHolID = new List<int>();
                arrHolID.Clear();
                for (int x = 0; x <= dtH.Rows.Count - 1; x++)
                {
                    //MessageBox.Show("");
                    ListViewItem lst = new ListViewItem();
                    arrHolID.Add((int)dtH.Rows[x][0]);
                    lst.Text = dtH.Rows[x][1].ToString();
                    //MessageBox.Show(dtH.Rows[x][1].ToString());
                    lst.SubItems.Add(dtH.Rows[x][2].ToString());
                    lst.SubItems.Add(Convert.ToDateTime(dtH.Rows[x][3]).ToString("MMMM dd, yyyy"));
                    lvwHoliday.Items.Add(lst);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _EdNewHoliday.Text = "New Holiday";
            _EdNewHoliday.StartPosition = FormStartPosition.CenterScreen;
            _EdNewHoliday.txtHoliday.Text = "";
            _EdNewHoliday.cboType.SelectedIndex = 0;
            _EdNewHoliday.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lvwHoliday.SelectedItems.Count > 0)
            {
                CheckOpen.cons();
                StoreData.selectedHolID = arrHolID[lvwHoliday.FocusedItem.Index];
                DataTable dtH = new DataTable();
                MySqlDataAdapter daH = new MySqlDataAdapter("SELECT * FROM holidays WHERE holidayID=" + StoreData.selectedHolID, msqlcon.con);
                daH.Fill(dtH);
                _EdNewHoliday.Text = "Modify Holiday";
                _EdNewHoliday.txtHoliday.Text = dtH.Rows[0][1].ToString();
                _EdNewHoliday.cboType.Text = dtH.Rows[0][2].ToString();
                _EdNewHoliday.dtpDate.Value = Convert.ToDateTime(dtH.Rows[0][3]);
                _EdNewHoliday.StartPosition = FormStartPosition.CenterScreen;
                _EdNewHoliday.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwHoliday.SelectedItems.Count > 0)
            {
               
                if (MessageBox.Show("Delete Holiday?","Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CheckOpen.cons();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM holidays WHERE holidayID=" + arrHolID[lvwHoliday.FocusedItem.Index], msqlcon.con);
                    cmd.ExecuteNonQuery();
                    loadholidaylist();
                }
            }
        }
    }
}
