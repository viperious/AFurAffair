namespace AFurAffair.Web.Models;

public record GroomingService(
    string Name,
    string Icon,
    string Description,
    decimal? StartingPrice,
    string PriceNote,
    bool IsFeatured = false
);

public record DaycarePackage(
    string Name,
    decimal Price,
    string PriceUnit
);

public record Testimonial(
    string Quote,
    string Author,
    int Stars
);
