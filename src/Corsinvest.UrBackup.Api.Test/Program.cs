using System;

namespace Corsinvest.UrBackup.Api.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new UrBackupClient(false, "10.92.90.96", 55414);
            if (client.Login("test", "test"))
            {
                foreach (var item in client.Backups.Get().Response.Clients)
                {
                    Console.Out.WriteLine(item.Name);
                }
            }
        }
    }
}
