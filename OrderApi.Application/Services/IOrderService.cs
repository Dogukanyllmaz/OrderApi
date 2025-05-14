using OrderApi.Application.DTOs;

namespace OrderApi.Application.Services
{
    public interface IOrderService
    {

        Task<IEnumerable<OrderDTO>> GetOrdersByClientId(string clientId);
        Task<OrderDetailsDTO> GetOrderDetails(int orderId);

    }
}
