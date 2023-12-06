using FluentValidation;

namespace MyScrutor.Services.Generic
{
    public class GenericRipositoryValidator<T> : IRepository<T>
    {
        private readonly IRepository<T> _bookRepository;
        private readonly IEnumerable<IValidator<T>> _validators;
        public GenericRipositoryValidator(IRepository<T> bookRepository, IEnumerable<IValidator<T>> validators)
        {
            _bookRepository = bookRepository;
            _validators = validators;
        }
        public void Save(T entity)
        {
            var context = new ValidationContext<T>(entity);
            var failures = _validators.Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if(failures.Count!=0)
            {
                throw new ValidationException(failures);
            }

            _bookRepository.Save(entity);

               
        }
    }
}
