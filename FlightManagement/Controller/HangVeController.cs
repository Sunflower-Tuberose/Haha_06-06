using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FlightManagement.Model;
using FlightManagement.Controller;

namespace FlightManagement.Controller
{   
      public  class HangVeController
    { private static HangVeController instance;

        internal static HangVeController Instance 
        {
            get { if (instance == null) instance = new HangVeController(); return HangVeController.instance; }
            set { HangVeController.instance = value; }
        }
        public List<HangVe> Load_HangVe()
        {
            DataTable Data = new DataTable();
            List<HangVe> HangVeList = new List<HangVe>();
            Data = DataProvider.Instance.ExecuteQuery("SELECT * FROM HANGVE");
            foreach(DataRow row in Data.Rows)
            {
                HangVe HangVe = new HangVe(row);
                HangVeList.Add(HangVe);
            }
            return HangVeList;
        }
        public void Save_DaTa(List<HangVe> ListHangVe,string MaChuyenBay)
        { 
            foreach(HangVe item in ListHangVe)
            {
                if(item.ChonHangVe == true)
                {
                    string Query = "EXEC INSERT_CHITIETHANGVE N'" + MaChuyenBay + "', N'" + item.MaHangVe+"'," + item.SoLuongVe;
                    DataProvider.Instance.ExecuteQuery(Query);
                }
            }
        }

    }
}
