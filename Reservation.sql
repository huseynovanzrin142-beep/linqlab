CREATE DATABASE ReservationDB
GO
USE ReservationDB
GO


CREATE TABLE Companies(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL DEFAULT 'No Name',
[IATA_Code] NVARCHAR(30) NOT NULL DEFAULT 'No IATA_Code'
) 


GO
CREATE TABLE Cabins(
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[BaggageLimit] INT NOT NULL DEFAULT (30)
)


GO
CREATE TABLE Airports (
[IATA_Code] CHAR(3) PRIMARY KEY NOT NULL, 
[Name] NVARCHAR(100) NOT NULL,
[City] NVARCHAR(50) NOT NULL,
[Country] NVARCHAR(50) NOT NULL
)


GO
CREATE TABLE Passangers (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[FirstName] NVARCHAR(50) NOT NULL DEFAULT ('No Firstname'),
[LastName] NVARCHAR(50) NOT NULL DEFAULT ('No Lastname'),
[Gender] CHAR(1) CHECK ([Gender] IN ('M', 'F', 'm', 'f')),
[Phone] NVARCHAR(50) NOT NULL DEFAULT 'Can not find phone',
[Password] NVARCHAR(50) NOT NULL UNIQUE,
)


GO
CREATE TABLE Airplanes (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL DEFAULT 'No Name',
[Model] NVARCHAR(100) NOT NULL DEFAULT 'No Model',
[TailNumber] NVARCHAR(100) NOT NULL DEFAULT 'No Tail Number',
[Manufacturer] NVARCHAR(50) NOT NULL DEFAULT 'No Manufacturer',
[CompanyId] INT NOT NULL,
CONSTRAINT  FK_CompanyId FOREIGN KEY ([CompanyId]) REFERENCES Companies(Id) ON DELETE CASCADE ON UPDATE CASCADE
)





GO
CREATE TABLE Seats (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[SeatNumber] NVARCHAR(5) NOT NULL,
[LocationType] NVARCHAR(15),
[AirplaneId] INT NOT NULL,
[CabinId] INT NOT NULL,
CONSTRAINT FK_SeatAirplane FOREIGN KEY ([AirplaneId]) REFERENCES Airplanes(Id) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_CabinId FOREIGN KEY ([CabinId]) REFERENCES Cabins(Id) ON DELETE CASCADE ON UPDATE CASCADE
)




GO
CREATE TABLE AirplaneConfigurations (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CabinId] INT NOT NULL,
[AirplaneId] INT NOT NULL,
CONSTRAINT FK_CabinId2 FOREIGN KEY ([CabinId]) REFERENCES Cabins(Id) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_AirplaneId FOREIGN KEY ([AirplaneId]) REFERENCES Airplanes(Id) ON DELETE CASCADE ON UPDATE CASCADE
)





GO
CREATE TABLE [Routes] (
[Id] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
[FromAirportIATA] CHAR(3) NULL,
[ToAirportIATA] CHAR(3) NULL,
[CompanyId] INT NOT NULL,
CONSTRAINT FK_FromAirport FOREIGN KEY ([FromAirportIATA]) REFERENCES Airports(IATA_Code),
CONSTRAINT FK_ToAirport FOREIGN KEY ([ToAirportIATA]) REFERENCES Airports(IATA_Code),
CONSTRAINT FK_CompanyId3 FOREIGN KEY ([CompanyId]) REFERENCES Companies(Id) ON DELETE CASCADE ON UPDATE CASCADE
)


GO
CREATE TABLE Flights (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[AirplaneId] INT NOT NULL,
[RouteId] INT NOT NULL,
[DepartureTime] DATETIME NOT NULL,
[ArrivalTime] DATETIME NOT NULL,
CONSTRAINT FK_RouteId5 FOREIGN KEY ([RouteId]) REFERENCES [Routes](Id),
CONSTRAINT FK_AirplaneId2 FOREIGN KEY ([AirplaneId]) REFERENCES Airplanes(Id) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT CK_FlightTime CHECK ([ArrivalTime] > [DepartureTime])
)



GO
CREATE TABLE Pilots (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[FirstName] NVARCHAR(50) NOT NULL DEFAULT 'No Firstname',
[LastName] NVARCHAR(50) NOT NULL DEFAULT 'No Lastname',
[CompanyId] INT NOT NULL,
[IsActive] BIT NOT NULL DEFAULT (0),
[Salary] MONEY NOT NULL DEFAULT (2500.50),
[Rank] NVARCHAR(50) NOT NULL DEFAULT ('Junior'),
[RouteId] INT,
CONSTRAINT FK_RouteId FOREIGN KEY ([RouteId]) REFERENCES [Routes](Id),
CONSTRAINT FK_CompanyId4 FOREIGN KEY ([CompanyId]) REFERENCES Companies(Id) ON DELETE CASCADE ON UPDATE CASCADE
)


GO
CREATE TABLE FlightPilots (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Role] NVARCHAR(30) NOT NULL,
[FlightId] INT NOT NULL,
[PilotId] INT NOT NULL,
CONSTRAINT FK_FlightId3 FOREIGN KEY ([FlightId]) REFERENCES Flights(Id) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_PilotId FOREIGN KEY ([PilotId]) REFERENCES Pilots(Id) 
)



GO
CREATE TABLE Tickets (
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Price] MONEY NULL ,
[CabinId] INT NOT NULL,
[SeatNumberId] INT NOT NULL,
[PurchaseDate] DATETIME NOT NULL,
[FlightId] INT NOT NULL,
[PassangerId] INT NOT NULL,
CONSTRAINT FK_PassangerId FOREIGN KEY ([PassangerId]) REFERENCES Passangers(Id) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_FlightId FOREIGN KEY ([FlightId]) REFERENCES Flights(Id) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_CabinId3 FOREIGN KEY ([CabinId]) REFERENCES Cabins(Id) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT FK_SeatId FOREIGN KEY ([SeatNumberId]) REFERENCES Seats(Id) 
)

GO
INSERT INTO Companies ([Name], [IATA_Code]) VALUES 
('Azerbaijan Airlines', 'J2'),
('Turkish Airlines', 'TK'),
('Lufthansa', 'LH');

GO
INSERT INTO Cabins ([Name], [BaggageLimit]) VALUES 
('Economy', 23),
('Business', 32),
('First Class', 40);

GO
INSERT INTO Airports ([IATA_Code], [Name], [City], [Country]) VALUES 
('GYD', 'Heydar Aliyev Intl', 'Baku', 'Azerbaijan'),
('IST', 'Istanbul Airport', 'Istanbul', 'Turkey'),
('FRA', 'Frankfurt Airport', 'Frankfurt', 'Germany');

GO
INSERT INTO Airplanes ([Name], [Model], [TailNumber], [Manufacturer], [CompanyId]) VALUES 
('Karabakh', 'Boeing 787', '4K-AZ01', 'Boeing', 1),
('Bosphorus', 'Airbus A330', 'TC-JND', 'Airbus', 2),
('Alpha', 'Airbus A320', 'D-AIPX', 'Airbus', 3);

GO
INSERT INTO Seats ([SeatNumber], [LocationType], [AirplaneId], [CabinId]) VALUES 
('1A', 'Window', 1, 3),
('1B', NULL, 1, 3),      
('12C', 'Aisle', 1, 1),  
('5A', 'Window', 2, 2);  

GO
INSERT INTO [Routes] ([FromAirportIATA], [ToAirportIATA], [CompanyId]) VALUES 
('GYD', 'IST', 1),
('IST', 'FRA', 2),
('FRA', 'GYD', 3);

GO
INSERT INTO Flights ([AirplaneId], [RouteId], [DepartureTime], [ArrivalTime]) VALUES 
(1, 1, '2023-12-25 10:00:00', '2023-12-25 13:00:00'),
(2, 2, '2023-12-26 15:30:00', '2023-12-26 19:45:00');

GO
INSERT INTO Passangers ([FirstName], [LastName], [Gender], [Password]) VALUES 
('Ali', 'Aliyev', 'M', 'P@ss123'),
('Valida', 'Mammadova', 'F', 'Secured!01'),
('John', 'Doe', 'M', 'Secret55'); 

GO
INSERT INTO Pilots ([FirstName], [LastName], [CompanyId], [IsActive], [Salary], [Rank]) VALUES 
('Kamran', 'Huseynov', 1, 1, 5500.00, 'Captain'),
('Murad', 'Ahmadov', 1, 1, 3200.00, 'First Officer'),
('Selim', 'Yılmaz', 2, 0, 4800.00, 'Captain');

GO
INSERT INTO FlightPilots ([Role], [FlightId], [PilotId]) VALUES 
('Captain', 1, 1),
('First Officer', 1, 2);

GO
INSERT INTO Tickets ([Price], [CabinId], [SeatNumberId], [PurchaseDate], [FlightId], [PassangerId]) VALUES 
(450.00, 1, 3, GETDATE(), 1, 1),
(NULL, 3, 1, GETDATE(), 1, 2),
(800.50, 2, 4, GETDATE(), 2, 3);


GO
