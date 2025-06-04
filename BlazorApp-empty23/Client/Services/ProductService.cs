// Client/Services/ProductService.cs
using System.Net.Http.Json;
using Shared.Models;

namespace Client.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>?> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Product>>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<Product>();
        }
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
    }

    public async Task AddProductAsync(Product product)
    {
        await _httpClient.PostAsJsonAsync("api/products", product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/products/{id}");
    }

}