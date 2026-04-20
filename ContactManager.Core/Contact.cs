using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace ContactManager.Core;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    //public string Email { get; set; }
    //public string PhoneNumber { get; set; }
    //public Contact(string name, string email, string number) //contructor
    // : this(name)
    // {
    //     Email = email;
    //     PhoneNumber = number;
    // }
    public Contact(string name)
    {
        if (name == "")
        {
            throw new Exception("Name cannot be empty");
        }
        Name = name;
    }

}