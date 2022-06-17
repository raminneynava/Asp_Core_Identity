using System.ComponentModel;

namespace Asp_Core_Identity.Models
{
    public static class Perrmisions
    {

        [DisplayName("حذف")]
        public static string AdminDelete { get; } = "Admin";
    }
}
