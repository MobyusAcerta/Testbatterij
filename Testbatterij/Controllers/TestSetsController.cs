using System.Net;
using System.Web.Mvc;
using Testbatterij.Models;

namespace Testbatterij.Controllers
{
    public class TestSetsController : Controller
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

            TestSet testSet = new TestSet() {Id = id.Value};

            return View(testSet);
        }
    }
}
