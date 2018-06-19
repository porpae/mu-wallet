using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace mu_wallet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_Input_Balance_10_amount_1000_balanceReceive_True()
        {
            int balance = 10;
            int amount_Transfer = 1000;
            bool expected = true;
            mu_wallet.Service walletObj = new mu_wallet.Service();

            bool actual = walletObj.check_condition(balance, amount_Transfer);

            Assert.AreEqual(expected, actual);
        }
    }
}
