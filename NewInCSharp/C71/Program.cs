using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using static System.Console;

namespace C71
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var results = Enumerable.Range(1, 40)
                .Select(input => (input,task: FibonacciAsync(input)))
                .ToArray();

            foreach (var item in results)
            {
                WriteLine($"Fib {item.input} = {await item.task}");
            }
            ReadLine();
        }

        private static Task<int> FibonacciAsync (int n, CancellationToken token = default)
        {
            return Task.Run(() => Fib(n).curr, token);

            (int curr,int prev) Fib(int i)
            {
                if (i is 0) return (1, 0);
                var (c, p) = Fib(i - 1);
                return (c + p, c);
            }
        }
    }
}
