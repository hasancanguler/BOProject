using BOApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BOBuss
{
    public class Company
    {
        //public async Task<List<Company>> GetCompanyByName(string name)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var response = await client.GetAsync("http://localhost:50549/api/Complaints");
        //        List<Complaints> model = JsonConvert.DeserializeObject<List<Complaints>>(response.Content.ReadAsStringAsync().Result);

        //    }
        //}

        public async Task<int> Create(CompanyBaseModel company)
        {
            using (var client = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(company);
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:50549/api/Company", content);

                CreateResponse createResponse = JsonConvert.DeserializeObject<CreateResponse>(response.Content.ReadAsStringAsync().Result);
                return createResponse.Id;
            }
        }

        public async Task<Company> GetCompanyById(int Id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:50549/api/Company");
                Company model = JsonConvert.DeserializeObject<Company>(response.Content.ReadAsStringAsync().Result);
                return model;
            }
        }
    }
}
