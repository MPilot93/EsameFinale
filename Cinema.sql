 

use Cinema

create table Cinema(
Room int not null,
Value decimal default 0 not null)

create table Rooms(
IdRoom int primary key identity(1,1) not null,
NSeats int not null,
Occupied int null,
IdFilm int not null,
Value decimal default 0 not null)

create table Film(
IdFilm int primary key identity(1,1) not null,
Title nvarchar(30) not null,
Genre nvarchar(30) not null,
Director nvarchar(30) not null,
Minutes int not null)

create table Spectator(
IdSpectator int primary key identity(1,1) not null,
Name nvarchar(40) not null,
Birth datetime not null,
IdTicket int not null)

create table Ticket(
IdTicket int primary key identity(1,1) not null,
Seat int  not null,
Price decimal not null)



insert into Cinema(Room,Value)
values (1,0)
insert into Cinema(Room,Value)
values (2,0)


insert into Rooms(NSeats,Occupied,IdFilm,Value)
values (100,0,1,0)
insert into Rooms(NSeats,Occupied,IdFilm,Value)
values (80,0,2,0)
insert into Rooms(NSeats,Occupied,IdFilm,Value)
values (100,20,1,0)


insert into Film(Title,Genre,Director,Minutes)
values ('It','Horror','Unknow',120)
insert into Film(Title,Genre,Director,Minutes)
values ('Minios','Animation','WaltDisney',100)


insert into Spectator(Name,Birth,IdTicket)
values ('Paolo Rossi','2000-01-01',1)
insert into Spectator(Name,Birth,IdTicket)
values ('Andrea Neri','2018-01-01',2)
insert into Spectator(Name,Birth,IdTicket)
values ('Anna Verdi','1945-01-01',3)

select * from Cinema
select * from Rooms
select * from Film
select * from Spectator
select * from Ticket

