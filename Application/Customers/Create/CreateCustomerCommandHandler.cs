using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Guid>>
    {
        private readonly IcustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IcustomerRepository customerRepository, IUnitOfWork unitOfWork = null)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
                {
                    return Error.Validation("Customer.PhoneNumber", "Phone number has not valid format.");
                }
                var customer = new Customer(new CustomerId(Guid.NewGuid()),
                    command.Name,
                    command.LastName,
                    command.Email,
                    phoneNumber,
                    true);
                 _customerRepository.Add(customer);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return customer.Id.Value;
            }
            catch (Exception ex)
            {
                return Error.Failure("Create.Failure", ex.Message);
            }
        }
    }
}
