using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{
    internal static class UnitsConverter
    {
        internal static decimal  WeiToEth(decimal weiValue)
        {
            return weiValue / 1000000000000000000;
        }



    }
}
