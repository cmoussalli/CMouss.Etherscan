using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{
    public class NormalTransaction
    {
        public long BlockNumber { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Hash { get; set; }
        public string Nonce { get; set; }
        public string BlockHash { get; set; }
        public string TransactionIndex { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }
        public long Gas { get; set; }
        public long GasPrice { get; set; }
        public bool IsError { get; set; } = true;
        public string Txreceipt_status { get; set; }
        public string Input { get; set; }
        public string ContractAddress { get; set; }
        public long CumulativeGasUsed { get; set; }
        public long GasUsed { get; set; }
        public long Confirmations { get; set; }


    }
}
