using System;
using System.Collections.Generic;
using System.Linq;

namespace sel_12.Models
{
    public class Product : IEquatable<Product>
    {
        public string ProductName { get; set; }

        public string Manufacturer { get; set; }

        public decimal ActualPrice { get; set; }

        public decimal? OldPrice { get; set; }

        public List<string> Stickers { get; set; }

        public enum ProductCategories
        {
            MostPopular,
            Campaigns,
            Latest
        }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ProductName, other.ProductName) && 
                ActualPrice == other.ActualPrice && 
                OldPrice == other.OldPrice && 
                Stickers.OrderBy(x => x).SequenceEqual(other.Stickers.OrderBy(x => x));
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
                hashCode = (hashCode * 397) ^ ActualPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ (Stickers != null ? Stickers.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
