using System;
using Bank;
using NUnit.Framework;

namespace HelloBankTest
{
    [TestFixture]
    public class UnitTests
    {
        private BankAccount account = null;
        private BankAccount otherAccount = null;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount(1000);
        }

        [Test]
        public void Adding_Funds_Updates_Balance()
        {
            // Act
            account.Add(500);

            // Assert
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void Adding_Negative_Funds_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-500));
        }

        [Test]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // Act
            account.Withdraw(500);

            // Assert
            Assert.AreEqual(500, account.Balance);
        }

        [Test]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));
        }

        [Test]
        public void Withdrawing_More_Than_Balance_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Test]
        public void Transfering_Funds_Updates_Both_Account()
        {
            // Arrange
            otherAccount = new BankAccount();

            // Act
            account.TransferFundsTo(otherAccount, 500);

            // Assert
            Assert.AreEqual(500, account.Balance);
            Assert.AreEqual(500, otherAccount.Balance);
        }

        [Test]
        public void Transfering_To_Non_Existing_Account_Throws()
        {
            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}
