using System;
using Exemple.DAL.EF;
using Exemple.DAL.Entities;
using Exemple.DAL.Interfaces;

namespace Exemple.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private MobileContext _db;
        private PhoneRepository phoneRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(string connectionString)
        {
            _db = new MobileContext(connectionString);
        }
        public IRepository<Phone> Phones
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new PhoneRepository(_db);
                return phoneRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_db);
                return orderRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}