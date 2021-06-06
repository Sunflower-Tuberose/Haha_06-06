
using FlightManagement.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightManagement
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void btnClose_Setting_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       private void LoadThamSo()
        {            
            txtTG_BayToiThieu.Text = ThamSoController.Instance.Min_Fly_Time.ToString();
            txtSBTGTD.Text = ThamSoController.Instance.Num_Tran_Airpot.ToString();
            txtTG_DungToiThieu.Text = ThamSoController.Instance.Min_Wait_Time.ToString();
            txtTG_DungToiDa.Text = ThamSoController.Instance.Max_Wait_Time.ToString();
            txtTG_ChamNhatDatVe.Text = ThamSoController.Instance.Latest_Time_Book.ToString();
            txtTG_ChamNhatHuyDatVe.Text = ThamSoController.Instance.Latest_Time_Cancel.ToString();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            LoadThamSo();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            int Min_Fly_Time = Convert.ToInt32(txtTG_BayToiThieu.Text);
            int Num_Tran_Airpot = Convert.ToInt32(txtSBTGTD.Text);
            int Min_Wait_Time = Convert.ToInt32( txtTG_DungToiThieu.Text);
            int Max_Wait_Time = Convert.ToInt32(txtTG_DungToiDa.Text);
            int Latest_Time_Book = Convert.ToInt32( txtTG_ChamNhatDatVe.Text);
            int Latest_Time_Cancel = Convert.ToInt32(txtTG_ChamNhatHuyDatVe.Text);

            ThamSoController.Instance.UpdateThamSo(Min_Fly_Time, Num_Tran_Airpot, Min_Wait_Time, Max_Wait_Time, Latest_Time_Book, Latest_Time_Cancel);           
            MessageBox.Show("Cập nhật thành công");           
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
