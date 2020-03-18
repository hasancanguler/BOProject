using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BODB
{
    public class Complaints
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string  Description { get; set; }
        public bool Publish { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
