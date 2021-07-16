using Microsoft.Extensions.Logging;
using Rookie.MyEcommerce.Entities.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.DataAccessors.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.OrderStatuses.AddRangeAsync(GetOrderStatusesAsync());
            await context.SaveChangesAsync();
        }

        private static IEnumerable<OrderStatus> GetOrderStatusesAsync()
        {
            return new List<OrderStatus>
            {
                new OrderStatus() { Status = "Tạo mới", Description = "Khách hàng tạo mới đơn hàng."},
                new OrderStatus() { Status = "Xác nhận", Description = "Đơn hàng được xác nhận."},
                new OrderStatus() { Status = "Đang vận chuyển", Description = "Đơn hàng đã chuyển giao cho đơn vị vận chuyển."},
                new OrderStatus() { Status = "Thành công", Description = "Khách hàng đã nhận và thanh toán đơn hàng."},
                new OrderStatus() { Status = "Hủy", Description = "Đơn hàng bị hủy."},
            };
        }
    }
}
