namespace AppAssociados.Domain
{
    public class Dependente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Parentesco parentesco { get; set; }
        public Associado associado { get; set; }   
    }
}