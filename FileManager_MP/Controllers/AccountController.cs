using System.Data.SqlClient;
using System.Web.Mvc;
using FileManager_MP.Models;
using FileManager_MP.Services;
using LocalRes = FileManager_MP.App_Resources.LocalResources;

namespace FileManager_MP.Controllers
{
    public class AccountController : Controller
    {
        private IFileDirectoryServiceProvider _fileDirectoryServiceProvider;
        private IAccountServiceProvider _accountServiceProvider;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        //SqlDataReader dr;
        public AccountController() { }

        public AccountController(IAccountServiceProvider accountServiceProvider, IFileDirectoryServiceProvider fileDirectoryServiceProvider)
        {
            _accountServiceProvider = accountServiceProvider;
            _fileDirectoryServiceProvider = fileDirectoryServiceProvider;
        }

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
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
            acc.Message = LocalRes.InvalidUserNameOrPassword;
            return View(acc);
        }

        [HttpPost]
        public ActionResult AdminActions(FileDirectory fileDirectory, string open, string createFile,string createDirectory ,string delete)
        {
            
            if (open != null)
            {
                fileDirectory.Message = _fileDirectoryServiceProvider.GetDirectoryFiles(fileDirectory.Path,out var directories, out var files);
                if (fileDirectory.Message == null)
                {
                    fileDirectory.Files = files;
                    fileDirectory.Directories = directories;
                }

            }else if (createFile != null)
            {
                fileDirectory.Message  = _fileDirectoryServiceProvider.CreateFile(fileDirectory.Path);
            }else if (createDirectory != null)
            {
                fileDirectory.Message = _fileDirectoryServiceProvider.CreateDirectory(fileDirectory.Path);
            }else if (delete != null)
            {
               fileDirectory.Message = _fileDirectoryServiceProvider.DeleteFile(fileDirectory.Path);
            }

            return View(fileDirectory);
        }

        [HttpPost]
        public ActionResult User(FileDirectory fileDirectory)
        {
            fileDirectory.Message = _fileDirectoryServiceProvider.GetDirectoryFiles(fileDirectory.Path, out var directories, out var files);
            if (fileDirectory.Message == null)
            {
                fileDirectory.Files = files;
                fileDirectory.Directories = directories;
            }
            return View(fileDirectory);
        }

        [HttpPost]
        public ActionResult ChangeRole(Account acc)
        {
            var idRole = _accountServiceProvider.ChangeRole(acc.Role);
            if (idRole == 0)
            {
                acc.Message = "Wrong Role";
                return View(acc);
            }

            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "UPDATE Tbl_Accounts set IdRole="+ idRole + " where UserName='" + acc.Name+"'";
            var a = com.ExecuteNonQuery();
            acc.Message = a == 0 ? LocalRes.WrongUserName : LocalRes.UserNameChanged;

            return View(acc);
        }
    }

   
}
