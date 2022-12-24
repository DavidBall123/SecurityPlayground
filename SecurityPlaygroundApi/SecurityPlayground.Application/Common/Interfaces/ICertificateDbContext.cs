using Microsoft.EntityFrameworkCore;
using SecurityPlaygroundApi.;

namespace SecurityPlayground.Application.Common.Interfaces;

internal interface ICertificateDbContext
{
    DbSet<Certificate> Certificates { get; }

    DbSet<Subject> Subjects { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

