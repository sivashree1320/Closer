using Closer.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json;

namespace Closer.Services
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartKey = "CartItems";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<MenProduct> GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString(CartKey);
            return cartJson == null ? new List<MenProduct>() : JsonSerializer.Deserialize<List<MenProduct>>(cartJson);
        }

        public void AddToCart(MenProduct product)
        {
            var cart = GetCart();
            cart.Add(product);
            SaveCart(cart);
        }

        public void SaveCart(List<MenProduct> cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString(CartKey, JsonSerializer.Serialize(cart));
        }
    }
}
