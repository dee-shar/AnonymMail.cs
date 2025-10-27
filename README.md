# AnonymMail.cs
Web-API for [AnonymMail](https://anonymmail.net) which provides ability to create temporary email address for free

## Example
```cs
using AnonymMailApi;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new AnonymMail();
            string domains = await api.GetDomains();
            Console.WriteLine(domains);
        }
    }
}
```
