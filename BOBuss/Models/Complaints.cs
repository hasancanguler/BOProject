using System;
using System.Web.Mvc;

namespace BOBuss.Models
{
    public class Complaints
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        [AllowHtml]
        public string  Description { get; set; }
        public int CompanyId { get; set; }
        public bool Publish { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }

}
