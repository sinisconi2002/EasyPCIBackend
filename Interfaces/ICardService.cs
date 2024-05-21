﻿using EasyPCIBackend.Models;

namespace EasyPCIBackend.Interfaces
{
    public interface ICardService
    {
        Task<List<Card>> GetCards();
        Task<Card> GetCard(Guid cardId);
        Task<List<Card>> GetCardsBySearch(string search);
        Task AddCard(Card card);
    }
}
