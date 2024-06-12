using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Core.Entities
{
    public class User : BaseEntity
    {
        private string passwordHash;

        public User(string fullName, string email, DateTime birthDate, string password, string role, string tenantId)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
            Active = true;
            Password = password;
            Role = role;
            TenantId = tenantId;
        }




        public string FullName { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public bool Active { get; set; }

        public string Password { get; private set; }

        public string Role { get; private set; }

        public string TenantId { get; private set; }
    }
}
