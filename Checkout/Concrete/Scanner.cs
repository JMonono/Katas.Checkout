using System.Collections.Generic;

namespace Checkout.Concrete
{
    public class Scanner
    {
        private Money _total = new Money(0);
        
        private readonly ICheckoutListener _checkoutListener;
        private readonly IDiscountListener _discountListener;

        private readonly Dictionary<Product, Money> _priceList = new Dictionary<Product, Money>
        {
            {new Product("A"), new Money(50)},
            {new Product("B"), new Money(30)},
            {new Product("C"), new Money(20)},
            {new Product("D"), new Money(15)}
        };
        
        public Scanner(ICheckoutListener checkoutListener, IDiscountListener discountListener)
        {
            _checkoutListener = checkoutListener;
            _discountListener = discountListener;
        }

        public void Scan(Product item)
        {
            _total = _total.Add(_priceList[item]);

            // Connascence of algorithm here - can this be avoided?
            _discountListener.ItemScanned(item, SetDiscount);
            _checkoutListener.ItemScanned(item, _total);
        }

        private void SetDiscount(Money amountToDiscount)
        {
            _total = _total.Subtract(amountToDiscount);
        }
    }
}