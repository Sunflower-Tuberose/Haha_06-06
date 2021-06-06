using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightManagement.Model;


namespace FlightManagement.Controller
{
    public class ThamSoController
    {
        private static ThamSoController instance;
        public int Min_Fly_Time;
        public int Num_Tran_Airpot;
        public int Min_Wait_Time;
        public int Max_Wait_Time;
        public int Latest_Time_Book;
        public int Latest_Time_Cancel;


        internal static ThamSoController Instance
        {
            get
            {
                if (instance == null) instance = new ThamSoController(); return ThamSoController.instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ThamSoController()
        {

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM THAMSO");
            foreach (DataRow item in data.Rows)
            {
               
                ThamSo ThamSo = new ThamSo(item);
                if (ThamSo.TenThamSo == "ThoiGianBayToiThieu")
                {
                    this.Min_Fly_Time = ThamSo.GiaTri;
                }
                if (ThamSo.TenThamSo == "SoSanBayTrungGianToiDa")
                {
                    this.Num_Tran_Airpot = ThamSo.GiaTri;
                }
                if (ThamSo.TenThamSo == "ThoiGianDungToiThieu")
                {
                    this.Min_Wait_Time = ThamSo.GiaTri;
                }
                if (ThamSo.TenThamSo == "ThoiGianDungToiDa")
                {
                    this.Max_Wait_Time = ThamSo.GiaTri;
                }
                if (ThamSo.TenThamSo == "ThoiGianChamNhatDatVe")
                {
                    this.Latest_Time_Book = ThamSo.GiaTri;
                }
                if (ThamSo.TenThamSo == "ThoiGianChamNhatHuyDatVe")
                {
                    this.Latest_Time_Cancel = ThamSo.GiaTri;
                }

            }
        }

        public void UpdateThamSo(int Min_Fly_Time, int Num_Tran_Airpot, int Min_Wait_Time, int Max_Wait_Time, int Latest_Time_Book, int Latest_Time_Cancel)
        {
            string query = "EXEC SETTING_UPDATE "
                            + " @min_fly_time = "
                            + Min_Fly_Time
                            + " , @num_tran_airpot = "
                            + Num_Tran_Airpot
                            + " , @min_wait_time ="
                            + Min_Wait_Time
                            + " , @max_wait_time ="
                            + Max_Wait_Time
                            + " , @latest_time_book ="
                            + Latest_Time_Book
                            + " , @latest_time_cancel ="
                            + Latest_Time_Cancel;

            DataProvider.Instance.ExecuteNonQuery(query);            
        }


        public bool checkTGBay(int FlyTime)
        {
            if (FlyTime < this.Min_Fly_Time)
            {
                return false;

            }
            return true;


        }

        public bool checkSoSanBayTrungGian(int soSBTG)
        {
            if (soSBTG > this.Num_Tran_Airpot)
            {
                return false;
            }
            return true;
        }

        public bool checkTGcho (int max, int min)
        {
            if (max == -1 )
            {
                return false;
            }   
           else  if (max > this.Max_Wait_Time || min < this.Min_Wait_Time)
            {
                return true;
            }
                return false;
        }


    }
}
