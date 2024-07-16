using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Product;

public class Media
{
    public int MediaId { get; set; }
    public int Priority { get; set; }
    public string Url { get; set; }
    public MediaType Type { get; set; }

    public int? ColorId { get; set; }
    public virtual Color? Color { get; set; }
}

public enum MediaType
{
    Image,
    Video
}