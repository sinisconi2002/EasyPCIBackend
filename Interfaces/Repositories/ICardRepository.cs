using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces.Repositories
{
    public interface ICardRepository
    {
        Card GetCard(Guid CardId);
        IEnumerable<Card> GetCards(bool trackChanges);
        IEnumerable<Card> GetCardsByString(string search, bool trackChanges);
        void CreateCard(Card Card);
    }
}
