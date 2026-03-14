using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PR6._1;

namespace PR6._1_BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        /*[TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 23.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }*/


        /*[TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            double expected = 16.99;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -5.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

        [TestMethod]
        public void Credit_WithZeroAmount_DoesNotChangeBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 0.0;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(beginningBalance, actual, 0.001, "Balance should not change when credit is zero");
        }*/

/*        [TestMethod]
        public void Credit_ManySmallCredits_ShouldAccumulateCorrectly()
        {
            // Arrange
            BankAccount account = new BankAccount("Mr. Roman Abramovich", 0.0);

            // Act
            for (int i = 0; i < 100; i++)
            {
                account.Credit(10.0);
            }

            // Assert
            Assert.AreEqual(1000.0, account.Balance, 0.001, "Balance incorrect after many credit operations");
        }


        [TestMethod]
        public void Credit_WithLargeAmount_UpdatesBalanceCorrectly()
        {
            // Arrange
            double beginningBalance = 100.00;
            double creditAmount = 1000000.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double expected = 1000100.00;
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Large credit not processed correctly");
        }*/


        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldContainCorrectErrorMessage()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -5.00;
            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            // Act
            try
            {
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, "Credit amount is less than zero");
                return;
            }

            Assert.Fail("Expected exception was not thrown.");
        }

        /*[TestMethod]
        public void Credit_ShouldNotAffectOtherAccounts()
        {
            // Arrange
            BankAccount account1 = new BankAccount("Mr. Roman Abramovich", 100.00);
            BankAccount account2 = new BankAccount("Mr. Roman Abramovich", 200.00);

            // Act
            account1.Credit(50.00);

            // Assert
            Assert.AreEqual(150.00, account1.Balance, 0.001);
            Assert.AreEqual(200.00, account2.Balance, 0.001, "Credit operation affected another account");
        }*/
    }
}
