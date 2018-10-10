using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Exemple.DAL.EF;
using Exemple.DAL.Entities;
using Exemple.DAL.Interfaces;

namespace Exemple.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private MobileContext _db;

        public OrderRepository(MobileContext context)
        {
            this._db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.Include(o => o.Phone);
        }

        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            _db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return _db.Orders.Include(o => o.Phone).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order != null)
                _db.Orders.Remove(order);
        }
    }
}