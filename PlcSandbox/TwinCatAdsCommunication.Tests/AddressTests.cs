namespace TwinCatAdsCommunication.Tests
{
    using NUnit.Framework;
    using TwinCatAdsCommunication.Address;

    public class AddressTests   
    {
        [Test]
        public void CanCreateBoolAddress()
        {
            var size = 12;
            var bitOffset = 34;
            var name = "Name";
            var address = new BoolAddress(size, name, bitOffset);
            Assert.AreEqual(name, address.Name);
            Assert.AreEqual(size, address.BitSize);
            Assert.AreEqual(bitOffset, address.BitOffset);
        }
    }
}
