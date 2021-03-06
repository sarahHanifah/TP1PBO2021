using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1PBO2021.Properties
{
    class Login
    {
    }
}

class Login
{
    public string username { get; set; }
    public string password { get; set; }

    public Login()
    {

    }

    public Login(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public int Validation()
    {
        if(password == "pbo123")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
