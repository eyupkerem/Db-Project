using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Transactions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Form2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            string isolationLevel = comboBox1.Text;
            int typeAUserNumber = (int)typeAUser.Value;
            int typeBUserNumber = (int)typeBUser.Value;

            Thread[] aThreads = new Thread[typeAUserNumber];
            Thread[] bThreads = new Thread[typeBUserNumber];

            for (int a = 0; a < typeAUserNumber; a++)
            {
                aThreads[a] = new Thread(()=>AThreadFunc(isolationLevel));
                aThreads[a].Start();
            }

            foreach (var thread in aThreads)
            {
                thread.Join();
            }

            MessageBox.Show("Tüm  A thread'ler tamamlandý.");

            for (int b = 0; b < typeBUserNumber; b++)
            {
                bThreads[b] = new Thread(BThreadFunc);
                bThreads[b].Start(); // Her bir thread'e bir parametre ile baþlatma
            }

            foreach (var thread in aThreads)
            {
                thread.Join();
            }

            MessageBox.Show("Tüm  B thread'ler tamamlandý.");
            MessageBox.Show(isolationLevel);

        }


        public void AThreadFunc(string isolationLevel)
        {
            int ThreadADeadlock = 0;
            DateTime beginTime = DateTime.Now;
            SqlConnection sql = null;
            Random rand = new Random();
         for(int i = 0;i<3;i++) { 
            try
            {

                    // Conenction Strgin içeri 
                sql = new SqlConnection("" );
                sql.Open();


                System.Data.IsolationLevel transactionIsolationLevel;
                if (!Enum.TryParse(isolationLevel, out transactionIsolationLevel))
                {
                    // Geçersiz izolasyon seviyesi seçilirse varsayýlaný kullan
                    transactionIsolationLevel = System.Data.IsolationLevel.ReadCommitted;
                    MessageBox.Show($"Geçersiz izolasyon seviyesi! {isolationLevel}. Varsayýlan olarak READ COMMITTED kullanýlýyor.");
                }

                // Ýþlem baþlat (izolasyon seviyesi parametre olarak)
                SqlTransaction transaction = sql.BeginTransaction(transactionIsolationLevel);



                    //   if (rand.NextDouble() < 0.5)
                    updateQuery(transaction, "20110101", "20111231");

              //  if (rand.NextDouble() < 0.5)
                    updateQuery(transaction, "20120101", "20121231");

              //  if (rand.NextDouble() < 0.5)
                    updateQuery(transaction, "20130101", "20131231");

              //  if (rand.NextDouble() < 0.5)
                    updateQuery(transaction, "20140101", "20141231");

                if (rand.NextDouble() < 0.5)
                    updateQuery(transaction, "20150101", "20151231");

                transaction.Rollback();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SQL sorgusu sýrasýnda hata oluþtu: " + ex.Message);
                Console.WriteLine(ex.Message );
            }
            finally
            {
                if (sql != null)
                {
                    sql.Close();
                }
            }
        } 

            Console.WriteLine("Konsol");
            MessageBox.Show("Thread a çalýþýyor");

            DateTime endTime = DateTime.Now;
            TimeSpan elapsed = endTime - beginTime;

            MessageBox.Show("Geçen süre A: " + elapsed.ToString());
        }

        static void updateQuery(SqlTransaction transaction , string beginDate , string endDate)
        {
            string query = @"UPDATE Sales.SalesOrderDetail
                        SET UnitPrice = UnitPrice * 10.0 / 10.0
                        WHERE UnitPrice > 100
                        AND EXISTS (
                            SELECT * FROM Sales.SalesOrderHeader
                            WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID
                            AND Sales.SalesOrderHeader.OrderDate BETWEEN @BeginDate AND @EndDate
                            AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
            SqlCommand command = new SqlCommand(query, transaction.Connection, transaction);
            command.Parameters.AddWithValue("@BeginDate", beginDate);
            command.Parameters.AddWithValue("@EndDate", endDate);
            command.ExecuteNonQuery();
        }

        public void BThreadFunc()
        {
            MessageBox.Show("Thread b is working");
        }


        private void Form1_Load(object sender, EventArgs e){}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void numericUpDown1_ValueChanged(object sender, EventArgs e){}
    }
}
