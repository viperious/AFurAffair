using AFurAffair.Web.Models;

namespace AFurAffair.Web.Services;

public interface ISalonInfoService
{
    string BusinessName { get; }
    string Tagline { get; }
    string Address { get; }
    string AddressShort { get; }
    string Phone { get; }
    string PhoneTel { get; }
    string Email { get; }
    string FacebookUrl { get; }
    string MoeGoBookingUrl { get; }
    IReadOnlyList<GroomingService> Services { get; }
    IReadOnlyList<DaycarePackage> DaycarePackages { get; }
    IReadOnlyList<Testimonial> Testimonials { get; }
    IReadOnlyList<(string Days, string Hours)> HoursOfOperation { get; }
}
