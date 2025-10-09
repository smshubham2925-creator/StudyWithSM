using System.ComponentModel.DataAnnotations;

namespace StudyWithMe.Models
{
    public class StudyMaterial
    {
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Topic { get; set; }

        public string Description { get; set; }

        public string? PdfUrl { get; set; }

    }
}
