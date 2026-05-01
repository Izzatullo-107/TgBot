namespace Tg_Bott.BotDTOs
{
    public class DogGetAllDTO
    {
        public long DogId { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? TrainingLevel { get; set; }

        public string? LifeSpan { get; set; }

        public string? Weight { get; set; }

        public string? SpecialSkill { get; set; }

        public string? PhotoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
