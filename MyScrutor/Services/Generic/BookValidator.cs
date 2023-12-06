using FluentValidation;
using MyScrutor.Models;
using System.Data;

namespace MyScrutor.Services.Generic
{
    public class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty();

            RuleFor(x=>x.Name)
                .NotEmpty();
        }
    }
}
