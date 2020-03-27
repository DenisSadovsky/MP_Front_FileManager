using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager_MP.Controllers;
using System.Web.Mvc;
using FileManager_MP.Services;
using Moq;

namespace FileManager_MP.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {


        [TestMethod]
        public void LoginViewResultNotNull()
        {
            // Arrange
            AccountController controller = new AccountController();
            // Act
            ViewResult result = controller.Login() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoginViewNameEqualIndex()
        {
            // Arrange
            AccountController controller = new AccountController();
            // Act
            ViewResult result = controller.Login() as ViewResult;
            // Assert
            Assert.AreEqual("Login", result?.ViewName);

        }
        [TestMethod]
        public void UsersGetFileDirectory()
        {
            var fdMock = new Mock<FileDirectoryServiceProvider>(); 
            //var accountMock = new Mock<IAccountServiceProvider>();
            //var accountController = new AccountController(accountMock.Object, fdMock.Object);
            var message = fdMock.Object.GetDirectoryFiles(GetTestPath(), out _, out _);
            Assert.IsNull(message);
        }
        private string GetTestPath()
        {
            return "C:\\";
        }

        //[TestMethod]
        //public void AdminActionCreateDirectory()
        //{
        //    var filePath = "C:\\123";
        //    var fdMock = new Mock<FileDirectoryServiceProvider>();
        //    //var accountMock = new Mock<IAccountServiceProvider>();
        //    //var accountController = new AccountController(accountMock.Object, fdMock.Object);
        //    var message = fdMock.Object.CreateDirectory(filePath);
        //    Assert.IsNull(message);

        //}

        //[TestMethod]
        //public void AdminActionCreateFile()
        //{
        //    var filePath = "C:\\123.test.txt";
        //    var fdMock = new Mock<FileDirectoryServiceProvider>();
        //    //var accountMock = new Mock<IAccountServiceProvider>();
        //    //var accountController = new AccountController(accountMock.Object, fdMock.Object);
        //    var message = fdMock.Object.CreateFile(filePath);
        //    Assert.IsNull(message);

        //}
        //[TestMethod]
        //public void AdminActionDeleteFile()
        //{
        //    var filePath = "C:\\123.test.txt";
        //    var fdMock = new Mock<FileDirectoryServiceProvider>();
        //    //var accountMock = new Mock<IAccountServiceProvider>();
        //    //var accountController = new AccountController(accountMock.Object, fdMock.Object);
        //    var message = fdMock.Object.DeleteFile(filePath);
        //    Assert.IsNull(message);

        //}
        
    }
}