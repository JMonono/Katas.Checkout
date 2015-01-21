using System;

namespace Checkout.Concrete
{
    public class Money
    {
        private readonly int _amount;

        public Money(int amount)
        {
            _amount = amount;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Money)obj)._amount == _amount;
        }

        public override int GetHashCode()
        {
            return _amount.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Amount: {0}", _amount);
        }

        public Money Add(Money amountToAdd)
        {
            return new Money(_amount + amountToAdd._amount);
        }

        public Money Subtract(Money amountToSubtract)
        {
            return new Money(_amount - amountToSubtract._amount);
        }
    }
}