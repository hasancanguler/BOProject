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
        public async Task Create(ComplaintsModel complaints)
        {
            //Buraya Company araması eklenecek
            CompanyBaseModel companyModel = new CompanyBaseModel();
            companyModel.Name = complaints.CompanyName;
            
            
            companyModel.Id = await company.Create(companyModel);

            ComplaintsBaseModel complaintsBaseModel = new ComplaintsBaseModel();
            complaintsBaseModel.Name = complaints.Name;
            complaintsBaseModel.Description = complaints.Description;
            complaintsBaseModel.CompanyId = companyModel.Id;
            complaintsBaseModel.Publish = true;
            complaintsBaseModel.CreatedDate = DateTime.Now;

            using (var client = new HttpClient())
            {
                var data = JsonConvert.SerializeObject(complaintsBaseModel);
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:50549/api/Complaints", content);
            }
        }

        public async Task<List<BODB.Complaints>> List()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:50549/api/Complaints");
                List<BODB.Complaints> complaintmodel = JsonConvert.DeserializeObject<List<BODB.Complaints>>(response.Content.ReadAsStringAsync().Result);
                return complaintmodel;
            }
        }
    }
}
