using MediatR;
using System.Collections.Generic;
using Microsoft.Inventura.Web.ViewModels;

namespace Microsoft.Inventura.Web.Features.MyOrders
{
    public class GetMyOrders : IRequest<IEnumerable<OrderViewModel>>
    {
        public string UserName { get; set; }

        public GetMyOrders(string userName)
        {
            UserName = userName;
        }
    }
}
