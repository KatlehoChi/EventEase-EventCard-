# EventEase

EventEase is a Blazor Web App for discovering events, registering attendees, and tracking participation during a user session. It uses a small in-memory catalog so the application can be explored without a database or external services.

## Requirements

- .NET SDK 10.0 or later
- A modern browser

Check the installed SDK with:

```powershell
dotnet --version
```

## Run locally

From the `EventEase-EventCard-` project directory:

```powershell
dotnet restore
dotnet run --project .\EventEase.csproj
```

Open the URL shown by ASP.NET Core, usually `http://localhost:5246` or the HTTPS URL from the launch profile.

To create a production build:

```powershell
dotnet build .\EventEase.csproj -c Release
```

## Application routes

| Route            | Purpose                                  |
| ---------------- | ---------------------------------------- |
| `/`              | EventEase home page                      |
| `/events`        | Browse upcoming events                   |
| `/events/{id}`   | View event details and attendance status |
| `/register/{id}` | Register for an event                    |
| `/not-found`     | Friendly fallback for unknown routes     |

## Features

- Reusable event cards backed by validated mock event data.
- Virtualized event browsing with stable keyed rendering for larger catalogs.
- Event details, registration, and not-found routing.
- Registration validation for required names, name length, and email format.
- Scoped `UserSessionState` for continuity across navigation in a Blazor circuit.
- Attendance tracking for registered events.
- Responsive interface for desktop and mobile screens.
- No additional package dependencies beyond the .NET and Blazor framework.

## Project structure

```text
Components/
	AttendanceTracker.razor    Attendance state controls
	EventCard.razor            Reusable event card
	RegistrationForm.razor     Validated registration form
	Pages/                      Routed application pages
	Layout/                     Shared navigation and layout
Models/
	Event.cs                    Event data model and validation
	EventCatalog.cs             In-memory event catalog
Services/
	UserSessionState.cs         Scoped registration and attendance state
wwwroot/
	app.css                    EventEase visual styles
Program.cs                    Application and service configuration
```

## State and data notes

The event catalog is intentionally in memory for this learning project. `UserSessionState` is registered as a scoped service, so registration and attendance remain available while the user stays in the same Blazor Server circuit. Restarting the application clears this state.

For production persistence, replace the in-memory catalog and session service with a database-backed repository and an authenticated user or server-side session store.
