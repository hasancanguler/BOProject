using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOApi.Model;
using BODB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        Response response = new Response();
        // GET: api/Complaints
        [HttpGet]
        public IEnumerable<Complaints> Get()
        {
            using (BODBcontext context = new BODBcontext())
            {
                return context.Complaints.Where(w=>w.Publish == true).OrderByDescending(o => o.CreatedDate).ToList();
            } 
        }

        // POST: api/Complaints
        [HttpPost]
        public Response Post([FromBody] Complaints complaints)
        {
            try
            {
                using (BODBcontext context = new BODBcontext())
                {
                    context.Complaints.Add(complaints);
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Kayıt Eklendi";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message.ToString();
            }
            return response;
        }
        
    }
}
