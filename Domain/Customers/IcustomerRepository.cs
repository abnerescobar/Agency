﻿
namespace Domain.Customers;
public interface IcustomerRepository
{
    Task<List<Customer>> GetAll();
    Task<Customer?> GetByIdAsync(CustomerId id);
    Task<bool> ExistsAsync(CustomerId id);
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(Customer customer);
}
