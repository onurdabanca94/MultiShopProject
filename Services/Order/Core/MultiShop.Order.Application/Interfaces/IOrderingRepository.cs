using MultiShopProject.Order.Domain.Entities;

namespace MultiShopProject.Order.Application.Interfaces;

public interface IOrderingRepository
{
    public List<Ordering> GetOrderingByUserId(string id);
}
