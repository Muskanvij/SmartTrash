using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nowui.Controllers
{
    [Authorize]
    public class RoutesController : Controller
    {
        public String a = " ";

        [BindProperty]

        public DataTable bindata { get; set; }

        [BindProperty]

        public string council { 
            
            get; set; }
        public void Onget()
        {

        }
        public IActionResult OnPost()

        {
            Console.WriteLine("Action",council );
            if (council != null)
            {
                getRouteData(council);
            }

            return View();
        }

        public string owner = "";
        public string embed = "";

        String waypoints = "";

        public void getRouteData(String owner)
        {
            Console.WriteLine("getting data");
            
            SqlConnection sqlc = new SqlConnection("Server=smartcitysqlservero.database.windows.net;Database=SmartCityTeamO;User ID=teamo;Password=Cti30862020;MultipleActiveResultSets=true");

            string query = "select t.tag_number, t.data_date, t.data_val, t.lat, t.lng, t.owner from[BinData] t inner join(select tag_number, max(data_date) as MaxDate from[BinData] group by tag_number, owner) tm on t.tag_number = tm.tag_number and t.data_val/1250>0.7 and  t.data_date = tm.MaxDate and t.owner = "+owner;


            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = new SqlCommand(@query ,sqlc);
            DataTable DataTable = new DataTable();
            String initialPosition = "";
            String finalPosition = "";
            adaptor.Fill(DataTable);

            if (owner == "banyule")
            {
                initialPosition = "-37.704335,145.105047";
                finalPosition = "-37.704335,145.105047";

            }
            else if (owner == "mitchell")
            {
                initialPosition = "-37.704335,145.105047";
                finalPosition = "-37.704335,145.105047";
            }
            else if (owner == "nillumbik")
            {
                initialPosition = "-37.704335,145.105047";
                finalPosition = "-37.704335,145.105047";
            }
            else if (owner == "whittlesea")
            {
                initialPosition = "-37.704335,145.105047";
                finalPosition = "-37.704335,145.105047";
            }
            else if (owner == "moreland")
            {
                initialPosition = "-37.704335,145.105047";
                finalPosition = "-37.704335,145.105047";
            }



            foreach (DataRow row in DataTable.Rows)
            {
                Console.WriteLine("Data row :",row);
                    
                waypoints = waypoints + row.ItemArray[3] + "," + row.ItemArray[4] + "|";
            }
            int len = waypoints.Length;

            Console.WriteLine("Data len :", len);

            waypoints = waypoints.Substring(0, len - 1);



            embed = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyCZqrhxH1Ypwt0wRAcG631TmlBDxE7XgcM" +
            "&origin=" + initialPosition +
            "&destination=" + finalPosition +
            "&waypoints =" + waypoints;



            bindata = DataTable;
            ViewData["a"] = embed;
            
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}

