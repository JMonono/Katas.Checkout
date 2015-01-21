namespace Checkout.Concrete
{
    public class Product
    {
        private readonly string _name;

        public Product(string name)
        {
            _name = name;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((Product)obj)._name == _name;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }
    }
}