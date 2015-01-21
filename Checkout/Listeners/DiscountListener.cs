using System;
using System.Collections.Generic;
using Checkout.Concrete;

namespace Checkout.Listeners
{
    public class DiscountListener : IDiscountListener
    {
        private readonly Dictionary<Product, int> _itemsAwaitingDiscount = new Dictionary<Product, int>();
        private readonly Dictionary<DiscountThreshold, Money> _discountList = new Dictionary<DiscountThreshold, Money>
        {
            {new DiscountThreshold(new Product("A"), 3), new Money(20)},
            {new DiscountThreshold(new Product("B"), 2), new Money(15)}
        };

        public void ItemScanned(Product item, Action<Money> applyDiscount)
        {
            IncrementItemsAwaitingDiscountCount(item);
            ApplyDiscount(item, applyDiscount);
        }

        private void ApplyDiscount(Product item, Action<Money> applyDiscountAction)
        {
            var discountThresholdKey = new DiscountThreshold(item, _itemsAwaitingDiscount[item]);

            if (DiscountRequired(discountThresholdKey))
            {
                var amountToDiscount = _discountList[discountThresholdKey];
                applyDiscountAction(amountToDiscount);
                ResetDiscountCount(item);
            }
        }

        private void ResetDiscountCount(Product item)
        {
            _itemsAwaitingDiscount[item] = 0;
        }

        private bool DiscountRequired(DiscountThreshold discountThresholdKey)
        {
            return _discountList.ContainsKey(discountThresholdKey);
        }

        private void IncrementItemsAwaitingDiscountCount(Product item)
        {
            if (!_itemsAwaitingDiscount.ContainsKey(item))
                _itemsAwaitingDiscount.Add(item, 0);

            _itemsAwaitingDiscount[item] = _itemsAwaitingDiscount[item] + 1;
        }
    }
}