using System;
using Checkout.Concrete;

namespace Checkout
{
    public interface IDiscountListener
    {
        void ItemScanned(Product item, Action<Money> applyDiscount);
    }
}