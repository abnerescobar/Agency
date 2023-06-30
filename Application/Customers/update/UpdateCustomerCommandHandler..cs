using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Update;

internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<Unit>>
{
    private readonly IcustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCustomerCommandHandler(IcustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (!await _customerRepository.ExistsAsync(new CustomerId(command.Id)))
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            return Error.Validation("Customer.PhoneNumber", "Phone number has not valid format.");
        }


        Customer customer = Customer.UpdateCustomer(command.Id, command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            command.Active);

        _customerRepository.Update(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
