using System.ComponentModel.DataAnnotations;
namespace ECommerceDomain;

public class User {
    [Display(Name = "First Name")]
    public string FirstName {get; set;}

    [Display(Name = "Last Name")]
    public string LastName {get; set;}

    [Display(Name = "Email Address")]
    public string EmailId {get; set;}

    [Display(Name = "Contact Number")]
    public string ContactNo {get; set;}

    [Display(Name = "Password")]
    public string Password {get; set;}
}