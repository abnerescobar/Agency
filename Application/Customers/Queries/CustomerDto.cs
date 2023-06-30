using Domain.Customers;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries;

public record CustomerDto
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public bool Active { get; set; }

}
