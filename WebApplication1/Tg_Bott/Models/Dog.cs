using Postgrest.Attributes;
using Postgrest.Models;

namespace Tg_Bott.Models
{
    [Table("Dogs")] // Supabase-dagi jadval nomi bilan bir xil bo'lishi shart
    public class Dog : BaseModel
    {
        [PrimaryKey("DogId", true)] // true - agar baza o'zi ID beradigan bo'lsa (Identity)
        public long DogId { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("TrainingLevel")]
        public string? TrainingLevel { get; set; }

        [Column("LifeSpan")]
        public string? LifeSpan { get; set; }

        [Column("Weight")]
        public string? Weight { get; set; }

        [Column("SpecialSkill")]
        public string? SpecialSkill { get; set; }

        [Column("PhotoUrl")]
        public string? PhotoUrl { get; set; }

        [Column("IsDeleted")]
        public bool IsBlocked { get; set; } = false; // Supabase ustuni nomi bilan bir xil bo'lishi kerak

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}