using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Queries;

internal sealed class GetCustomerQuery : IRequest<ErrorOr<List<CustomerDto>>>
{
}
