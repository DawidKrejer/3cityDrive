using System.ComponentModel.DataAnnotations;

namespace ASP_NET_REACT_CRUD_Project.Models
{
    public class Driver
    {
        [Key]
        public int id { get; set; }

        public string drivername { get; set; }

        public string team { get; set; }
    }
}
