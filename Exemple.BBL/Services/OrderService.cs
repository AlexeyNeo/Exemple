using System;
using System.Collections.Generic;
using AutoMapper;
using Exemple.BLL.Infrastructure;
using Exemple.BLL.Interfaces;
using Exemple.BLL.ModelDto;
using Exemple.BLL.Models;
using Exemple.DAL.Entities;
using Exemple.DAL.Interfaces;

namespace Exemple.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }
 
        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDto orderDto)
        {
            Phone phone = Database.Phones.Get(orderDto.PhoneId);
 
            // валидация
            if (phone == null)
                throw new ValidationException("Телефон не найден","");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                PhoneId = phone.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
 
        public IEnumerable<PhoneDto> GetPhones()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Phone, PhoneDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Phone>, List<PhoneDto>>(Database.Phones.GetAll());
        }
 
        public PhoneDto GetPhone(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона","");
            var phone = Database.Phones.Get(id.Value);
            if (phone == null)
                throw new ValidationException("Телефон не найден","");
             
            return new PhoneDto { Company = phone.Company, Id = phone.Id, Name = phone.Name, Price = phone.Price };
        }
 
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}