using Microsoft.EntityFrameworkCore;

namespace Search;

public class DataContext : DbContext
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FullName { get; set; }

    public string Gander {get; set; }
    public string City {get; set; }

    public DataContext(int id, int age, string userName, string email,
        string phone, string fullName, string gander, string city)

    {
        Id = id;
        Age = age;
        UserName = userName;
        Email = email;
        Phone = phone;
        FullName = fullName;
        Gander = gander;
        City = city;
    }
    
    
}