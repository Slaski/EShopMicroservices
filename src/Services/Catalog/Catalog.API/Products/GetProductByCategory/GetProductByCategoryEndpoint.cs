namespace Catalog.API.Products.GetProductByCategory;

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, IMediator mediator) =>
        {
            var result = await mediator.SendQueryAsync<GetProductByCategoryQuery, GetProductByCategoryResult>(new GetProductByCategoryQuery(category));
            var response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductsByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product by Category")
        .WithDescription("Get Product by Category");
    }
}
