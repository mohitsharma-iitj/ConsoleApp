using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace CollectionDemo
{
    public class ProcessLog
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }

    public class Table
    {
        public string TableName { get; set; }
        public List<string> Columns { get; set; } = new();
    }

    public class Step
    {
        public string StepName { get; set; }
        public Action Execute { get; set; }
    }

    public class ProcessLogCollection : Collection<ProcessLog>
    {
        public void AddLog(string message)
        {
            this.Add(new ProcessLog
            {
                Timestamp = DateTime.Now,
                Message = message
            });
        }

        public void PrintAll()
        {
            foreach (var log in this)
            {
                Console.WriteLine($"[{log.Timestamp}] {log.Message}");
            }
        }
    }

    public class TableCollection : Collection<Table>
    {
        public Table? GetTableByName(string name) => this.FirstOrDefault(t => t.TableName == name);
    }

    public class StepCollection : Collection<Step>
    {
        public void RunAll()
        {
            foreach (var step in this)
            {
                Console.WriteLine($"Running: {step.StepName}");
                step.Execute?.Invoke();
            }
        }
    }

    public class CustomNameCollection : Collection<string>
    {
        protected override void InsertItem(int index, string item)
        {
            // Enforce uppercase before adding
            base.InsertItem(index, item.ToUpper());
        }
    }

    public static class CustomCollections
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Custom Collections ===");

            // override Example 
            var names = new CustomNameCollection();
            names.Add("alice");
            names.Add("bob");

            foreach (var name in names)
                Console.WriteLine(name); 

            // ProcessLogCollection
            var logs = new ProcessLogCollection();
            logs.AddLog("Started application.");
            logs.AddLog("Connected to database.");
            logs.PrintAll();

            // TableCollection
            var tables = new TableCollection();
            tables.Add(new Table { TableName = "Users", Columns = { "Id", "Name", "Email" } });
            tables.Add(new Table { TableName = "Orders", Columns = { "OrderId", "UserId", "Amount" } });

            var userTable = tables.GetTableByName("Users");
            Console.WriteLine("Columns in 'Users' table:");
            userTable?.Columns.ForEach(Console.WriteLine);

            // StepCollection
            var steps = new StepCollection();
            steps.Add(new Step { StepName = "Step 1", Execute = () => Console.WriteLine("Step 1 executed") });
            steps.Add(new Step { StepName = "Step 2", Execute = () => Console.WriteLine("Step 2 executed") });
            steps.RunAll();
        }
    }
}
