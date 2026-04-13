namespace FireFighterOperations.Models
{
    public class Einsatz
    {
        public int Id { get; set; }
        public string Typ { get; set; } 
        public string Einsatzleiter { get; set; }
        public string Adresse { get; set; }
        public DateTime Beginn { get; set; }
        public DateTime Ende { get; set; }
        public List<EingesetztesFahrzeug> Fahrzeuge { get; set; } = new List<EingesetztesFahrzeug>();
        public string SonstigeInformationen {  get; set; }
    }


}
