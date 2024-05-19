using EasyPCIBackend.Data;
using EasyPCIBackend.Interfaces.Repositories;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Repositories
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext) {}

        public void CreateCard(Card Card) => Create(Card);

        public Card GetCard(Guid CardId) => FindByCondition(x => x.Id == CardId, false).First();

        public IEnumerable<Card> GetCards(bool trackChanges) => FindAll(trackChanges).ToList();

        public IEnumerable<Card> GetCardsByString(string search, bool trackChanges) => FindByCondition(x => x.CardNumber.Contains(search), trackChanges).ToList();

    }
}
