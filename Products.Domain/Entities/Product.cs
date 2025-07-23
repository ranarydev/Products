namespace Products.Domain.Entities;

public class Product
{
    /// <summary>
    /// Unique ID
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Category: Bath & Body, Fragrance, Hair care, Makeup, Nails, Skin care, Tools & accessories
    /// </summary>
    public int CategoryID { get; set; }

    /// <summary>
    /// Express, Standard
    /// </summary>
    public int ShippingOption { get; set; }

    /// <summary>
    /// Brand: L'Oreal Paris, E.L.F., CeraVe, Maybelline, La Roche-Posay, Oral-B
    /// </summary>
    public int BrandID { get; set; }

    /// <summary>
    /// 1 to 5 stars
    /// </summary>
    public int CustomerReview { get; set; }

    /// <summary>
    /// Discount: 5% off ... etc
    /// </summary>
    public double Discount { get; set; }

    /// <summary>
    /// Status: In store, Online, out of stock
    /// </summary>
    public int Status { get; set; }
}
