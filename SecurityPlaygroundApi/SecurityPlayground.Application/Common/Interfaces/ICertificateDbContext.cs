using Microsoft.EntityFrameworkCore;
using SecurityPlayground.Domain.Entities;


namespace SecurityPlayground.Application.Common.Interfaces;

public interface ICertificateDbContext
{
    DbSet<Certificate> Certificates { get; }

    DbSet<Subject> Subjects { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

