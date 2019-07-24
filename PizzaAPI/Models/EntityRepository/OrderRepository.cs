﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public class OrderRepository : IOrderRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public OrderRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        //public void Add(Order order)
        //{
        //    APIDbContext.Orders.Add(order);
        //    APIDbContext.SaveChanges();
        //}

        //public Order Delete(int id)
        //{
        //    Order order = APIDbContext.Orders.Find(id);
        //    if (order != null)
        //    {
        //        APIDbContext.Orders.Remove(order);
        //        APIDbContext.SaveChanges();
        //    }
        //    return order;
        //}

        public async Task<Order> GetOrder(int id)
        {

            var order = await APIDbContext.Orders.Include("Customer").Where(s => s.Customer.CustomerID == id && s.Pay == false).FirstOrDefaultAsync();

            if (order == null)
            {
                order = new Order()
                {
                    Pay = false,
                    TotalAmount = 0,
                    Customer = await APIDbContext.Customers.FindAsync(id)

                };
                APIDbContext.Orders.Add(order);
                await APIDbContext.SaveChangesAsync();

            }
            return order;
        }


        public List<Order> GetHistory(int customerId)
        {
            var qu = APIDbContext.Orders.Where(b => b.Customer.CustomerID == customerId && b.Pay == true).ToList();
            return qu;
        }
        public List<Item> Transationsumbit(int Id)
        {
            var transaction = APIDbContext.Items.Include("Order").Where(s => s.Order.OrderID == Id).ToList();
            var TotalAmount = transaction[0].Order.TotalAmount;
            return transaction;


        }
    }
}

