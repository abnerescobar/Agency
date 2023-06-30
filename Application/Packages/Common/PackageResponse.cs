using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Packages.Common;

public record  PackageResponse(
        Guid Id,
        string Name,
        string Sku,
        string Description,
        string  TravelDate,
        MoneyResponse Money);
public record MoneyResponse(string Currency, decimal Amount);


