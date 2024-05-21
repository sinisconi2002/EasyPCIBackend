using EasyPCIBackend.Interfaces;
using EasyPCIBackend.Models;

namespace EasyPCIBackend.Services
{
    public class CardService : ICardService
    {
        private readonly IRepositoryManager _repository;

        public CardService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task AddCard(Card card)
        {
            card.Id = Guid.NewGuid();

            _repository.Cards.CreateCard(card);
            await _repository.Save();
        }

        public async Task<Card> GetCard(Guid cardId)
        {
            return _repository.Cards.GetCard(cardId);

        }

        public async Task<List<Card>> GetCards()
        {
            return _repository.Cards.GetCards(false).ToList();
        }

        public List<Card> GetCardsBySearch(string search)
        {
            return _repository.Cards.GetCardsByString(search, false).ToList();
        }
    }
}
