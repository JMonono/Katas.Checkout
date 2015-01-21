using Checkout.Concrete;

namespace Checkout
{
    public interface ICheckoutListener
    {
        void ItemScanned(Product item, Money currentTotal);
    }
}