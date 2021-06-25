using System;

namespace Tenth
{
    public class ShopNotFoundException : Exception
    {
        public string ShopName { get; set; }

        public override string Message => !string.IsNullOrWhiteSpace(ShopName) ? $"Shop named \"{ShopName}\" not found" : $"Shop not found";

        public ShopNotFoundException() : base() { }
        public ShopNotFoundException(string shopName) : base() => ShopName = shopName;
    }
}
