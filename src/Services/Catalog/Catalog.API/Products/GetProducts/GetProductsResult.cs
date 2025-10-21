using Catalog.API.Models;

namespace Catalog.API.Products.GetProducts;

public record GetProductsResult(IEnumerable<Product> Products);
