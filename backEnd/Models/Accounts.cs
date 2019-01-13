using System;

namespace backEnd.Models
{
    public partial class Accounts
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
