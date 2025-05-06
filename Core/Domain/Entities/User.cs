using Domain.Exceptions;

namespace Domain.Entities;

public sealed class User
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public string? Phone { get; private set; }


    public User(Guid id, string name, string email, string? phone = null)
    {
        Id = id;
        Validate(name, email);
        Name = name;
        Email = email;
        Phone = phone;
    }

    public void AddUser(string name, string email, string? phone = null)
    {
        Id = Guid.NewGuid();
        Validate(name, email, phone);
        Name = name;
        Email = email;
        Phone = phone;
    }

    private static void Validate(string name, string email, string? phone = null)
    {
        if (name is null || (name.Length < 3))
            throw new UserException("Invalid Name");

        if (email is null || !email.Contains("@"))
            throw new UserException("Invalid Email");

        if (phone is not null && phone.Length < 10)
            throw new UserException("Invalid Phone Number");
    }
}
