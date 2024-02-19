USE MilesCarRentalDB
-- Table Location
CREATE TABLE LOCATIONS (
    id_location INT PRIMARY KEY IDENTITY,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(255)
);

-- Table Vehicle
CREATE TABLE VEHICLES (
    id_vehicle INT PRIMARY KEY IDENTITY,
    brand VARCHAR(100) NOT NULL,
    model VARCHAR(100) NOT NULL,
    type VARCHAR(50),
    availability VARCHAR(20),
    id_location INT,
    FOREIGN KEY (ID_location) REFERENCES LOCATIONS(ID_location)
);

-- Table Customer
CREATE TABLE CLIENTS (
    id_client INT PRIMARY KEY IDENTITY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    phone VARCHAR(20) NOT NULL
);

-- Table Rental_History
CREATE TABLE RENTALS (
    id_rental INT PRIMARY KEY IDENTITY,
    id_client INT NOT NULL,
    id_vehicle INT NOT NULL,
    id_pickup_location INT NOT NULL,
    id_return_location INT NOT NULL,
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
    FOREIGN KEY (id_client) REFERENCES CLIENTS(id_client),
    FOREIGN KEY (ID_vehicle) REFERENCES VEHICLES(ID_vehicle),
    FOREIGN KEY (ID_pickup_location) REFERENCES LOCATIONS(ID_location),
    FOREIGN KEY (ID_return_location) REFERENCES LOCATIONS(ID_location)
);
