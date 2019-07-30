using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PizzaAPI.Models.EntityRepository
{
    public class CardTypeRepository : ICardTypeRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public CardTypeRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<CardType> Add(CardType type)
        {
            try
            {
                APIDbContext.CardType.Add(type);
                await APIDbContext.SaveChangesAsync();
                var result = await APIDbContext.CardType.FindAsync(APIDbContext.CardType.Count());
                return result;
            }
            catch
            {
                return null;
            }
        }
        public async Task<CardType> Delete(int id)
        {
            try
            {
                CardType type = await APIDbContext.CardType.FindAsync(id);
                if (type != null)
                {
                    APIDbContext.CardType.Remove(type);
                    await APIDbContext.SaveChangesAsync();
                }
                return type;
            }
            catch
            {
                return null;
            }
        }
        public async Task<CardType> Get(int id)
        {
            try
            {
                CardType type = await APIDbContext.CardType.FindAsync(id);
                return type;
            }
            catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<CardType>> GetAll()
        {
            try
            {
                var type = await APIDbContext.CardType.ToListAsync<CardType>();
                return type;
            }
            catch
            {
                return null;
            }
        }
        public async Task<CardType> Update(CardType dto)
        {
            try
            {
                CardType type = await APIDbContext.CardType.FindAsync(dto.CardTypeId);
                type.Type = dto.Type;
                APIDbContext.CardType.Update(type).State = EntityState.Modified;
                await APIDbContext.SaveChangesAsync();
                return type;
            }
            catch
            {
                return null;
            }
        }
    }
}
