using Eleventh;

using System.Collections.Generic;
using System.Linq;

using static System.Console;

var house = new House
{
    Address = new AddressInfo
    {
        Street = "Street",
        HouseNumber = "123",
    },
    IsPrivate = true,
    Name = "House",
    OwnerName = "Owner"
};

var house2 = new House
{
    Address = new AddressInfo
    {
        Street = "Street",
        HouseNumber = "123",
    },
    IsPrivate = true,
    Name = "House2",
    OwnerName = "Owner"
};

var house3 = new House
{
    Address = new AddressInfo
    {
        Street = "Street2",
        HouseNumber = "123",
    },
    IsPrivate = true,
    Name = "House2",
    OwnerName = "Owner"
};

var deepClone = house.DeepClone();
var clone = house.Clone() as House;

var deepClone2 = house2.DeepClone();
var clone2 = house2.Clone() as House;

var deepClone3 = house3.DeepClone();
var clone3 = house3.Clone() as House;

var houses = new Dictionary<string, House>
{
    { nameof(house), house },
    { nameof(house2), house2 },
    { nameof(house3), house3 },
    { nameof(clone), clone },
    { nameof(clone2), clone2 },
    { nameof(clone3), clone3 },
    { nameof(deepClone), deepClone },
    { nameof(deepClone2), deepClone2 },
    { nameof(deepClone3), deepClone3 },
}.ToArray();

for (var i = 0; i < houses.Length; i++)
{
    for (var j = 0; j < houses.Length; j++)
    {
        WriteLine();

        WriteLine($"Compare {houses[i].Key} and  {houses[j].Key}");
        Compare(houses[i].Value, houses[j].Value);
    }
}

static void Compare(House a, House b)
{
    WriteLine(a);
    WriteLine(b);
    WriteLine($"a equals b: {a.Equals(b)}");
    WriteLine($"a == b:     {a == b}");
    WriteLine($"a.Adress equals b.Address:  {a.Address.Equals(b?.Address)}");
    WriteLine($"a.Adress == b.Address:      {a.Address == b?.Address}");
}