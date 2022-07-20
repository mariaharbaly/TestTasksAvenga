using Newtonsoft.Json;
using TestTask1;

string text = System.IO.File.ReadAllText(@"C:\Users\garba\RiderProjects\TestTasksAvenga\TestTask1\Test task #1 - Pizzas (1) (1).json");

List<Pizza>? items = JsonConvert.DeserializeObject<List<Pizza>>(text);

var result = items.GroupBy(x => string.Join( ", ",  x.Toppings.OrderBy(y => y)))
    .Select(g => new { g.Key, Count = g.Count() })
    .OrderByDescending(x => x.Count);

Console.WriteLine("The most popular combinations of toppings: ");
foreach (var pizza in result.Take(20))
{
    Console.WriteLine($"{pizza.Key} - {pizza.Count}");
}

Console.ReadLine();