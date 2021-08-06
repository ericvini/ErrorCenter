using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCenter.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Error> Erros { get; set; } = new List<Error>();

        public User()
        {

        }

        public User(string name, string email, string password)
        {
            //Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public void AddError(Error err)
        {
            Erros.Add(err);

        }
    }
}
