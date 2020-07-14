# Vehicle Management System

- [Vehicle Management System](#vehicle-management-system)
  - [Setup](#setup)
  - [Architecture](#architecture)
  - [Domain](#domain)
    - [Entity](#entity)
    - [Vehicle (Aggregate Root, Entity)](#vehicle-aggregate-root-entity)
    - [VehicleType (ValueObject - enum)](#vehicletype-valueobject---enum)
    - [Speed (ValueObject)](#speed-valueobject)
    - [Location (Entity)](#location-entity)
    - [Latitude (ValueObject)](#latitude-valueobject)
    - [Longitude (ValueObject)](#longitude-valueobject)
    - [Kilometres (ValueObject)](#kilometres-valueobject)
  - [Use Cases](#use-cases)
    - [GetVehicles](#getvehicles)
    - [UpdateMileage](#updatemileage)
  - [Database Schema](#database-schema)
  - [Technologies Used](#technologies-used)
  - [Client](#client)
  - [References/Inspiration](#referencesinspiration)

## Setup

`git clone https://github.com/josh-asi/vms-web-api`

Open Visual Studio and run the project VMS.Api. Swagger will open by default.

## Architecture

I have tried to implement the **Ports and Adapter Pattern/Hexagonal Architecture**.

- VMS.Api - .NET Core Api implementation
- VMS.Application - where the application logic lives. Mostly composed of ports/interfaces
- VMS.Domain - where the domain logic resides
- VMS.Infrastructure - various adapters/implementations of ports

## Domain

Property : _Type_

### Entity

- +Id : _int_

### Vehicle (Aggregate Root, Entity)

- +Type : [_VehicleType_](#vehicletype-valueobject---enum)
- +Speed : [_Speed_](#speed-valueobject)
- +Mileage : [_Kilometres_](#kilometres-valueobject)
- +Location : [_Location_](#location-entity) (WIP)
- +Measurements: _Measurement (WIP)_

### VehicleType (ValueObject - enum)

- +Truck - 0
- +Bus - 1

### Speed (ValueObject)

- -kilometresPerHour : _float_

### Location (Entity)

- +Latitude : [_Latitude_](#latitude-valueobject)
- +Longitude : [_Longitude_](#longitude-valueobject)

### Latitude (ValueObject)

- -latitude : _float_

### Longitude (ValueObject)

- -longitude : _float_

### Kilometres (ValueObject)

- -kilometres: _float_

## Use Cases

- GetVehicles
- UpdateMileage
- AddVehicleLocation _(WIP)_

### GetVehicles

`GET /api/vehicles`

Returns all the vehicles available.

### UpdateMileage

`POST /api/vehicle/{vehicleId}`

Updates the mileage for a vehicle.

## Database Schema

For a closer look, please look at **VMS.Infrastructure/Data/Schema**. Each SQL script will have the fields and field types for each table.

## Technologies Used

- .NET Core
- SQL Server
- EF Core

## Client

To have a look at the client implementation, please go to this [link](https://github.com/josh-asi/vms-client).

## References/Inspiration

- [Buyers Guide - Vehicle Booking and Fleet Management Solution (VBFMS)](https://www.procurement.govt.nz/assets/procurement-property/documents/buyers-guide/vehicle-booking-and-fleet-management-services-syndicated-buyers-guide-msd.pdf)
