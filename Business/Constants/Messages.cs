using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ürün eklendi";
        public static string NameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string SubpieceAdded = "Parça eklendi";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string QuantityError = "Product quantity should be multiple of five";
        public static string NoStock = "Subpart is out of stock";
        public static string SubpieceAddedToProduct = "Subpiece added to product";
        public static string Updated = "Updated";
        public static string ProductNotFound = "Product Not Found";
        public static string ProductIdError = "ProductId does not exist";
        public static string OrderNotFound = "Order Not Found";
    }
}
