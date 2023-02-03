using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{
    public static class AccountBalanceConverter
    {
        public static AccountBalance Convert(EtherscanBalancesResponse_Balance sourceData)
        {
            AccountBalance result = new AccountBalance();
            result.Address = sourceData.account;
            result.Balance = UnitsConverter.WeiToEth(decimal.Parse(sourceData.balance));
            return result;
        }

        public static List<AccountBalance> Convert(List<EtherscanBalancesResponse_Balance> sourceData)
        {
            List<AccountBalance> result = new();
            foreach (EtherscanBalancesResponse_Balance item in sourceData)
            {
                try
                {
                    AccountBalance o = new();
                    o.Address = item.account;
                    o.Balance = UnitsConverter.WeiToEth(decimal.Parse(item.balance));
                    result.Add(o);
                }
                catch (Exception ex) { }
            }
            return result;
        }


    }
}
