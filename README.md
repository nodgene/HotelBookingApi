## Hotel Booking API

A simple, robust API for booking hotel rooms.  
Designed using ASP.NET Core and Entity Framework Core.

## Overview

This API allows users to:

- Find a hotel by name  
- View available rooms for specific dates and guest count  
- Book a room  
- Retrieve booking details by reference

The system enforces:
- Unique booking references  
- No overlapping bookings  
- Room capacity limits  
- No room changes during a stay  

Each hotel contains 6 rooms across 3 types: single, double, and deluxe.

## Running the API

## Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Optional: SQLite (used by default)

## Steps

1. Clone the repository (bash):
   git clone https://github.com/nodgene/HotelBookingApi.git
   cd hotel-booking-api

2. Run the API (bash):
   dotnet run --project HotelBookingApi

3. Access Swagger UI for exploration and testing
   Open your browser at:
   `https://localhost:5001/swagger`

## Testing
Unit tests are written with xUnit.

To run all tests (bash):
dotnet test

The tests cover:
* Hotel creation and structure
* Booking rules (overlaps, capacity, types)
* Room availability queries
* Booking reference lookups

## Admin Endpoints (for testing)
Available via `/api/admin`:

* `POST /api/admin/seed`
  Seeds the database with a test hotel and 6 rooms.
* `DELETE /api/admin/reset`
  Clears all data.

These endpoints appear in Swagger for manual use.
