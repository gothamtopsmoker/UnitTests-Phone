using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectPhone
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void Konstructor_PoprawneDane_TworzyObiekt()
        {
            var phone = new Phone("John Doe", "123456789");
            Assert.AreEqual("John Doe", phone.Owner);
            Assert.AreEqual("123456789", phone.PhoneNumber);
            Assert.AreEqual(0, phone.Count);
        }

        [TestMethod]
        public void Konstructor_PustyOwner_RzucaWyjatek()
        {
            Assert.ThrowsException<ArgumentException>(() => new Phone("", "123456789"));
        }
        [TestMethod]
        public void Konstructor_NullOwner_RzucaWyjatek()
        {
            Assert.ThrowsException<ArgumentException>(() => new Phone(null, "123456789"));
        }
        [TestMethod]
        public void Konstructor_PustyPhoneNumber_RzucaWyjatek()
        {
            Assert.ThrowsException<ArgumentException>(() => new Phone("John Doe", ""));
        }
        [TestMethod]
        public void Konstructor_NullPhoneNumber_RzucaWyjatek()
        {
            Assert.ThrowsException<ArgumentException>(() => new Phone("John Doe", null));
        }

    }
}
