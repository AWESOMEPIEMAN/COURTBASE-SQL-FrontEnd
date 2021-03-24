create database Court
use Court;


---------------------No foerign Keys----------------
create table spectators
(
Spec_ID int IDENTITY(10,1) Primary Key,
Name_spec char(20),
Age int,
DOB_Spec date,
address_spec char(20),
);

create table Sheriff 
(
Sheriff_ID int IDENTITY(10,1) Primary key,
DOB_Sheriff date,
Address_sheriff char(20),

)

create table Jury
(
Member_ID int IDENTITY(10,1) Primary key,
Name_jury char(20),
age int,
DOB_Jury date,
address_jury char(20),

)



create table Clerk
(
Clerk_ID int IDENTITY(10,1) Primary key,
name_clerk char(20),
age_clerk int,
DOB_Clerk date,
Address_Clerk char(20),
Records_made int,
)

-------------------------------------------------------------------
-------------------------With foreign keys-------------------------
create table HighCourt
(
ID int IDENTITY(10,1) primary key,
ChiefJustice char(20),
address char(20),
Phoneno char (20),
email char(30),
ID_DC int FOREIGN KEY REFERENCES DistrictCourt(ID_DC)
)

create table DistrictCourt 
(
ID_DC int IDENTITY(10,1) primary key,
District char(20),
address char(20),
Phone_no_dc char(20),
Email char(20),

Room_ID int FOREIGN KEY REFERENCES courtroom(Room_ID)
)
create table courtroom
(
Room_ID int IDENTITY(10,1) primary key,
location_cr char(20),
Phone_no_cr char(20),
case_t char(20),

Plaintiff int FOREIGN KEY REFERENCES Plaintiff(Plaintiff_ID),
Defendant_ID int FOREIGN KEY REFERENCES Defendant(Defendant_ID),
Spec_ID int FOREIGN KEY REFERENCES spectators(Spec_ID),
Clerk_ID int FOREIGN KEY REFERENCES Clerk(Clerk_ID),
Judge_ID int FOREIGN KEY REFERENCES Judge(Judge_ID),
Sheriff_ID int FOREIGN KEY REFERENCES Sheriff(Sheriff_ID),
Member_ID int FOREIGN KEY REFERENCES Jury(Member_ID),
)

create table Judge
(
Judge_ID int IDENTITY(10,1) primary key,
name_judge char(20),
age_judge int,
rank_judge char(10),
YearsInservice int,

Firm_ID int FOREIGN KEY REFERENCES firm(Firm_ID),
Plaintiff int FOREIGN KEY REFERENCES Plaintiff(Plaintiff_ID),
Defendant_ID int FOREIGN KEY REFERENCES Defendant(Defendant_ID)
)

create table Defendant
(
Defendant_ID int IDENTITY(10,1) primary key,
name_defend char(20),
age_defend int,
DOB_defend date,
)


select * from Plaintiff

create table Plaintiff
(
Plaintiff_ID int IDENTITY(10,1) primary key,
name_plain char(20),
age_plain int,
DOB_plain date,
)

create table firm
(
Firm_ID int IDENTITY(10,1) Primary key,
name_firm char(20),
address_firm char(29),
phone_firm int,
email_firm char(20),
StartingYear date,

)

create table lawyer 
(
Lawyer_ID int IDENTITY(10,1) Primary key,
name_lawyer char(20),
client char(20),
Firm_ID int FOREIGN KEY REFERENCES firm(Firm_ID),
Plaintiff int FOREIGN KEY REFERENCES Plaintiff(Plaintiff_ID),
Defendant_ID int FOREIGN KEY REFERENCES Defendant(Defendant_ID)
)

-------Queries-------
select *from lawyer
select *from Clerk
select *from courtroom
select *from DistrictCourt
select *from firm
select *from HighCourt
select *from Judge
select *from Jury
select *from Plaintiff
select *from Defendant
select *from Sheriff
select *from spectators

SELECT name_plain
FROM Plaintiff
INNER JOIN Defendant
ON Plaintiff.name_plain = Defendant.name_defend;

SELECT name_plain
FROM Plaintiff
FULL OUTER JOIN Defendant
ON Plaintiff.name_plain = Defendant.name_defend
WHERE name_plain = name_defend;

update Plaintiff 
set name_plain = 'Ayesha'
where Plaintiff_ID = 14

SELECT name_plain, PLaintiff_ID FROM Plaintiff;
