using System.ComponentModel.DataAnnotations;

namespace FireFighterOperations.Models
{
    public class Fahrzeug
    {
        [Key]
        public string Bezeichnung { get; set; }
        public int Sitzplätze { get; set; }
        
    }
}
