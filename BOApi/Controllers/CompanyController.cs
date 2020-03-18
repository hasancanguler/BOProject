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
    public class CompanyController : ControllerBase
    {
        CreateResponse response = new CreateResponse();

        [HttpGet("{id}", Name = "Get")]
        public Company Get(int id)
        {
            using (BODBcontext context = new BODBcontext())
            {
                return context.Company.Where(w => w.Id == id).FirstOrDefault();
            }
        }

        [HttpPost]
        public Response Post([FromBody] Company company)
        {
            try
            {
                using (BODBcontext context = new BODBcontext())
                {
                    context.Company.Add(company);
                    context.SaveChanges();
                }
                response.Id = company.Id;
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