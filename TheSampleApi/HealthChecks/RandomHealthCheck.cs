using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TheSampleApi.HealthChecks
{
    public class RandomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            int randomResult = Random.Shared.Next(1, 4);

            return randomResult switch
            {
                1 => Task.FromResult(HealthCheckResult.Healthy("This is a test random service.")),
                2 => Task.FromResult(HealthCheckResult.Degraded("This is a test random service.")),
                3 => Task.FromResult(HealthCheckResult.Unhealthy("This is a test random service.")),
                _ => Task.FromResult(HealthCheckResult.Healthy("This is a test random service.")),
            };
        }
    }
}
