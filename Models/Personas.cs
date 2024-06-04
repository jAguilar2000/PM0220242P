using SQLite;

namespace PM0220242P.Models
{
    [Table("Personas")]
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombres { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Apellidos { get; set; } = string.Empty;
        public DateTime FechaNac { get; set; }
        [Unique]
        public string Telefono { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
    }
}
