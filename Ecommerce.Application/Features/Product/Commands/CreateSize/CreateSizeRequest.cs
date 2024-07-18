using Ecommerce.Application.Features.Product.Commands.CreateColor;
using Ecommerce.Application.Features.Product.Commands.CreatePrice;
using Ecommerce.Application.Features.Product.Queries.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Product.Commands.CreateSize;
public class CreateSizeRequest : IRequest<Unit>
{
    public string SizeValue { get; set; }
    public string SizeUnit { get; set; }
    public CreatePriceRequest? Price { get; set; }
    public List<CreateColorRequest>? Colors { get; set; }
}
