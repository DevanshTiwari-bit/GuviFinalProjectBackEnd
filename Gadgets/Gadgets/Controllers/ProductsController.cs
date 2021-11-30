using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gadgets.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;

namespace Gadgets.Controllers
{
    public class ProductsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select ProductID,ProductName,Category,ProductDescription,PhotoFileName from Products";
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
        /*public string Post(Products pro)
        {
            try
            {
                string query = @"insert into dbo.Products values
                (
                '" + pro.ProductName + @"',
                '" + pro.Category + @"',
                '" + pro.ProductDescription + @"',
                '" + pro.PhotoFileName + @"'
                )";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["GadgetsAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
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
        public string Put(Products pro)
        {
            try
            {
                string query = @"update dbo.Products set 
                ProductName='" + pro.ProductName + @"',
                Category='" + pro.Category + @"',
                ProductDescription='" + pro.ProductDescription + @"',
                PhotoFileName='" + pro.PhotoFileName + @"'

                where ProductID=" + pro.ProductID + @"";

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
                string query = @"delete from dbo.Products where ProductID=" + id + @"";

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
        }
        [Route("api/Products/GetAllCategoryName")]
        [HttpGet]
        public HttpResponseMessage GetAllCategoryName()
        {
            string query = @"select CategoryName from dbo.Category";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["GadgetsAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        [Route("api/Products/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest=HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename=postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos" + filename);

                postedFile.SaveAs(physicalPath);
                return filename;
            }
            catch(Exception)
            {
                return "anonymous.png";
            }
        }*/
    }
}
