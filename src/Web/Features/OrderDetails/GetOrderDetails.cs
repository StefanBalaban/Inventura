using MediatR;
using Microsoft.Inventura.Web.ViewModels;

namespace Microsoft.Inventura.Web.Features.OrderDetails
{
    public class GetOrderDetails : IRequest<OrderViewModel>
    {
        public string UserName { get; set; }
        public int OrderId { get; set; }

        public GetOrderDetails(string userName, int orderId)
        {
            UserName = userName;
            OrderId = orderId;
        }
    }
}
