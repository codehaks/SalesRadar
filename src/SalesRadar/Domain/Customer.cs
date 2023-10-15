using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRadar.Domain;
public class Customer
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string BankAccountNumber { get; set; }
}
