using System;
using System.Collections.Generic;

namespace UsersManager.DAL.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public float Estimate { get; set; }
    }
}
