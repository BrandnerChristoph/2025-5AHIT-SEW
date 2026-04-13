namespace FireFighterOperations.Models
{
    public class EingesetztesFahrzeug
    {
        public int Id { get; set; }
        public int Manschaftsstand { get; set; }
        public string Gruppenkommandant { get; set; }
        public Fahrzeug Fahrzeug { get; set; }
        public int? AnzahlAtemtraeger { get; set; }
        public DateTime? AusgeruecktAm { get; set; }
        public DateTime? EinsatzortAngekommenAm { get; set; }
        public DateTime? EinsatzbereitschaftwiederHergestelltAm { get; set; }
        //public bool Einsatzbereit { get { return EinsatzbereitschaftwiederHergestelltAm < DateTime.Now && EinsatzbereitschaftwiederHergestelltAm > AusgeruecktAm; } }
       
    }
}
