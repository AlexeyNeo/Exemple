using System.Collections.Generic;
using Exemple.BBL.ModelDto;

namespace Exemple.BBL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDto orderDto);
        PhoneDto GetPhone(int? id);
        IEnumerable<PhoneDto> GetPhones();
        void Dispose();
    }
}