🔑 Slide 6: Dictionary<K,V>
🔹 Use-case:
Fast lookups using key-value pairs.

🔹 Features:
Unique keys.

O(1) lookup performance.

🔹 Example:
csharp
Copy
Edit
Dictionary<int, string> users = new Dictionary<int, string>();
users.Add(1, "Alice");
users[2] = "Bob";


📚 Slide 7: Collection<T>
🔹 Use-case:
Base class for creating custom collections.

🔹 Features:
Extends IList<T>.

Provides methods to override for customization (e.g., InsertItem, SetItem).

🔹 Example:
csharp
Copy
Edit
Collection<string> logs = new Collection<string>();
logs.Add("Started process");


🧰 Slide 8: Custom Collections Overview
Extend .NET collections to enforce business rules or specialized behavior.

Often inherit from Collection<T>, List<T>, or implement interfaces like IEnumerable<T>.

🧾 Slide 9: Custom Collection: ProcessLogCollection
🔹 Use-case:
Manage process logs with additional filtering or formatting.

🔹 Sample Class:
csharp
Copy
Edit
public class ProcessLogCollection : Collection<string>
{
    public void AddInfo(string message) => Add($"INFO: {message}");
    public void AddError(string message) => Add($"ERROR: {message}");
}
📊 Slide 10: Custom Collection: TableCollection
🔹 Use-case:
Represent a list of structured table rows in memory.

🔹 Sample Class:
csharp
Copy
Edit
public class TableRow
{
    public int Id { get; set; }
    public string Data { get; set; }
}

public class TableCollection : Collection<TableRow>
{
    public TableRow FindById(int id) => this.FirstOrDefault(row => row.Id == id);
}
🧱 Slide 11: Custom Collection: StepCollection
🔹 Use-case:
Represent a sequence of steps in a process flow (workflow engine, pipelines).

🔹 Sample Class:
csharp
Copy
Edit
public class Step
{
    public string Name { get; set; }
    public int Order { get; set; }
}

public class StepCollection : Collection<Step>
{
    public IEnumerable<Step> OrderedSteps() => this.OrderBy(s => s.Order);
}


🧩 Slide 12: Comparison Table
Feature	List<T>	Dictionary<K,V>	Collection<T>	Custom Collection
Type Safety	✅	✅	✅	✅
Indexing	✅	❌	✅	✅ (if implemented)
Key Lookup	❌	✅	❌	✅ (if added)
Custom Behavior	❌	❌	✅	✅

✅ Difference: Collection<T> vs ArrayList
Feature	Collection<T>	ArrayList
Namespace	System.Collections.ObjectModel	System.Collections
Generic	✅ Yes (T is strongly typed)	❌ No (stores object, needs casting)
Type Safety	✅ Yes – avoids runtime errors	❌ No – requires type casting
Performance	✅ Better (no boxing/unboxing)	❌ Slower with value types (boxing needed)
Extensibility	✅ Designed to be extended (override methods)	❌ Limited extensibility
Usage Recommendation	✅ Preferred in modern .NET apps	🚫 Legacy – avoid in new development
LINQ Support	✅ Fully supported	❌ Indirect, requires Cast<T>() first


✅ List<T> vs Collection<T> in C#
Feature	List<T>	Collection<T>
Namespace	System.Collections.Generic	System.Collections.ObjectModel
Inherits From	Collection<T> (indirectly from IList<T>)	ObjectModel.Collection<T> directly
Type Safety	✅ Yes	✅ Yes
Dynamic Resizing	✅ Yes – has internal array resizing	✅ Yes – uses underlying list internally
Extensibility	❌ No virtual methods – hard to customize behavior	✅ Yes – override methods like InsertItem, etc.
Performance	⚡ Slightly faster (more optimized)	🐢 Slightly slower (more abstracted)
Usage Scenario	General-purpose collection for everyday use	Base class for creating custom collections
LINQ Support	✅ Yes	✅ Yes
Serialization-friendly	✅ (especially with DTOs)	✅ (less commonly used in APIs)


✅ 2. LINQ (Language Integrated Query)
LINQ lets you write query-like syntax over collections (SQL-style) using method or query syntax.

a) Query Expressions
SQL-like syntax over collections.

csharp
Copy
Edit
var result = from name in names
             where name.StartsWith("A")
             select name;
b) Where()
Filters a sequence based on a predicate.

csharp
Copy
Edit
var filtered = names.Where(n => n.StartsWith("A"));
c) Select()
Projects each element into a new form.

csharp
Copy
Edit
var nameLengths = names.Select(n => n.Length);
d) ToList()
Converts an IEnumerable<T> to List<T>

csharp
Copy
Edit
List<string> filteredList = names.Where(n => n.Contains("a")).ToList();
e) GroupBy()
Groups elements by a key.

csharp
Copy
Edit
var grouped = names.GroupBy(n => n.Length);
foreach (var group in grouped)
{
    Console.WriteLine($"Length: {group.Key}");
    foreach (var name in group)
        Console.WriteLine(name);
}
