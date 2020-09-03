using NUnit.Framework;
using UpCloudLogic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace UpCloudLogic_Tests
{
    public class Tests
    {   //register and login tests
        CRUDManager _crud = new CRUDManager ;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}