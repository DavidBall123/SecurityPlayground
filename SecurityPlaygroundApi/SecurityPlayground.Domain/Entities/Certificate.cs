
namespace SecurityPlayground.Domain.Entities
{
    public class Certificate
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Acronym
        /// </summary>
        public string Acronym { get; set; }

        /// <summary>
        /// Gets or sets the organisation
        /// </summary>
        public string Organisation { get; set; }

        /// <summary>
        /// Gets or sets the subjects
        /// </summary>
        public ICollection<Subject> Subjects { get; set; }
    }
}
