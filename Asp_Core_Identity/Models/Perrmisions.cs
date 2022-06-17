using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp_Core_Identity.Models
{
    public  class Perrmisions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public bool IsCkeck { get; set; }
    }
}
