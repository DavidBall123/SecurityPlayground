using MediatR;
using Microsoft.EntityFrameworkCore;
using SecurityPlayground.Domain.Entities;
using SecurityPlayground.Application.Common.Interfaces;
using SecurityPlayground.Infrastructure.Identity;
using SecurityPlayground.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.Extensions.Options;

namespace SecurityPlayground.Infrastructure.Persistence;

public class CertificateContext : ApiAuthorizationDbContext<ApplicationUser>, ICertificateContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<Subject> Subjects => Set<Subject>();

    public CertificateContext(
        DbContextOptions<CertificateContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator, 
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

}

