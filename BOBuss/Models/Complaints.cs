using System;

namespace BOBuss
{
    public class ComplaintsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string  Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class ComplaintsBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public bool Publish { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
