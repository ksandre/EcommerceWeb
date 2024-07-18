using Ecommerce.Application.Features.Product.Commands.CreateMedia;
using Ecommerce.Application.Features.Product.Commands.CreatePrice;
using Ecommerce.Application.Features.Product.Queries.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Product.Commands.CreateColor;

public class CreateColorRequest : IRequest<Unit>
{
    public string Hex { get; set; }
    public string Name { get; set; }
    public CreatePriceRequest? Price { get; set; }
    public List<CreateMediaRequest>? Media { get; set; }
}
