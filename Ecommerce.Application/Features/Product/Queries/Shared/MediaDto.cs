﻿namespace Ecommerce.Application.Features.Product.Queries.Shared;

public class MediaDto
{
    public int MediaId { get; set; }
    public int Priority { get; set; }
    public string Url { get; set; }
    public MediaType Type { get; set; }
}

public enum MediaType
{
    Image,
    Video
}