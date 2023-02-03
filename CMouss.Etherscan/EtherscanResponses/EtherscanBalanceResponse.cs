using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{


    public class EtherscanBalanceResponse:EtherscanBaseResponse
    {
        public string result { get; set; }

    }





    public class EtherscanBalancesResponse_Balance
    {
        public string account { get; set; }
        public string balance { get; set; }
    }
    public class EtherscanBalancesResponse:EtherscanBaseResponse
    {
        public List<EtherscanBalancesResponse_Balance> result { get; set; }

    }



}
