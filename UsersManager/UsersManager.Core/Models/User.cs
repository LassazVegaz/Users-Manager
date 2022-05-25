﻿namespace UsersManager.Core.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public float Estimate { get; set; }
        public string Name { get; set; } = null!;
    }
}
