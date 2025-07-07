using Closer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closer.Domain.Interface
{
    public interface ICartRepository
    {
        List<MenProduct> GetCart();
        void AddToCart(MenProduct product);
        void SaveCart(List<MenProduct> cart);
    }
}
