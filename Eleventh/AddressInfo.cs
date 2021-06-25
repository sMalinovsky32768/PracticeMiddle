using System;

namespace Eleventh
{
    public class AddressInfo : IEquatable<AddressInfo>
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public bool Equals(AddressInfo other) => Street == other.Street && HouseNumber == other.HouseNumber;

        public override bool Equals(object obj) => Equals(obj as AddressInfo);

        public override int GetHashCode() => HashCode.Combine(Street, HouseNumber);
        public static bool operator ==(AddressInfo address1, AddressInfo address2) => Equals(address1, address2) || address1.Equals(address2);
        public static bool operator !=(AddressInfo address1, AddressInfo address2) => !Equals(address1, address2) && !address1.Equals(address2);
    }
}
