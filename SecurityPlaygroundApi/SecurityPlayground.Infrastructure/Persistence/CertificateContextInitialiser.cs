using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SecurityPlayground.Infrastructure.Persistence;

public class CertificateContextInitialiser
{
    private readonly ILogger<CertificateContextInitialiser> _logger;
    private readonly CertificateContext _context;

    public CertificateContextInitialiser(ILogger<CertificateContextInitialiser> logger, CertificateContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
}
