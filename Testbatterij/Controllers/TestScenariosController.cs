using System.Net;
using System.Web.Mvc;
using Testbatterij.Models;

namespace Testbatterij.Controllers
{
    public class TestScenariosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TestScenario testScenario = new TestScenario {Id = id.Value};

            return View(testScenario);
        }
    }
}
