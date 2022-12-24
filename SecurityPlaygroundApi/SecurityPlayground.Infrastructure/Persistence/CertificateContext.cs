using MediatR;
using Microsoft.EntityFrameworkCore;
using SecurityPlayground.Domain.Entities;
using SecurityPlayground.Application.Common.Interfaces;
using SecurityPlayground.Infrastructure.Identity;
using SecurityPlayground.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

namespace SecurityPlayground.Infrastructure.Persistence;

public class CertificateContext : ApiAuthorizationDbContext<ApplicationUser>, ICertificateDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<Subject> Subjects => Set<Subject>();

    public CertificateContext(DbContextOptions<CertificateContext> options, IMediator mediator, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


        
    }

}

