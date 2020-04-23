using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Api.Configurations.HealthChecks
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        readonly string _connection;

        public SqlServerHealthCheck(string connection)
        {
            _connection = connection;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using (var connection = new SqlConnection(_connection))
                {
                    await connection.OpenAsync(cancellationToken);

                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT TOP 1 1 FROM SITUACAO";

                    return Convert.ToInt32(await command.ExecuteScalarAsync(cancellationToken)) > 0 ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
                }
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
