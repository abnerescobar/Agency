using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer: AggregateRoot
{
    public Customer(CustomerId id, string name, string lastName, string email, PhoneNumber phoneNumber, bool active)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Active = active;
    }
    private Customer()
    {

    }

    public CustomerId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; set; }
    public bool Active { get; set; }
    public static Customer UpdateCustomer(Guid id, string name, string lastName, string email, PhoneNumber phoneNumber, bool active)
    {
        return new Customer(new CustomerId(id), name, lastName, email, phoneNumber, active);
    }

}
