using MultiShopProject.Order.Application.Interfaces;
using MultiShopProject.Order.Domain.Entities;
using MultiShopProject.Order.Persistence.Context;

namespace MultiShopProject.Order.Persistence.Repositories;

public class OrderingRepository : IOrderingRepository
{
    private readonly OrderContext _orderContext;

    public OrderingRepository(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public List<Ordering> GetOrderingByUserId(string id)
    {
        var values = _orderContext.Orderings.Where(x => x.UserId == id).ToList();
        return values;
    }
}
