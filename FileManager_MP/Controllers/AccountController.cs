using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManager_MP.Models;

namespace FileManager_MP.Controllers
{
    public class AccountController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = @"data source=EPBYMINW0728; database=FileManager; Trusted_Connection=True;";

        }

        [HttpPost]
        public ActionResult Login(Account acc)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select IdRole from tbl_Accounts where UserName='" + acc.Name + "' and Password='" +
                              acc.Password + "'";
            //dr = com.ExecuteReader();
            var userRole = com.ExecuteScalar();
            if (userRole != null)
            {
                if (userRole.ToString() == "1")
                {
                    //Admin
                    con.Close();
                    return View("Create");
                }

                con.Close();
                return View("Create");
                //vonychka

            }

            con.Close();
            return View("Error");
        }

        [HttpPost]
        public ActionResult Create(FileDirectory acc)
        {
            acc.GetDirectoryFiles(acc.Path);
            return View(acc);
        }

        [HttpPost]
        public void Create(string acc)
        {
            var d = new FileDirectory();
            d.CreateDirectory(acc);
            //return View(acc);
        }

    }

   
}
