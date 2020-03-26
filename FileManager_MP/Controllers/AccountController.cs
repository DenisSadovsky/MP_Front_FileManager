using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManager_MP.Models;
using System.Data.Entity;

namespace FileManager_MP.Controllers
{
    public class AccountController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        //SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdminActions()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangeRole()
        {
            return View();
        }

        void ConnectionString()
        {
            //con.ConnectionString = @"data source=EPBYMINW0728; database=FileManager; Trusted_Connection=True
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FileManager_MPDate.mdf;Integrated Security=True";
        }

        [HttpPost]
        public ActionResult Login(Account acc)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select IdRole from Tbl_Accounts where UserName='" + acc.Name + "' and Password='" +
                              acc.Password + "'";
            var userRole = com.ExecuteScalar();
            if (userRole != null)
            {
                if (userRole.ToString() == "1")
                {
                    acc.Role = "Admin";
                    con.Close();
                    return View("AdminActions");
                }
                acc.Role = "User";
                con.Close();
                return View("User");
            }

            con.Close();
            acc.Message = "Invalid username or password";
            return View(acc);
        }

        [HttpPost]
        public ActionResult AdminActions(FileDirectory fileDirectory, string open, string createFile,string createDirectory ,string delete)
        {
            if (open != null)
            {
                fileDirectory.GetDirectoryFiles();
            }else if (createFile != null)
            {
                fileDirectory.CreateFile();
            }else if (createDirectory != null)
            {
                fileDirectory.CreateDirectory();
            }else if (delete != null)
            {
                fileDirectory.DeleteFile();
            }

            return View(fileDirectory);
        }

        [HttpPost]
        public ActionResult User(FileDirectory fileDirectory)
        {
            fileDirectory.GetDirectoryFiles();
            return View(fileDirectory);
        }

        [HttpPost]
        public ActionResult ChangeRole(Account acc)
        {
            var idRole = acc.ChangeRole();
            if (idRole == 0)
            {
                return View(acc);
            }

            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "UPDATE Tbl_Accounts set IdRole="+ idRole + " where UserName='" + acc.Name+"'";
            int a = com.ExecuteNonQuery();
            acc.Message = a == 0 ? "Something wrong with User Name" : "User Role changed";

            return View(acc);
        }
    }

   
}
