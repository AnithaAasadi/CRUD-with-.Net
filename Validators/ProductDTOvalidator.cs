namespace CRUD.Validators
{
    using CRUD.DTO;
    using CRUD.Interfaces;
    using FluentValidation;

    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        private readonly ICategoryRepository _repo;
        public ProductDtoValidator(ICategoryRepository repo)
        {
            _repo = repo;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");

            RuleFor(x => x.CategoryId)
                 .GreaterThan(0).WithMessage("Invalid CategoryId");
            /*RuleFor(x => x.CategoryId)
     .MustAsync(async (id, ct) =>
     {
         var category = await repo.GetCategoryById(id);
         return category != null;
     })
     .WithMessage("Category does not exist.");*/

        }
    }
}

