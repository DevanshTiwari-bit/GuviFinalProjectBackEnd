using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gadgets.Models;

namespace Gadgets.Controllers
{
    public class CategoryController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select CategoryID,CategoryName from Category";
            DataTable table = new DataTable();
            using (var con=new MySqlConnection(ConfigurationManager.
                ConnectionStrings["GadgetsAppDB"].ConnectionString))
            using (var cmd=new MySqlCommand(query,con))
            using (var da=new MySqlDataAdapter(cmd))
            {
                cmd.CommandType=CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        /*public string Post(Category cat)
        {
            try
            {
                string query = @"insert into Category values('"+cat.CategoryName+@"')";

                DataTable table = new DataTable();
                using (var con = new MySqlConnection(ConfigurationManager.
                    ConnectionStrings["GadgetsAppDB"].ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";

            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }
        public string Put(Category cat)
        {
            try
            {
                string query = @"update dbo.Category set CategoryName='" + cat.CategoryName + @"' where CategoryID="+cat.CategoryID+@"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["GadgetsAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully";

            }
            catch (Exception)
            {
                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Category where CategoryID=" + id + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["GadgetsAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";

            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }*/
    }
}
