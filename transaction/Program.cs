using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


// a ket csv filet belerakni egy nagy listaba decentralizalni 
namespace transaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                string exp = "expense.csv";
                string inc = "income.csv";
                var transactions = new List<Transaction>();
                transactions.AddRange(ReadFromCSVToTransaction(exp, TransactionType.Type.Expense));
                transactions.AddRange(ReadFromCSVToTransaction(inc, TransactionType.Type.Income));

                int id = 0;
                foreach (var item in transactions)
                {
                    id++;
                    item.Id = id;
                }

                Console.WriteLine("ID\tAmount\tDate\tType\t\tDescription");

                foreach (var t in transactions)
                {
                    Console.WriteLine(t.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba tortent a fajl beolvasasa kozben: {e.Message}" );
            }
            Console.WriteLine("Kész vagy te gyászfejú");
            Console.ReadLine();
        }
        private void ConnectionDatabase()
        {
            // Database connection logic here
            string connectionstring = "Server=localhost;Database=transactions;User Id=myUsername;Password=;";
        }
        static IEnumerable<Transaction> ReadFromCSVToTransaction(string path, TransactionType.Type type)
        {
            var transactions = new List<Transaction>();
            using (StreamReader sr = new StreamReader(path))
            {
                string header = sr.ReadLine(); // Skip header line
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    string[] parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        
                        
                        decimal amount = decimal.Parse(parts[1]);
                        DateTime date = DateTime.Parse(parts[0]);
                        string description = parts[2];
                        Transaction transaction = new Transaction(0, amount, date, type, description);
                        transactions.Add(transaction);
                    }
                    
                }
            }
            return transactions;
        }
    }
}

