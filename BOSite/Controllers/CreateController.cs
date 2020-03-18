using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BOSite.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Index(BOBuss.ComplaintsModel complaint)
        {
            BOBuss.Complaints complaintsBuss = new BOBuss.Complaints();
            await complaintsBuss.Create(complaint);
            return View();
        }

      
    }
}