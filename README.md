# Vehicle Management System

- [Vehicle Management System](#vehicle-management-system)
  - [Setup](#setup)
    - [Database](#database)
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
    - [AddVehicle](#addvehicle)
    - [GetVehicles](#getvehicles)
    - [UpdateMileage](#updatemileage)
    - [DeleteVehicle](#deletevehicle)
  - [Technologies Used](#technologies-used)
  - [Client](#client)
  - [References/Inspiration](#referencesinspiration)

## Setup

`git clone https://github.com/josh-asi/vms-web-api`

Open Visual Studio and run the project VMS.Api. Swagger will open by default.

### Database

**Please ensure that a database called VMS is created in (localdb)\MSSQLLocalDB** For a closer look at the schema, please look at **VMS.Infrastructure/Data/Schema**. Each SQL script will have the fields and field types for each table.

To generate the entities\* from the database into Entity Framework entities, in Visual Studio, select menu Tools -> NuGet Package Manger -> Package Manger Console and run the following command:

`Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=VMS;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/EntityFramework/Entities -f`

\*_Make sure that the Default project is set to VMS.Infrastructure and that Microsoft.EntityFrameworkCore.Tools is installed as a nuget package._

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

- +Truck - 1
- +Bus - 2

### Speed (ValueObject)

- -kilometresPerHour : _double_

### Location (Entity)

- +Latitude : [_Latitude_](#latitude-valueobject)
- +Longitude : [_Longitude_](#longitude-valueobject)

### Latitude (ValueObject)

- -latitude : _double_

### Longitude (ValueObject)

- -longitude : _double_

### Kilometres (ValueObject)

- -kilometres: _double_

## Use Cases

- [AddVehicle](#addvehicle)
- [GetVehicles](#getvehicles)
- [UpdateMileage](#updatemileage)
- [DeleteVehicle](#deletevehicle)
- AddVehicleLocation _(WIP)_

### AddVehicle

`POST /api/vehicle/`

Adds a new vehicle.

Required Parameters:

- Type : _int_
- Speed : _double_
- Mileage: _double_

### GetVehicles

`GET /api/vehicles`

Returns all the vehicles available.

### UpdateMileage

`PUT /api/vehicle/{vehicleId}`

Updates the mileage for a vehicle.

### DeleteVehicle

`DELETE /api/vehicle/{vehicleId}`
Marks the vehicle as deleted in the database

## Technologies Used

- .NET Core
- SQL Server
- EF Core

## Client

To have a look at the client implementation, please go to this [link](https://github.com/josh-asi/vms-client).

## References/Inspiration

- [Buyers Guide - Vehicle Booking and Fleet Management Solution (VBFMS)](https://www.procurement.govt.nz/assets/procurement-property/documents/buyers-guide/vehicle-booking-and-fleet-management-services-syndicated-buyers-guide-msd.pdf)
