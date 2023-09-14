using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tugas1.Auth
{

    public class Employees
    {

     
       public Employees() { }
        public Employees(String firstName, String lastName, String password, String username) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Username = username;
          
        }


   
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public String Password { set; get; }
        public String Username { set; get; }

     
        public  String toString()
        {
            
            return "Nama : "+FirstName+" "+LastName+"\nUsername : "+Username+"\nPassword : "+Password;
            
        }


    }
}
