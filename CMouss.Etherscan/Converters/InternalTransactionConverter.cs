using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{
    public static class InternalTransactionConverter
    {
        public static InternalTransaction Convert(EtherscanInternalTransactionsResponse_Transaction sourceData)
        {
            InternalTransaction result = new InternalTransaction();
            result.BlockNumber = long.Parse(sourceData.blockNumber);
            result.TimeStamp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(sourceData.timeStamp));
            result.Hash = sourceData.hash;
            result.From = sourceData.from;
            result.To = sourceData.to;
            result.Value = decimal.Parse(sourceData.value);
            result.ContractAddress = sourceData.contractAddress;
            result.Input = sourceData.input;
            result.Type = sourceData.type;
            result.Gas = long.Parse(sourceData.gas);
            result.GasUsed = long.Parse(sourceData.gasUsed);
            if (sourceData.traceId != null)
            {
                result.TraceId = long.Parse(sourceData.traceId);

            }

            if (sourceData.isError == "0")
            {
                result.IsError = false;
            }
            result.ErrCode = sourceData.errCode;
            return result;
        }

        public static List<InternalTransaction> Convert(List<EtherscanInternalTransactionsResponse_Transaction> sourceData)
        {
            List<InternalTransaction> result = new();
            foreach (EtherscanInternalTransactionsResponse_Transaction item in sourceData)
            {
                //try
                //{
                InternalTransaction o = Convert(item);

                result.Add(o);
                //}
                //catch (Exception ex) { }
            }
            return result;
        }


    }
}
