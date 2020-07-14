﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE dbo.Vehicle DROP CONSTRAINT [FK_Vehicle_ToVehicleType];

DROP TABLE [dbo].[VehicleType];
CREATE TABLE [dbo].[VehicleType](
	[id] INT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(30) NOT NULL
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

DROP TABLE [dbo].[Vehicle];
CREATE TABLE [dbo].[Vehicle](
	[id] INT IDENTITY(1,1) NOT NULL,
	[created_dttm] DATETIME NOT NULL,
	[speed] FLOAT NOT NULL,
	[type] INT NOT NULL,
	[mileage] FLOAT NOT NULL,
	[deleted_dttm] DATETIME NULL,
	[deleted_by] INT NULL,
	CONSTRAINT [FK_Vehicle_ToVehicleType] FOREIGN KEY ([type]) REFERENCES [dbo].[VehicleType]([id]),
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]