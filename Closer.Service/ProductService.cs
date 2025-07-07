
using Closer.Domain.Interface;
using Closer.Domain.Models;


namespace Closer.Service
{
    //public class ProductService : IProductService
    //{
    //    private readonly IProductRepository _productRepository;

    //    public ProductService(IProductRepository productRepository)
    //    {
    //        _productRepository = productRepository;
    //    }

    //    public async Task<List<Product>> GetAllProducts()
    //    {
    //        return await _productRepository.GetAllProductsAsync();
    //    }
    //}

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<List<Product>> SearchAsync(string searchTerm)
        {
            var allProducts = await _productRepository.GetAllProductsAsync();

            if (string.IsNullOrWhiteSpace(searchTerm))
                return allProducts;

            searchTerm = searchTerm.ToLower();

            return allProducts
                .Where(p =>
                    (!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(searchTerm))
                )
                .ToList();
        }


    }
}
