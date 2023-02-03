using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{
    public class ERC721Transaction
    {
        public long BlockNumber { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Hash { get; set; }
        public string Nonce { get; set; }
        public string BlockHash { get; set; }
        public string From { get; set; }
        public string ContractAddress { get; set; }
        public string To { get; set; }
        public string TokenID { get; set; }
        public string TokenName { get; set; }
        public string TokenSymbol { get; set; }
        public decimal TokenDecimal { get; set; }
        public string TransactionIndex { get; set; }
        public long Gas { get; set; }
        public long GasPrice { get; set; }
        public long GasUsed { get; set; }
        public long CumulativeGasUsed { get; set; }
        public string Input { get; set; }
        public long Confirmations { get; set; }
    }
}
