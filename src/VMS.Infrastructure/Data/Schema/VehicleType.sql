﻿CREATE TABLE [dbo].[VehicleType](
	[id] INT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(30) NOT NULL
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]