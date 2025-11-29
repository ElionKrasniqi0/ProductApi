using ProductApi.DTOs.Commands;
using ProductApi.DTOs.Queries;
using ProductApi.Entities;

namespace ProductApi.Interfaces
{
    public interface IProductService
    {
        Task<PagedResult<ProductResponseDto>> GetProductsAsync(ProductQueryDto query);
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductResponseDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int id);
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}