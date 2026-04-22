using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace ContactManager.Core;

public class Contact //class contact aangemaakt die een naam als parameter neemt.
{
    public int Id { get; set; }
    public string Name { get; private set; } //moet nog altijd public zijn want je moet de naam kunnen  lezen, maar mag private set zijn omdat enkel Contact de naam mag toewijzen, en andere klasses van buitenaf mogen dit niet kunnen
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public Contact(string name, string email = "", string number = "") //contructor, email en number zijn default ""
    {
        Update(name, email, number);
    }

    public void Update(string name, string email = "", string number = "")
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Name cannot be empty");
        }
        Name = name;
        Email = email;
        PhoneNumber = number;
    }
}