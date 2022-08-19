using System.Text.Json;
using Tran = TransactionTest.Entity.Transaction;

var transactions = new List<Tran>();

while (true)
{

    Console.Write("Please, input command: ");
    var command = Console.ReadLine() ?? "";

    switch (command.ToLower())
    {
        case "add":
            {
                int id = 0;
                DateTime date;
                decimal amount = 0;

                do
                {
                    Console.Write("Input id: ");
                    int.TryParse(Console.ReadLine(), out id);
                }
                while (id == default(int));

                do
                {
                    Console.Write("Input date: ");
                    DateTime.TryParse(Console.ReadLine(), out date);
                }
                while (date == default(DateTime));

                do
                {
                    Console.Write("Input sum: ");
                    decimal.TryParse(Console.ReadLine(), out amount);
                }
                while (amount == default(decimal));

                var containElements = transactions.Where(x => x.Id == id);

                if (containElements.Any())
                {
                    var newId = transactions.OrderBy(x => x.Id).Select(x => x.Id).Last();

                    transactions.Add(new Tran
                    {
                        Id = newId,
                        TransactionDate = date,
                        Amount = amount
                    });
                    Console.WriteLine($"[OK] Id is duplicate, new id = {newId}");
                }
                else
                {
                    transactions.Add(new Tran
                    {
                        Id = id,
                        TransactionDate = date,
                        Amount = amount
                    });
                    Console.WriteLine("[OK]");
                }
                break;
            }

        case "get":
            {

                int id = 0;

                do
                {
                    Console.Write("Input id: ");
                    int.TryParse(Console.ReadLine(), out id);
                }
                while (id == default(int));

                var transaction = transactions.Find((x) => x.Id == id);

                if (transaction == null)
                {
                    Console.WriteLine("Search not give result");
                }
                else
                {
                    Console.WriteLine(JsonSerializer.Serialize(transaction));

                    Console.WriteLine("[OK]");
                }

                break;
            }

        case "cls":
            {
                Console.Clear();
                break;
            }

        case "exit":
            {
                Environment.Exit(0);
                break;
            }

        default:
            {
                Console.WriteLine("[ERROR] Command not supported");
                break;
            }
    }
    Console.WriteLine();
}