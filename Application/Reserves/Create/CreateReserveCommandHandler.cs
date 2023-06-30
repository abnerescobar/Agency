using Application.Reserves.Common;
using Domain.Customers;
using Domain.Packages;
using Domain.Primitives;
using Domain.Reservation;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reserves.Create;

public sealed class CreateReserveCommandHandler : IRequestHandler<CreateReserveCommand, ErrorOr<ReserveResponse>>
{
    private readonly IcustomerRepository _customerRepository;
    private readonly IReserveRepository _reserveRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateReserveCommandHandler(IcustomerRepository customerRepository, IReserveRepository reserveRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _reserveRepository = reserveRepository;
        _unitOfWork = unitOfWork;
    }

    
    public async Task<ErrorOr<ReserveResponse>> Handle(CreateReserveCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(new CustomerId(request.CustomerId));
        if (customer is null)
        {
            return Error.NotFound("Customer.NotFound",$"Customer with the Id {request.CustomerId} no exists");
        }
        var Reserve = Domain.Reservation.Reserve.Create(customer.Id);
        if(!request.Packages.Any())
        {
            return Error.NotFound("Reserve.Detail", "For create at Reserve you need to specify the packages.");
        }
        foreach (var item in request.Packages)
        {
            Reserve.Add(new PackageId(item.PackageId), new Money("$", item.Price));
        }
        _reserveRepository.Add(Reserve);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new ReserveResponse();
    }
}
