namespace DBManager.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<KeyValuePairsContext>();

                    // Get the record with the specified key
                    string keyToDelete = "00e9l71w76";
                    var record = await context.KeyValuePairs.FindAsync(keyToDelete);

                    if (record != null)
                    {
                        // Delete the record from the database
                        context.KeyValuePairs.Remove(record);

                        // Save the changes
                        await context.SaveChangesAsync();
                    }

                }

                // Wait for one hour
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}