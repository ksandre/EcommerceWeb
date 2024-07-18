using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Product.Commands.CreatePrice;

public class CreatePriceRequest : IRequest<Unit>
{
    public int MaxQuantity { get; set; }
    public decimal InitialPrice { get; set; }
    public decimal DiscountPrice { get; set; }
}
