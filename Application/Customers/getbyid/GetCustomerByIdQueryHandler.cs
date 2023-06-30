using Customers.Common;
using Domain.Customers;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetById;


internal sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ErrorOr<CustomerResponse>>
{
    private readonly IcustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(IcustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<ErrorOr<CustomerResponse>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetByIdAsync(new CustomerId(query.Id)) is not Customer customer)
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        return new CustomerResponse(
            customer.Id.Value,
            customer.FullName,
            customer.Email,
            customer.PhoneNumber.Value,
            customer.Active);
    }
}