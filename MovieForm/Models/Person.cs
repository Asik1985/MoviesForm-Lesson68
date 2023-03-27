using Microsoft.AspNetCore.Mvc;
using MovieForm.Attributes;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace MovieForm.Models;


public class Person
{
    [Display(Name = "Имя")]
    [PersonName(new string[] { "Tom", "Sam", "Alice" }, ErrorMessage = "Недопустимое имя")]
    [Required(ErrorMessage = "Не указано имя")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Не указан возраст")]
    [Range(1, 110, ErrorMessage = "Недопустимый возраст")]
    public int Age { get; set; }


    //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
    [EmailAddress(ErrorMessage = "Некорректный адрес")]
    [Remote(action: "CheckEmail", controller: "Home", ErrorMessage = "Email уже используется")]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string? PasswordConfirm { get; set; }


}