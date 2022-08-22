using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    //Repository pattern that consist all the methods related to product which we pass to controller
    public interface IProductRepository
    {
        //Signature of our methods
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}