using SecurityPlayground.Domain.Common;

namespace SecurityPlayground.Domain.Entities
{
    public class Subject : BaseAuditableEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        public int CertificateId { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the certificate. 
        /// </summary>
        public virtual Certificate Certificate { get; set; }
    }
}
