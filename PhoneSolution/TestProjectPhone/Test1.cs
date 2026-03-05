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
            Assert.ThrowsException<ArgumentException>(() => new Phone(null!, "123456789"));
        }
        [TestMethod]
        public void Konstructor_PustyPhoneNumber_RzucaWyjatek()
        {
            Assert.ThrowsException<ArgumentException>(() => new Phone("John Doe", ""));
        }
        [TestMethod]
        public void Konstructor_NullPhoneNumber_RzucaWyjatek()
        {
            Assert.ThrowsException<ArgumentException>(() => new Phone("John Doe", null!));
        }
        [TestMethod]
        public void Konstructor_NiepoprawnyPhoneNumber_RzucaWyjatek()
        {
            Assert.ThrowsException<ArgumentException>(() => new Phone("John Doe", "12345"));
            Assert.ThrowsException<ArgumentException>(() => new Phone("John Doe", "1234567890"));
            Assert.ThrowsException<ArgumentException>(() => new Phone("John Doe", "12345678a"));
        }
        [TestMethod]
        public void AddContact_PoprawneDane_DodajeKontakt_ZwiekszaIlosc()
        {
            var phone = new Phone("John Doe", "123456789");
            var result = phone.AddContact("Alice", "987654321");
            Assert.IsTrue(result);
            Assert.AreEqual(1, phone.Count);
        }
        [TestMethod]
        public void AddContact_DuplicateName_ZwracaFalse()
        {
            var phone = new Phone("John Doe", "123456789");
            bool first = phone.AddContact("Alice", "987654321");
            bool second = phone.AddContact("Alice", "111222333");
            Assert.IsTrue(first);
            Assert.IsFalse(second);
            Assert.AreEqual(1, phone.Count);
        }
        [TestMethod]
        public void AddContact_PhoneBookFull_RzucaWyjatek()
        {
            var phone = new Phone("John Doe", "123456789");
            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Contact{i}", $"12345678{i}");
            }
            Assert.ThrowsException<InvalidOperationException>(() => phone.AddContact("ExtraContact", "123456789"));
        }
        [TestMethod]
        public void AddContact_NullName_ThrowsArgumentNullException()
        {
            var phone = new Phone("John Doe", "123456789");
            Assert.ThrowsException<ArgumentNullException>(() => phone.AddContact(null!, "987654321"));
        }
        [TestMethod]
        public void AddContact_DuplicateName_ZwracaFalse_Alternate()
        {
            var phone = new Phone("John Doe", "123456789");
            bool first = phone.AddContact("Bob", "111222333");
            bool second = phone.AddContact("Bob", "444555666");
            Assert.IsTrue(first);
            Assert.IsFalse(second);
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void Call_PoprawnyKontakt_ZwracaWiadomosc()
        {
            var phone = new Phone("John Doe", "123456789");
            phone.AddContact("Alice", "987654321");
            var message = phone.Call("Alice");
            Assert.AreEqual("Calling 987654321 (Alice) ...", message);
        }

        [TestMethod]
        public void Call_BrakKontaktu_RzucaWyjatek()
        {
            var phone = new Phone("John Doe", "123456789");
            Assert.ThrowsException<InvalidOperationException>(() => phone.Call("Unknown"));
        }
    }
}
