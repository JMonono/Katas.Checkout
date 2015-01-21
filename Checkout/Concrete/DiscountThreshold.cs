namespace Checkout.Concrete
{
    public class DiscountThreshold
    {
        private readonly Product _product;
        private readonly int _discountThreshold;

        public DiscountThreshold(Product product, int discountThreshold)
        {
            _product = product;
            _discountThreshold = discountThreshold;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var suppliedDiscountThreshold = ((DiscountThreshold)obj);

            return suppliedDiscountThreshold._discountThreshold == _discountThreshold &&
                   suppliedDiscountThreshold._product.Equals(_product);

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return _discountThreshold.GetHashCode() ^ _product.GetHashCode();
        }
    }
}