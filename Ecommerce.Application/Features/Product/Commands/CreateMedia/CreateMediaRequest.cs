using Ecommerce.Application.Features.Product.Queries.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Product.Commands.CreateMedia;

public class CreateMediaRequest : IRequest<Unit>
{
    public int Priority { get; set; }
    public string Url { get; set; }
    public MediaType Type { get; set; }
}
