namespace CMouss.Etherscan.TesterApp
{
    public partial class Form1 : Form
    {
        Etherscan.EtherClient eth = new("");
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            //decimal res = await eth.GetBalanceAsync(textBox2.Text);
            txtBalance.Text = eth.GetBalance(textBox2.Text).ToString();


            List<string> wallets = new List<string>() { textBox2.Text, "0x5C12BAc5ff8E6BadC0a807fbe8aa11EDDe8b663e", "0xD73608582287F1fB17c1BD0C092537De3a1Cd068" };
            List<AccountBalance> r = eth.GetBalances(wallets);

            List<NormalTransaction> normalTransactions = await eth.GetNormalTransactionsAsync(textBox2.Text, 0, 99999999, 1, 25, SortingMode.Ascending);
            dataGridView1.DataSource = normalTransactions;




        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            txtBalance.Text = eth.GetBalance(textBox2.Text).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            eth = new(textBox1.Text);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            List<InternalTransaction> InternalTransactions = await eth.GetInternalTransactionsAsync(textBox4.Text, 0, 99999999, 1, 25, SortingMode.Ascending);
            dataGridView2.DataSource = InternalTransactions;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            List<NormalTransaction> normalTransactions = await eth.GetNormalTransactionsAsync(textBox3.Text, 0, 99999999, 1, 25, SortingMode.Ascending);
            dataGridView1.DataSource = normalTransactions;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            List<ERC721Transaction> eRC721Transactions = await eth.GetERC721TokenTransactionsAsync(textBox5.Text,null,0,9999999999,1,25, SortingMode.Ascending);
            dataGridView3.DataSource = eRC721Transactions;


        }
    }
}