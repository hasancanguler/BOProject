using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BOApi.Model;
using BOSite;
using Newtonsoft.Json;

namespace BOBuss
{
    public class Complaints
    {
        Company company = new Company();
        public async Task Create(Models.Complaints complaints)
        {
            //Buraya Company araması eklenecek
            CompanyBaseModel companyModel = new CompanyBaseModel();
            companyModel.Name = complaints.CompanyName;
            
            
            companyModel.Id = await company.Create(companyModel);

            Models.Complaints complaintsItem = new Models.Complaints();
            complaintsItem.Name = complaints.Name;
            complaintsItem.Description = complaints.Description;
            complaintsItem.CompanyId = companyModel.Id;
            complaintsItem.Publish = true;
            complaintsItem.CreatedDate = DateTime.Now;

            using (var client = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(complaintsItem);
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:50549/api/Complaints", content);
            }
        }

        public async Task<List<Models.Complaints>> List()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:50549/api/Complaints");
                List<Models.Complaints> complaintsItem = JsonConvert.DeserializeObject<List<Models.Complaints>>(response.Content.ReadAsStringAsync().Result);
                return complaintsItem;
            }
        }
    }
}
