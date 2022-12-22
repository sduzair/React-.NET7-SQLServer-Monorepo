using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductsAPI.Controllers;

[ApiController]
[Route("/api/products")]
[Authorize(Roles = "Customer,ProductsAdmin")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
	private readonly ApiDbContext _context;
	private readonly ILogger<ProductsController> _logger;

	public ProductsController(ApiDbContext context, ILogger<ProductsController> logger)
	{
		_context = context;
		_logger = logger;
	}

	[HttpGet]
	[AllowAnonymous]
	[SwaggerOperation(Summary = "Get all products")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetProductResDto>))]
	public async Task<IActionResult> GetProducts(int limit = 10, string sort = "id", int sortDirection = 1, int skip = 0, string? category = "all")
	{
		// 	.ToListAsync();
		IQueryable<GetProductResDto> getProductsResDto = _context.Products
			.Where(p => category!.Equals("all", StringComparison.Ordinal) || p.Category == category)
			.Skip(skip)
			.Take(limit)
			.Select(p =>
				new GetProductResDto
				{
					ProductId = p.ProductId,
					Title = p.Title,
					Description = p.Description,
					Price = p.Price,
					DiscountPercentage = p.DiscountPercentage,
					Rating = p.Rating,
					Stock = p.Stock,
					Brand = p.Brand,
					Category = p.Category,
					ImageUrl = p.ImageUrl,
					DateCreated = p.DateCreated,
					DateUpdated = p.DateUpdated,
				}
			);

		// sort switch
		// {
		// 	"id" => getProducts.OrderBy(p => p.ProductId),
		// 	// "title" => p.Title,
		// 	// "price" => p.Price,
		// 	// "rating" => p.Rating,
		// 	// "stock" => p.Stock,
		// 	// "dateCreated" => p.DateCreated,
		// 	// "dateUpdated" => p.DateUpdated,
		// 	// _ => p.ProductId,
		// };
		if (sort.Equals("id", StringComparison.Ordinal)) getProductsResDto = sortDirection == 1 ? getProductsResDto.OrderBy(p => p.ProductId) : getProductsResDto.OrderByDescending(p => p.ProductId);
		if (sort.Equals("price", StringComparison.Ordinal)) getProductsResDto = sortDirection == 1 ? getProductsResDto.OrderBy(p => p.Price) : getProductsResDto.OrderByDescending(p => p.Price);
		if (sort.Equals("rating", StringComparison.Ordinal)) getProductsResDto = sortDirection == 1 ? getProductsResDto.OrderBy(p => p.Rating) : getProductsResDto.OrderByDescending(p => p.Rating);





		//List<GetProductResDto> getProductResDto = _mapper.Map<List<GetProductResDto>>(products);
		return Ok(await getProductsResDto.ToListAsync());
	}

	[HttpGet("{id}")]
	[AllowAnonymous]
	[SwaggerOperation(Summary = "Get product by id")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductResDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetProduct(int id)
	{
		Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
		if (product == null)
			return NotFound();
		GetProductResDto? getProductResDto = await _context.Products
			.Where(p => p.ProductId == id)
			.Select(p =>
				new GetProductResDto
				{
					ProductId = p.ProductId,
					Title = p.Title,
					Description = p.Description,
					Price = p.Price,
					DiscountPercentage = p.DiscountPercentage,
					Rating = p.Rating,
					Stock = p.Stock,
					Brand = p.Brand,
					Category = p.Category,
					ImageUrl = p.ImageUrl,
					DateCreated = p.DateCreated,
					DateUpdated = p.DateUpdated,
				}
			)
			.FirstOrDefaultAsync();
		//GetProductResDto productResDto = _mapper.Map<GetProductResDto>(product);
		return Ok(getProductResDto);
	}

	[HttpPost]
	[Authorize(Roles = "ProductsAdmin")]
	[SwaggerOperation(Summary = "Create product")]
	[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetProductResDto))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	public async Task<IActionResult> PostProduct([FromBody] PostProductReqDto postProductReqDto)
	{
		//Product product = _mapper.Map<Product>(postProductReqDto);
		Product product = new()
		{
			Title = postProductReqDto.Title,
			Description = postProductReqDto.Description,
			Price = (decimal)postProductReqDto.Price!,
			DiscountPercentage = (decimal)postProductReqDto.DiscountPercentage!,
			Rating = (double)postProductReqDto.Rating!,
			Stock = (int)postProductReqDto.Stock!,
			Brand = postProductReqDto.Brand,
			Category = postProductReqDto.Category,
			ImageUrl = postProductReqDto.ImageUrl
		};
		_ = _context.Products.Add(product);
		_ = await _context.SaveChangesAsync();
		return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, postProductReqDto);
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "ProductsAdmin")]
	[SwaggerOperation(Summary = "Update product")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> PutProduct(int id, [FromBody] PutProductReqDto putProductReqDto)
	{
		Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
		if (product == null) return NotFound();

		//_ = _mapper.Map(postProductReqDto, product);
		//if (putProductReqDto.Title != null)
		//	product.Title = putProductReqDto.Title;

		if (putProductReqDto.Title != null)
			product.Title = putProductReqDto.Title;

		if (putProductReqDto.Description != null)
			product.Description = putProductReqDto.Description;

		if (putProductReqDto.Price != null)
			product.Price = (decimal)putProductReqDto.Price;

		if (putProductReqDto.DiscountPercentage != null)
			product.DiscountPercentage = (decimal)putProductReqDto.DiscountPercentage;

		if (putProductReqDto.Rating != null)
			product.Rating = (double)putProductReqDto.Rating;

		if (putProductReqDto.Stock != null)
			product.Stock = (int)putProductReqDto.Stock;

		if (putProductReqDto.Brand != null)
			product.Brand = putProductReqDto.Brand;

		if (putProductReqDto.Category != null)
			product.Category = putProductReqDto.Category;

		if (putProductReqDto.ImageUrl != null)
			product.ImageUrl = putProductReqDto.ImageUrl;

		_ = await _context.SaveChangesAsync();
		return NoContent();
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "ProductsAdmin")]
	[SwaggerOperation(Summary = "Delete product")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status403Forbidden)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> DeleteProduct(int id)
	{
		Product? product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
		if (product == null)
			return NotFound();

		_ = _context.Products.Remove(product);
		_ = await _context.SaveChangesAsync();
		return NoContent();
	}
}