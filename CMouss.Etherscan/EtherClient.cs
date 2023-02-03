using System.Text.Json;

namespace CMouss.Etherscan
{





    public class EtherClient
    {
        #region Properties
        string apiKey = "";
        string baseURL = "https://api.etherscan.io/";

        #endregion



        #region Constructor
        public EtherClient(string etherscanApiKey)
        {
            apiKey = etherscanApiKey;

        }
        #endregion


        #region Behaviour

        #region Get Balance

        public async Task<decimal> GetBalanceAsync(string address)
        {
            decimal result = 0;
            try
            {
                HttpClient client = new HttpClient();
                string ps = "";
                ps = ps + "&module=account";
                ps = ps + "&action=balance";
                ps = ps + "&tag=latest";
                ps = ps + "&address=" + address;
                string resStr = await client.GetStringAsync(baseURL + "api?apikey=" + apiKey + ps);
                EtherscanBalanceResponse response = JsonSerializer.Deserialize<EtherscanBalanceResponse>(resStr);
                result = UnitsConverter.WeiToEth(Decimal.Parse(response.result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public decimal GetBalance(string address)
        {
            var eth = Task.Run(async () => GetBalanceAsync(address));
            eth.Wait();
            return eth.Result.Result;
        }
        #endregion

        #region Get Balances
        public async Task<List<AccountBalance>> GetBalancesAsync(List<string> addresses)
        {
            List<AccountBalance> result = new();
            try
            {
                HttpClient client = new HttpClient();
                string ps = "";
                ps = ps + "&module=account";
                ps = ps + "&action=balancemulti";
                ps = ps + "&tag=latest";
                ps = ps + "&address=" + string.Join(",", addresses);
                string resStr = await client.GetStringAsync(baseURL + "api?apikey=" + apiKey + ps);
                EtherscanBalancesResponse response = JsonSerializer.Deserialize<EtherscanBalancesResponse>(resStr);
                result = AccountBalanceConverter.Convert(response.result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<AccountBalance> GetBalances(List<string> addresses)
        {
            var eth = Task.Run(async () => GetBalancesAsync(addresses));
            eth.Wait();
            return eth.Result.Result;
        }
        #endregion



        #region Get Normal Transactions
        public async Task<List<NormalTransaction>> GetNormalTransactionsAsync(string address, long startBlock = 0, long endBlock = 99999999, long page = 1, long pagesize = 25, SortingMode sortingMode = SortingMode.Ascending)
        {
            List<NormalTransaction> result = new();
            try
            {
                HttpClient client = new HttpClient();
                string ps = "";
                ps = ps + "&module=account";
                ps = ps + "&action=txlist";
                ps = ps + "&startblock=" + startBlock.ToString();
                ps = ps + "&endblock=" + endBlock.ToString();
                ps = ps + "&page=" + page.ToString();
                ps = ps + "&offset=" + pagesize.ToString();
                if (sortingMode == SortingMode.Ascending)
                {
                    ps = ps + "&sort=" + "asc";
                }
                else
                {
                    ps = ps + "&sort=" + "desc";
                }

                ps = ps + "&address=" + address;
                string resStr = await client.GetStringAsync(baseURL + "api?apikey=" + apiKey + ps);
                EtherscanNormalTransactionsResponse response = JsonSerializer.Deserialize<EtherscanNormalTransactionsResponse>(resStr);
                result = NormalTransactionConverter.Convert(response.result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        #endregion

        #region Get Internal Transactions
        public async Task<List<InternalTransaction>> GetInternalTransactionsAsync(string address, long startBlock = 0, long endBlock = 99999999, long page = 1, long pagesize = 25, SortingMode sortingMode = SortingMode.Ascending)
        {
            List<InternalTransaction> result = new();
            try
            {
                HttpClient client = new HttpClient();
                string ps = "";
                ps = ps + "&module=account";
                ps = ps + "&action=txlist";
                ps = ps + "&startblock=" + startBlock.ToString();
                ps = ps + "&endblock=" + endBlock.ToString();
                ps = ps + "&page=" + page.ToString();
                ps = ps + "&offset=" + pagesize.ToString();
                if (sortingMode == SortingMode.Ascending)
                {
                    ps = ps + "&sort=" + "asc";
                }
                else
                {
                    ps = ps + "&sort=" + "desc";
                }

                ps = ps + "&address=" + address;
                string resStr = await client.GetStringAsync(baseURL + "api?apikey=" + apiKey + ps);
                EtherscanInternalTransactionsResponse response = JsonSerializer.Deserialize<EtherscanInternalTransactionsResponse>(resStr);
                result = InternalTransactionConverter.Convert(response.result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        #endregion

        #region Get Internal Transactions by Transactions Hash
        public async Task<List<InternalTransaction>> GetInternalTransactionsAsync(string txhash)
        {
            List<InternalTransaction> result = new();
            try
            {
                HttpClient client = new HttpClient();
                string ps = "";
                ps = ps + "&module=account";
                ps = ps + "&action=txlistinternal";
                ps = ps + "&txhash=" + txhash;
                string resStr = await client.GetStringAsync(baseURL + "api?apikey=" + apiKey + ps);
                EtherscanInternalTransactionsResponse response = JsonSerializer.Deserialize<EtherscanInternalTransactionsResponse>(resStr);
                result = InternalTransactionConverter.Convert(response.result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        #endregion

        #region Get ERC721 token transfers
        public async Task<List<ERC721Transaction>> GetERC721TokenTransactionsAsync(string address, string? contractAddress = null, long startBlock = 0, long endBlock = 99999999, long page = 1, long pagesize = 25, SortingMode sortingMode = SortingMode.Ascending)
        {
            List<ERC721Transaction> result = new();
            try
            {
                HttpClient client = new HttpClient();
                string ps = "";
                ps = ps + "&module=account";
                ps = ps + "&action=tokennfttx";
                ps = ps + "&startblock=" + startBlock.ToString();
                ps = ps + "&endblock=" + endBlock.ToString();
                ps = ps + "&page=" + page.ToString();
                ps = ps + "&offset=" + pagesize.ToString();
                ps = ps + "&address=" + address;
                if (sortingMode == SortingMode.Ascending)
                {
                    ps = ps + "&sort=" + "asc";
                }
                else
                {
                    ps = ps + "&sort=" + "desc";
                }

                if (contractAddress != null)
                {
                    ps = ps + "&contractaddress=" + contractAddress;
                }
                string resStr = await client.GetStringAsync(baseURL + "api?apikey=" + apiKey + ps);
                EtherscanERC721TransactionsResponse response = JsonSerializer.Deserialize<EtherscanERC721TransactionsResponse>(resStr);
                result = ERC721TransactionConverter.Convert(response.result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        #endregion

        #endregion

    }
}