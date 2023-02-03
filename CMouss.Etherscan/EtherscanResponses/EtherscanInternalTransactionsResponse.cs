using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{

    public class EtherscanInternalTransactionsResponse : EtherscanBaseResponse
    {
        public List<EtherscanInternalTransactionsResponse_Transaction> result { get; set; }

    }

    public class EtherscanInternalTransactionsResponse_Transaction
    {

        public string blockNumber { get; set; }
        public string timeStamp { get; set; }
        public string hash { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string value { get; set; }
        public string contractAddress { get; set; }
        public string input { get; set; }
        public string type { get; set; }
        public string gas { get; set; }
        public string gasUsed { get; set; }
        public string traceId { get; set; }
        public string isError { get; set; }
        public string errCode { get; set; }

    }

}
