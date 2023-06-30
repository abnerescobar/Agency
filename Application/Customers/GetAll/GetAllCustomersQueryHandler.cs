using Customers.Common;
using Domain.Customers;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll;


internal sealed class GetAllPackagesQueryHandler : IRequestHandler<GetAllPackagesQuery, ErrorOr<IReadOnlyList<CustomerResponse>>>
{
    private readonly IcustomerRepository _customerRepository;

    public GetAllPackagesQueryHandler(IcustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<CustomerResponse>>> Handle(GetAllPackagesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Customer> customers = await _customerRepository.GetAll();

        return customers.Select(customer => new CustomerResponse(
                customer.Id.Value,
                customer.FullName,
                customer.Email,
                customer.PhoneNumber.Value,
                customer.Active
            )).ToList();
    }
}