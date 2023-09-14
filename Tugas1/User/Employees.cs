using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tugas1.User
{

    public class Employees
    {


        public Employees() { }
        public Employees(string firstName, string lastName, string password, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Username = username;

        }



        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Password { set; get; }
        public string Username { set; get; }


        public string toString()
        {

            return "Nama : " + FirstName + " " + LastName + "\nUsername : " + Username + "\nPassword : " + Password;

        }


    }
}
