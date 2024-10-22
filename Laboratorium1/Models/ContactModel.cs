using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Imię jest wymagane")]
    [MaxLength(length:20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    
    public string LastName { get; set; }
    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    [MaxLength(length:20, ErrorMessage = "Nazwisko nie może być dłuższe niż 20 znaków")]
    
    public string Email { get; set; }
    [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
    public string PhoneNumber { get; set; }
    [Phone(ErrorMessage = "Niepoprawny numer telefonu")]
    [RegularExpression("{\\d}-\\d{3}-\\d{3}-\\d{3}", ErrorMessage = "Wpisz numer w formacie xxx xxx xxx")]
    
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
}