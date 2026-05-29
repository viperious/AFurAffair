using AFurAffair.Web.Models;

namespace AFurAffair.Web.Services;

public class SalonInfoService : ISalonInfoService
{
    private readonly IConfiguration _config;
    public SalonInfoService(IConfiguration config) { _config = config; }

    public string BusinessName => "A Fur Affair Pet Salon";
    public string Tagline => "The Finest Pet Grooming for Your Fur Babies";
    public string Address => "4930 W 6200 S, Kearns, UT 84118 (next to Subway)";
    public string AddressShort => "4930 W 6200 S, Kearns, UT 84118";
    public string Phone => "(801) 969-7555";
    public string PhoneTel => "+18019697555";
    public string Email => "afuraffairpetsalon@gmail.com";
    public string FacebookUrl => "https://www.facebook.com/afuraffairpetsalon/";
    public string MoeGoBookingUrl =>
        _config["Salon:MoeGoBookingUrl"]
        ?? "https://booking.moego.pet/ol/AfurAffairPetSalonKearns/landing";

    public IReadOnlyList<GroomingService> Services { get; } = new List<GroomingService>
    {
        new("Teeth Cleaning", "tooth",
            "Professional brushing — non-surgical, no anesthesia, all natural. A fresher pup in one visit.",
            26m, "maintenance only", IsFeatured: true),
        new("Full Groom", "scissors",
            "Bath, blow-dry, brush-out, breed-appropriate haircut from Cesar, ears, nails, and a kerchief to finish.",
            null, "from $55 / small dog"),
        new("Bath & Brush", "bath",
            "Warm bath, deep brush-out, blow-dry, ears cleaned, nails trimmed. The works minus the haircut.",
            null, "from $35 / small dog"),
        new("Pawdicure", "paw",
            "Nail trim and file. Quick, calm, usually under 15 minutes. Walk-ins welcome.",
            15m, ""),
        new("De-Shedding", "shed",
            "Specialty treatment that reduces shedding by up to 90%. Your couch will thank you.",
            45m, "from"),
        new("Anal Glands", "drop",
            "Quick, professional expression. Add-on to any service or book on its own.",
            15m, "")
    };

    public IReadOnlyList<DaycarePackage> DaycarePackages { get; } = new List<DaycarePackage>
    {
        new("Half Day of Daycare", 17m, "/ day"),
        new("Full Day of Daycare", 23m, "/ day"),
        new("5 Days of Daycare", 90m, "/ pack"),
        new("10 Days of Daycare", 165m, "/ pack"),
        new("20 Days of Daycare", 250m, "/ pack"),
        new("30 Days of Daycare", 335m, "/ pack"),
        new("Monthly Unlimited", 290m, "/ month")
    };

    public IReadOnlyList<Testimonial> Testimonials { get; } = new List<Testimonial>
    {
        new("Cesar was able to book me within a week and reasonably priced. My golden came out looking spectacular!", "Sarah M.", 5),
        new("The groomer is so patient — even when my dog doesn't want his legs done, he takes breaks. They come out happy every time.", "Sophie L.", 5),
        new("We use them, we love them. They treat our Kodi so great! The place to go for grooming in this area.", "Local neighbor", 5)
    };

    public IReadOnlyList<(string Days, string Hours)> HoursOfOperation { get; } = new List<(string, string)>
    {
        ("Mon – Wed", "9:00 AM – 5:00 PM"),
        ("Thu – Fri", "9:00 AM – 8:00 PM"),
        ("Saturday", "9:00 AM – 8:00 PM"),
        ("Sunday", "9:00 AM – 3:00 PM")
    };
}
