using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_REACT_CRUD_Project.Models
{
    public class Race
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Location { get; set; }
    }
}
