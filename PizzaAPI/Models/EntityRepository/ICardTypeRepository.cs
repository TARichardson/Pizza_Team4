using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public interface ICardTypeRepository
    {
        APIDbContext APIDbContext { set; get; }

        Task<CardType> Add(CardType card);
        Task<CardType> Delete(int id);
        Task<CardType> Update(CardType card);
        Task<CardType> Get(int id);
        Task<IEnumerable<CardType>> GetAll();
    }
}
