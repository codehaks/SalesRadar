using SalesRadar.Domain.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRadar.Domain;
public class Customer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public required DateOfBirth DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string BankAccountNumber { get; set; }
}
