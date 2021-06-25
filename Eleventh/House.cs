using System;

namespace Eleventh
{
    public class House : ICloneable, IDeepCloneable<House>, IEquatable<House>
    {
        public string OwnerName;
        public bool IsPrivate;

        public AddressInfo Address { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            return new House
            {
                Address = Address,
                Name = Name,
                IsPrivate = IsPrivate,
                OwnerName = OwnerName,
            };
        }

        public House DeepClone()
        {
            return new House
            {
                Address = new AddressInfo
                {
                    HouseNumber = Address.HouseNumber,
                    Street = Address.Street,
                },
                Name = Name,
                IsPrivate = IsPrivate,
                OwnerName = OwnerName,
            };
        }

        public bool Equals(House other) => OwnerName.Equals(other.OwnerName) && IsPrivate.Equals(other.IsPrivate) && Address.HouseNumber.Equals(other.Address.HouseNumber) && Address.Street.Equals(other.Address.Street) && Name.Equals(other.Name);

        public override bool Equals(object obj) => Equals(obj as House);

        public override int GetHashCode() => HashCode.Combine(Name, Address.GetHashCode(), IsPrivate, OwnerName);

        public override string ToString() => $"{{Street: {Address.Street}, Number: {Address.HouseNumber}, Name: {Name}, Owner: {OwnerName}, Private: {IsPrivate}}}";

        public static bool operator ==(House house1, House house2) => Equals(house1, house2) || house1.Equals(house2);
        public static bool operator !=(House house1, House house2) => !Equals(house1, house2) && !house1.Equals(house2);
    }
}
