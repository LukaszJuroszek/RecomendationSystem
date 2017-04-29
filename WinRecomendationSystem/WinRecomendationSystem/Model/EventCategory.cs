using System.ComponentModel.DataAnnotations.Schema;

namespace WinRecomendationSystem.Model
{
    public class EventCategory
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
