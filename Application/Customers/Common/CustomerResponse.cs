namespace Customers.Common;
public record CustomerResponse(
Guid Id,
string FullName,
string Email,
string PhoneNumber,
bool Active);
