# A Fur Affair Pet Salon — Marketing Site

## Project overview

This is a marketing/prototype site for **A Fur Affair Pet Salon**, a dog grooming business in Kearns, Utah. The site is a single-page Blazor Web App that showcases services, daycare packages, gallery, testimonials, and visit info. All "Book Now" CTAs deep-link to the salon's existing MoeGo booking system. The site does NOT implement its own booking backend — MoeGo handles scheduling.

**Status:** Prototype / mockup. Not yet deployed. Built to demo to the salon owner (Cesar) before any production work begins.

**Scope intent:** This is intentionally NOT a Clean Architecture solution. It is a single Web project with static data and no database. Keep it small. Do not add EF Core, Identity, multi-tenancy, or Domain/Application/Infrastructure layers unless explicitly asked.

## Stack

- **.NET 9** (`net9.0` target)
- **Blazor Web App** with **Auto** render mode (`InteractiveServer` + `InteractiveWebAssembly`)
- No database, no auth, no API — purely static-data marketing site
- Single NuGet dependency: `Microsoft.AspNetCore.Components.WebAssembly.Server` (9.0.0)
- Fonts: Fraunces (serif, display) + Inter (sans, body) via Google Fonts
- Icons: inline SVG in `ServiceIcon.razor` (no icon font dependency)

## Solution structure

```
AFurAffair.sln
AFurAffair.Web/
├── AFurAffair.Web.csproj
├── Program.cs                        # Wires up Razor Components + ISalonInfoService DI
├── appsettings.json                  # Contains Salon:MoeGoBookingUrl
├── appsettings.Development.json
├── Properties/launchSettings.json
├── Models/
│   └── Service.cs                    # GroomingService, DaycarePackage, Testimonial records
├── Services/
│   ├── ISalonInfoService.cs          # All salon-facing data exposed via this interface
│   └── SalonInfoService.cs           # Single source of truth for salon content
├── Components/
│   ├── App.razor                     # HTML host
│   ├── Routes.razor
│   ├── _Imports.razor                # All @using statements live here
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   ├── TopNav.razor              # Sticky nav with mobile hamburger
│   │   └── SiteFooter.razor
│   ├── Pages/
│   │   └── Home.razor                # @page "/", composes all sections
│   └── Sections/
│       ├── HeroSection.razor
│       ├── ServicesSection.razor
│       ├── ServiceIcon.razor         # Switch over Name parameter → inline SVG
│       ├── DaycareSection.razor
│       ├── GallerySection.razor      # Renders 8 GalleryTile components
│       ├── GalleryTile.razor         # SVG dog illustration placeholder
│       ├── AboutSection.razor
│       └── VisitSection.razor
└── wwwroot/
    └── app.css                       # ~640 lines, full design system
```

## Business facts (do not invent — these came from research)

- **Business name:** A Fur Affair Pet Salon
- **Owner / lead groomer:** Cesar
- **Address:** 4930 W 6200 S, Kearns, UT 84118 (next to Subway)
- **Phone:** (801) 969-7555
- **Facebook:** https://www.facebook.com/afuraffairpetsalon/
- **Booking system:** MoeGo. URL pattern guess: `https://booking.moego.pet/ol/AfurAffairPetSalonKearns/landing`
  - This URL is **not yet confirmed by the salon**. Stored in `appsettings.json` under `Salon:MoeGoBookingUrl` so it can be swapped without a rebuild.
- **Reputation:** ~88% recommend rate, 61+ reviews
- **Hours:** Mon–Wed 9–5, Thu–Fri 9–8, Sat 9–8, Sun 9–3

## Services (from the salon's flyer)

| Service | Price | Notes |
|---|---|---|
| Teeth Cleaning | from $26 | Non-surgical, no anesthesia. **Featured** ("Most loved") |
| Full Groom | from $55 / small dog | Bath, blow-dry, breed cut |
| Bath & Brush | from $35 / small dog | No haircut |
| Pawdicure (nail trim) | $15 | Walk-ins welcome |
| De-Shedding | from $45 | Reduces shedding up to 90% |
| Anal Glands | $15 | Add-on or standalone |

## Daycare packages (from the salon's price list)

| Package | Price |
|---|---|
| Half Day | $17 |
| Full Day | $23 |
| 5 Days | $90 |
| 10 Days | $165 |
| 20 Days | $250 |
| 30 Days | $335 |
| Monthly Unlimited | $290 (**Best value**, includes 2 free baths/year) |

All daycare days expire end of year. All pets must be up-to-date on vaccinations.

## Items not yet confirmed by the salon

These were best-guesses. Before going to production, get explicit confirmation:
1. The MoeGo booking URL slug (`AfurAffairPetSalonKearns`)
2. Email address (`afuraffairpetsalon@gmail.com` — inferred from business name)
3. The "10+ years in Kearns" stat in the hero
4. Hours, specifically Thu/Fri/Sat 8pm and Sun 3pm close
5. Whether Teeth Cleaning is actually the service they want featured, vs Full Groom

## Design system

### Brand colors (extracted from their actual logo)

```css
--red:       #c8102e   /* Primary brand red */
--red-deep:  #a30c24   /* Hover / pressed */
--red-dark:  #7a0918   /* Shadows / depth */
--ink:       #1a1a1a   /* Body text */
--ink-soft:  #555555   /* Secondary text */
--ink-muted: #777777   /* Tertiary text */
--cream:     #faf7f2   /* Page background */
--cream-deep:#f0ebe0   /* Card backgrounds */
--paper:     #ffffff   /* Card surfaces */
--line:      #e8e2d5   /* Borders */
--gold:      #d9a44a   /* Star ratings */
--sage:      #7a8c63   /* Success states */
```

### Typography

- **Display / headings:** Fraunces (variable serif, weight 800, optical size variable)
- **Body / UI:** Inter (weight 400–700)
- **`em` tags inside `h1`/`h2`** are deliberately styled — they render in Fraunces italic + brand red. This is the brand voice device. Use `<em>` for the one or two emphasized words per heading.

### Component patterns

- **Featured callouts:** `.featured-flag` red pill positioned top-right on cards. Applied via `IsFeatured` flag on service records or by name match on daycare packages (Monthly Unlimited).
- **Buttons:** `.btn` base + `.btn-primary` (red) or `.btn-ghost` (outlined). All include `<span class="arrow">→</span>` for hover translation.
- **Section pattern:** Each section is `<section id="..." class="X">` with a `.container` and `.section-head` (eyebrow + h2 + description) followed by the section's grid/content.
- **Mobile breakpoints:** 900px (layout shifts) and 820px (nav switches to hamburger).

### Animation guidelines

Animations are minimal and warm, never flashy:
- `pulse` on the hero eyebrow dot
- `gentle-rotate` on the AFA monogram (very slow, ±2deg)
- `float` on the floating badges
- Card hover lifts (`translateY(-4px)`) with shadow growth

Do not add scroll-triggered animations, parallax, or video backgrounds unless asked.

## Working with the data

**All salon content lives in `SalonInfoService.cs`.** To change a service, price, hour, or testimonial, edit the lists in that file. Components consume `ISalonInfoService` via `@inject` and iterate. Never hardcode salon data in component markup.

The interface exposes:
- `BusinessName`, `Tagline`, `Address`, `AddressShort`, `Phone`, `PhoneTel`, `Email`, `FacebookUrl`
- `MoeGoBookingUrl` (reads from `IConfiguration` → `appsettings.json`, fallback hardcoded)
- `Services: IReadOnlyList<GroomingService>`
- `DaycarePackages: IReadOnlyList<DaycarePackage>`
- `Testimonials: IReadOnlyList<Testimonial>`
- `HoursOfOperation: IReadOnlyList<(string Days, string Hours)>`

## Gallery — placeholder warning

The gallery currently uses **SVG dog illustrations**, not real photos. The variants are `doodle-cream`, `doodle-tan`, `poodle-black`, `poodle-white`, `terrier-tan`, each driving CSS color overrides in the gallery section of `app.css`.

When real photos arrive:
1. Drop them in `wwwroot/images/pets/` (e.g., `bailey.jpg`, `gin.jpg`)
2. Replace the `<svg>` block in `GalleryTile.razor` with `<img src="/images/pets/@(Name.ToLower()).jpg" alt="@Name" />`
3. Add `.gallery-tile img { width: 100%; height: 100%; object-fit: cover; }` to the gallery CSS
4. Keep the `.gallery-name` overlay — it works over photos with the existing text shadow

## Voice and copy guidelines

- **Warm, neighborhood, hand-crafted.** Not corporate, not veterinary, not slick agency.
- Use casual phrases ("goodest good boys & girls", "your couch will thank you", "spa day").
- Punctuation: use periods and commas, not em dashes or en dashes in copy (per Brian's writing style).
- The Facebook page has a documented sense of humor ("Nothing to see here, just dogs having the weeknight of your dreams" + dogs at a pizza party). It's okay to lean into that, sparingly.
- Do not write content that sounds like ChatGPT defaults: avoid "elevate", "seamless", "unlock", "in today's fast-paced world", etc.

## Running locally

```bash
cd AFurAffair
dotnet run --project AFurAffair.Web
```

Listens on `https://localhost:7080` and `http://localhost:5080` per `launchSettings.json`.

## Likely next requests

If asked to keep working, the most probable next tasks are:
1. **Wire up real photos** in the gallery (see Gallery section above)
2. **Add a contact form** that sends to `afuraffairpetsalon@gmail.com` (would need SMTP or a service like Resend/SendGrid)
3. **Split into multi-page** — Services, Daycare, About, Contact each on their own route
4. **SEO pass** — meta tags, OG images, structured data (LocalBusiness JSON-LD with hours, address, phone)
5. **Build a real AFA logo SVG** to replace the text-monogram in the hero and footer
6. **Deploy** — Azure App Service is the likely target (Brian's stack)
7. **Promo banner** for current coupons ($10 off Full Groom, $5 off Bath & Brush — visible on their flyer)
8. **Before/after section** — they post before/after photos regularly on Facebook

## What NOT to do without asking

- Do not add a database, ORM, or Identity
- Do not add Domain/Application/Infrastructure projects
- Do not introduce Tailwind, MudBlazor, or other UI frameworks — the design system is custom CSS for a reason (lightweight, brand-specific, no override fights)
- Do not change the brand red. `#c8102e` was matched to their actual logo.
- Do not write a custom booking flow — MoeGo owns that
- Do not invent business facts (pricing, hours, services). Anything new requires confirmation from the salon.
