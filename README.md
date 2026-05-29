# A Fur Affair Pet Salon — Marketing Site

Prototype marketing site for **A Fur Affair Pet Salon**, a dog grooming business in Kearns, Utah. Built to demo to the salon owner before production work begins.

## What this is

A single-page Blazor Web App showcasing services, daycare packages, gallery, testimonials, and visit info. All "Book Now" CTAs link out to the salon's existing MoeGo booking system. No database, no auth, no booking backend.

## Stack

- .NET 9 / Blazor Web App (Auto render mode)
- Custom CSS design system — no UI frameworks
- Google Fonts: Fraunces + Inter

## Running locally

```bash
dotnet run --project AFurAffair.Web
```

App runs at `https://localhost:7080` / `http://localhost:5080`.

## Business

- **Location:** 4930 W 6200 S, Kearns, UT 84118
- **Phone:** (801) 969-7555
- **Booking:** [MoeGo](https://booking.moego.pet/ol/AfurAffairPetSalonKearns/landing) (URL not yet confirmed with salon)
- **Facebook:** [afuraffairpetsalon](https://www.facebook.com/afuraffairpetsalon/)

## Editing content

All salon data (services, prices, hours, testimonials) lives in [AFurAffair.Web/Services/SalonInfoService.cs](AFurAffair.Web/Services/SalonInfoService.cs). The MoeGo booking URL is in [AFurAffair.Web/appsettings.json](AFurAffair.Web/appsettings.json) under `Salon:MoeGoBookingUrl`.

## Before going live

A few items need confirmation from the salon before this goes to production — see the "Items not yet confirmed" section in [CLAUDE.md](CLAUDE.md).
