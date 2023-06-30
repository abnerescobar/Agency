using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Domain.Customers;
using System.Collections.Generic;
using Domain.ValueObjects;
using Domain.Primitives;

namespace Application.Customers.Queries.Handlers
{
    internal sealed class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ErrorOr<List<CustomerDto>>>
    {
        private readonly IcustomerRepository _customerRepository;
    
        public GetCustomerQueryHandler(IcustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            
        }

        public async Task<ErrorOr<List<CustomerDto>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAll();
            var customerDtos = new List<CustomerDto>();

            foreach (var customer in customers)
            {
              

                var customerDto = new CustomerDto
                {
                    CustomerId = customer.Id.Value,
                    Name = customer.Name,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Active = customer.Active
                };

                customerDtos.Add(customerDto);
            }

            return customerDtos;
        }
    }
}
