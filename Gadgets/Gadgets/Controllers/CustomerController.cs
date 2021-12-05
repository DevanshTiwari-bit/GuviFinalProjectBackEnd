using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gadgets.Controllers
{
    public class CustomerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select CustomerID,CustomerName from Customer";
            DataTable table = new DataTable();
            using (var con = new MySqlConnection(ConfigurationManager.
                ConnectionStrings["GadgetsAppDB"].ConnectionString))
            using (var cmd = new MySqlCommand(query, con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
