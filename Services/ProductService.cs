using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Commands;
using ProductApi.DTOs.Queries;
using ProductApi.Entities;
using ProductApi.Interfaces;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductResponseDto>> GetProductsAsync(ProductQueryDto query)
        {
            var productsQuery = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(query.Category))
            {
                productsQuery = productsQuery.Where(p => p.Category.ToLower() == query.Category.ToLower());
            }

            if (query.MinPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price >= query.MinPrice.Value);
            }

            if (query.MaxPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price <= query.MaxPrice.Value);
            }
            productsQuery = query.SortBy?.ToLower() switch
            {
                "name" => query.SortDescending ? productsQuery.OrderByDescending(p => p.Name) : productsQuery.OrderBy(p => p.Name),
                "price" => query.SortDescending ? productsQuery.OrderByDescending(p => p.Price) : productsQuery.OrderBy(p => p.Price),
                "category" => query.SortDescending ? productsQuery.OrderByDescending(p => p.Category) : productsQuery.OrderBy(p => p.Category),
                "stockquantity" => query.SortDescending ? productsQuery.OrderByDescending(p => p.StockQuantity) : productsQuery.OrderBy(p => p.StockQuantity),
                "createdat" => query.SortDescending ? productsQuery.OrderByDescending(p => p.CreatedAt) : productsQuery.OrderBy(p => p.CreatedAt),
                _ => query.SortDescending ? productsQuery.OrderByDescending(p => p.Name) : productsQuery.OrderBy(p => p.Name)
            };

            var totalCount = await productsQuery.CountAsync();

            var products = await productsQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            var productDtos = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CreatedAt = p.CreatedAt,
                InStock = p.StockQuantity > 0
            }).ToList();

            return new PagedResult<ProductResponseDto>
            {
                Items = productDtos,
                TotalCount = totalCount,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return null;

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CreatedAt = product.CreatedAt,
                InStock = product.StockQuantity > 0
            };
        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Category = createProductDto.Category,
                Price = createProductDto.Price,
                StockQuantity = createProductDto.StockQuantity,
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CreatedAt = product.CreatedAt,
                InStock = product.StockQuantity > 0
            };
        }

        public async Task<ProductResponseDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return null;

            product.Name = updateProductDto.Name;
            product.Category = updateProductDto.Category;
            product.Price = updateProductDto.Price;
            product.StockQuantity = updateProductDto.StockQuantity;

            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CreatedAt = product.CreatedAt,
                InStock = product.StockQuantity > 0
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}