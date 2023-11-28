namespace ss_cron;

class Program
{
    static async Task Main(string[] args)
    {
        await CronJobScheduler.Start();

        // Keep the console application running
        Console.ReadLine();
    }
}
