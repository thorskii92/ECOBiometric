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
    public partial class frmEmployeePositions : Form
    {
        //int arrEmpID;
        private frmNewEditPosition _NewEditPos;

        public frmEmployeePositions()
        {
            InitializeComponent();
            _NewEditPos = new frmNewEditPosition(this);
        }
        List<int> arrEmpID = new List<int>();
        int[] arrEmp;
        private void frmEmployeePositions_Load(object sender, EventArgs e)
        {
            loadpositions();
            btnEdit.Visible = false;
        }
        public void loadpositions()
        {
            lvwPositions.Items.Clear();
            //int x = 0;
            //StoreData.arrHoldEmpID[] =;
            arrEmpID.Clear();
            queryClass.PubDT.Clear();
            queryClass.dataquery("SELECT * FROM empposition");
            if (queryClass.PubDT.Rows.Count > 0)
            {
                arrEmp = new int[queryClass.PubDT.Rows.Count - 1];
                int x;
                for (x =0; x <= queryClass.PubDT.Rows.Count - 1; x++) 
                {
                    ListViewItem lst = new ListViewItem();
                    //StoreData.arrHoldEmpID[x] = Convert.ToInt32(queryClass.PubDT.Rows[x][0]);
                    //arrHoldEmpID[x] = 
                    //arrEmp[x] = Convert.ToInt32(queryClass.PubDT.Rows[x][0]);
                    arrEmpID.Add(Convert.ToInt32(queryClass.PubDT.Rows[x][0]));
                    lst.Text = queryClass.PubDT.Rows[x][1].ToString();
                    lst.SubItems.Add(queryClass.PubDT.Rows[x][2].ToString());
                    lst.SubItems.Add(queryClass.PubDT.Rows[x][3].ToString());
                    lst.SubItems.Add(queryClass.PubDT.Rows[x][4].ToString());
                    lst.SubItems.Add(queryClass.PubDT.Rows[x][5].ToString());
                    lst.SubItems.Add(queryClass.PubDT.Rows[x][6].ToString());
                    lvwPositions.Items.Add(lst);
                }
            }
            btnEdit.Visible = false;
        }

        private void lvwPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPositions.SelectedItems.Count > 0)
            {
                btnEdit.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;
            }
        }

        private void btnEmpPos_Click(object sender, EventArgs e)
        {
            //frmNewEditPosition newEdPos = new frmNewEditPosition();
            //newEdPos.StartPosition = FormStartPosition.CenterScreen;
            //newEdPos.Text = "New Position";
            //newEdPos.ShowDialog();
            //loadpositions();
            _NewEditPos.StartPosition = FormStartPosition.CenterScreen;
            _NewEditPos.Text = "New Position";
            _NewEditPos.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPositions.SelectedItems.Count > 0)
            {
                //frmNewEditPosition EdPos = new frmNewEditPosition();
                _NewEditPos.StartPosition = FormStartPosition.CenterScreen;
                _NewEditPos.Text = "Edit Position";
                StoreData.HoldEmpID = arrEmpID[lvwPositions.FocusedItem.Index];
                //StoreData.HoldEmpID = arrEmp[lvwPositions.FocusedItem.Index];
                //MessageBox.Show(StoreData.HoldEmpID.ToString());
                DataTable dtP = new DataTable();
                MySqlDataAdapter daP = new MySqlDataAdapter("SELECT * FROM empposition WHERE PositionID=" + StoreData.HoldEmpID, msqlcon.con);
                daP.Fill(dtP);
                _NewEditPos.txtPos.Text = dtP.Rows[0][1].ToString();
                _NewEditPos.txtBasic.Text = dtP.Rows[0][2].ToString();
                _NewEditPos.txtSSS.Text = dtP.Rows[0][3].ToString();
                _NewEditPos.txtPagibig.Text = dtP.Rows[0][4].ToString();
                _NewEditPos.txtPhilHealth.Text = dtP.Rows[0][5].ToString();
                _NewEditPos.txtDailyRate.Text = dtP.Rows[0][6].ToString();
                _NewEditPos.ShowDialog();
                //loadpositions();
            }
        }
    }
}
