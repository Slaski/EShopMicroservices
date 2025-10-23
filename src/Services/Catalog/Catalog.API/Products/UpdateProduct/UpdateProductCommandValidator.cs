namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Product ID is required");
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(c => c.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
