using Closer.Models;

namespace Closer.Domain.Interface
{
    public interface ICartService
    {
        List<MenProduct> GetCart();
        void AddToCart(MenProduct product);
        void SaveCart(List<MenProduct> cart);
    }
}
