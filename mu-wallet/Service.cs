using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mu_wallet
{
    public class Service
    {
       public bool check_condition(int balance, int amount_Transfer)
        {
            return true;
        }

        public bool Update_DB(string account_No,int balance)
        {
            connectionDatabase con = new connectionDatabase();
            return con.updateData("ACCOUNTS", "Balance=" + balance, "Account_No like '"+account_No+"'");
        }
    }
}