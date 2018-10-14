using System.Collections.Generic;
using Exemple.BLL.ModelDto;

namespace Exemple.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDto orderDto);
        PhoneDto GetPhone(int? id);
        IEnumerable<PhoneDto> GetPhones();
        void Dispose();
    }
}