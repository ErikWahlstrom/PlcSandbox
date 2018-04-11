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
            var name = "Name";
            var address = new BoolAddressUnconnected(size, name);
            Assert.AreEqual(name, address.Name);
            Assert.AreEqual(size, address.BitSize);
        }
    }
}
