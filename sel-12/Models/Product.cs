using System;

namespace sel_12.Models
{
    public class Product : IEquatable<Product>
    {
        public string ProductName { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public string StickerValue { get; set; }

        public enum ProductCategories
        {
            MostPopular,
            Campaings,
            Latest
        }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ProductName, other.ProductName) && 
                string.Equals(Manufacturer, other.Manufacturer) && 
                Price == other.Price && 
                string.Equals(StickerValue, other.StickerValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ProductName != null ? ProductName.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Manufacturer != null ? Manufacturer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ (StickerValue != null ? StickerValue.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
