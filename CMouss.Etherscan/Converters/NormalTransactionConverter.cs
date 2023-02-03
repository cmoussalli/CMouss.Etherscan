using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Etherscan
{
    public static class NormalTransactionConverter
    {
        public static NormalTransaction Convert(EtherscanNormalTransactionsResponse_Transaction sourceData)
        {
            NormalTransaction result = new NormalTransaction();
            result.BlockNumber = long.Parse( sourceData.blockNumber);
            result.TimeStamp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(sourceData.timeStamp));
            result.Hash = sourceData.hash;
            result.Nonce = sourceData.nonce;
            result.BlockHash = sourceData.blockHash;
            result.TransactionIndex = sourceData.transactionIndex;
            result.From = sourceData.from;
            result.To = sourceData.to;
            result.Value = UnitsConverter.WeiToEth( decimal.Parse(sourceData.value));
            result.Gas = long.Parse(sourceData.gas);
            if (sourceData.isError == "0")
            {
                result.IsError = false;
            }
            result.Txreceipt_status = sourceData.txreceipt_status;
            result.Input = sourceData.input;
            result.ContractAddress = sourceData.contractAddress;
            result.CumulativeGasUsed = long.Parse(sourceData.cumulativeGasUsed);
            result.GasUsed = long.Parse(sourceData.gasUsed);
            result.Confirmations = long.Parse(sourceData.confirmations);
            return result;
        }

        public static List<NormalTransaction> Convert(List<EtherscanNormalTransactionsResponse_Transaction> sourceData)
        {
            List<NormalTransaction> result = new();
            foreach (EtherscanNormalTransactionsResponse_Transaction item in sourceData)
            {
                //try
                //{
                    NormalTransaction o = Convert(item);
                    
                    result.Add(o);
                //}
                //catch (Exception ex) { }
            }
            return result;
        }


    }
}
