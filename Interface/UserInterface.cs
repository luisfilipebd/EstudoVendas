using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoVendas.Interface
{
    internal class UserInterface
    {
        public interface IUser
        {
            int Id { get; }
            int FkUserProfile { get; set; }
            string Name { get; set; }
            string User { get; set; }
            string Password { get; set; }
            bool Inactive { get; set; }
        }
    }
}
