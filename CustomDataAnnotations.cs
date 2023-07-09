using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace gettingstarted;

public class Citizen {

    [ValidCreditCard]
    public string CreditCard { get; set; }

    [IsBornBetweenTheseDates("1900-01-01", "2099-12-31")]
    public DateTime BirthDate { get; set; }

}


public class IsBornBetweenTheseDates : ValidationAttribute
{
    private readonly DateTime _min;
    private readonly DateTime _max;

    public IsBornBetweenTheseDates(string minDate, string maxDate)
    {
        _min = DateTime.Parse(minDate);
        _max = DateTime.Parse(maxDate);
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date && date >= _min && date <= _max)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"Date is not in the range {_min:d} to {_max:d}");
    }
}

public class ValidCreditCardAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var creditCardNumber = value as string;
        if (creditCardNumber != null && CheckCreditCard(creditCardNumber))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Invalid credit card number.");
    }

    private bool CheckCreditCard(string creditCardNumber)
    {
        // Put Luhn algorithm implementation here
        // Return true if creditCardNumber passes the Luhn check, false otherwise
        return false;
    }
}



[TestFixture]
public class AgeGroupAttributeTests
{
    
    public bool ValidateObjectFromDataAnnotations(object obj)
    {
        ICollection<ValidationResult> validationResults = new List<ValidationResult>();
        return  Validator.TryValidateObject(
            obj,
            new ValidationContext(obj),
            validationResults,
            true);
        
    }
    

    
    [Test]
    public void ValidateCreditCard_GivenValidNumber_ReturnsTrue()
    {
        var testCitizen = new Citizen {CreditCard = "4111111111111111"};
        var result = ValidateObjectFromDataAnnotations(testCitizen);
        Assert.True(result);
    }
    
    [Test]
    public void ValidateCreditCard_GivenInvalidNumber_ReturnsFalse()
    {
        var testCitizen = new Citizen {CreditCard = "1234"};
        var result = ValidateObjectFromDataAnnotations(testCitizen);
        Assert.False(result);
    }
    
    [Test]
    public void ValidateDateRange_GivenValidDate_ReturnsTrue()
    {
        var testCitizen = new Citizen {BirthDate = new DateTime(2000, 12, 31)};
        var result = ValidateObjectFromDataAnnotations(testCitizen);
        Assert.True(result);
    }
    
    [Test]
    public void ValidateDateRange_GivenInvalidDate_ReturnsFalse()
    {
        var testCitizen = new Citizen {BirthDate = new DateTime(2100, 1, 1)};
        var result = ValidateObjectFromDataAnnotations(testCitizen);
        Assert.False(result);
    }

}