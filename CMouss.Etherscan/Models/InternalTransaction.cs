using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{
    public class InternalTransaction
    {
        public long BlockNumber { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Hash { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }
        public string ContractAddress { get; set; }
        public string Input { get; set; }
        public string Type { get; set; }
        public long Gas { get; set; }
        public long GasUsed { get; set; }
        public long? TraceId { get; set; }
        public bool IsError { get; set; }
        public string ErrCode { get; set; }
    }
}
