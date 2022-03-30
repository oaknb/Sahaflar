using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sahaflar.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
