\connect AdvertManagementDb2
CREATE TABLE Advert(
    Id SERIAL PRIMARY KEY,
    MemberId INT,
    CityId INT, 
    CityName varchar(50),
    TownId INT, 
    TownName varchar(50),
    ModelId INT, 
    ModelName varchar(100),
    Year INT, 
    Price INT,
    Title varchar(200), 
    Date TIMESTAMP,
    CategoryId INT, 
    Category varchar(100),
    KM INT,
    Color varchar(50),
    Gear varchar(50),
    Fuel varchar(50),
    FirstPhoto varchar(200),
    SecondPhoto varchar(200),
    UserInfo varchar(200),
    UserPhone varchar(50),
    Text TEXT);

ALTER TABLE Advert OWNER TO admin;

\copy Advert from './tmp/csv/Adverts.csv' delimiter ',' CSV HEADER;

