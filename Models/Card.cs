namespace EasyPCIBackend.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardHolder { get; set; }
        public string ExpirationDate { get; set; }
        public string CVVCode { get; set; }
    }
}
