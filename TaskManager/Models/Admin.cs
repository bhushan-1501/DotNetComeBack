using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Admin : User
    {
        public string Department {  get; set; }
        public string Role {  get; set; }
        public Admin(int id,string name,string dept,string role) : base(id,name)
        {
            Department = dept;
            Role = role;
        }
    }
}
