use MilesCarRentalDB

-- Insertar clientes con ciudades colombianas
INSERT INTO CLIENTS(first_name, last_name, phone) VALUES
('Juan', 'Perez', '1234567890'),
('Maria', 'Gonzalez', '0987654321'),
('Pedro', 'Rodriguez', '4567890123'),
('Ana', 'Martinez', '9876543210'),
('Luis', 'Lopez', '3210987654'),
('Laura', 'Sanchez', '6543210987'),
('Carlos', 'Diaz', '2345678901'),
('Sofia', 'Hernandez', '7654321098'),
('Diego', 'Torres', '3456789012'),
('Valeria', 'Jimenez', '8765432109'),
('Jorge', 'Rios', '5678901234'),
('Camila', 'Alvarez', '6549873210'),
('Daniel', 'Gomez', '7890123456'),
('Fernanda', 'Vargas', '8901234567'),
('Andres', 'Cruz', '5678901234'),
('Carolina', 'Reyes', '9012345678'),
('Ricardo', 'Mendoza', '6789012345'),
('Paula', 'Castro', '0123456789'),
('Miguel', 'Flores', '7890123456'),
('Isabella', 'Ramirez', '9012345678');


-- Insertar localidades como ciudades de Colombia con direcciones variadas
INSERT INTO LOCATIONS (name, address) VALUES
('Bogot�', 'Calle Principal 1, Bogot�'),
('Medell�n', 'Avenida Central 20, Medell�n'),
('Cali', 'Carrera 5 Este, Cali'),
('Barranquilla', 'Calle 45 Sur, Barranquilla'),
('Cartagena', 'Avenida del Libertador, Cartagena'),
('C�cuta', 'Calle 7 Norte, C�cuta'),
('Soledad', 'Carrera 10 Este, Soledad'),
('Ibagu�', 'Carrera 15 Oeste, Ibagu�'),
('Bucaramanga', 'Avenida Santander, Bucaramanga'),
('Soacha', 'Calle 3 Este, Soacha');



-- Insertar veh�culos con disponibilidad y asignaci�n a localidades
INSERT INTO VEHICLES(brand, model, type, availability, id_location) VALUES
('Toyota', 'Corolla', 'Autom�vil', 'Available', 1),
('Honda', 'Civic', 'Autom�vil', 'Available', 2),
('Chevrolet', 'Spark', 'Autom�vil', 'Available', 3),
('Ford', 'Fiesta', 'Autom�vil', 'Available', 4),
('Nissan', 'Sentra', 'Autom�vil', 'Available', 5),
('Volkswagen', 'Jetta', 'Autom�vil', 'Available', 6),
('BMW', 'Serie 3', 'Autom�vil', 'Available', 7),
('Mercedes-Benz', 'Clase C', 'Autom�vil', 'Available', 8),
('Audi', 'A4', 'Autom�vil', 'Available', 9),
('Kia', 'Rio', 'Autom�vil', 'Available', 10),
('Hyundai', 'Elantra', 'Autom�vil', 'Available', 1),
('Mazda', '3', 'Autom�vil', 'Available', 2),
('Renault', 'Clio', 'Autom�vil', 'Available', 3),
('Peugeot', '208', 'Autom�vil', 'Available', 4),
('Subaru', 'Impreza', 'Autom�vil', 'Available', 5),
('Tesla', 'Model 3', 'Autom�vil El�ctrico', 'Available', 6),
('Jeep', 'Wrangler', 'SUV', 'Available', 7),
('Land Rover', 'Range Rover', 'SUV', 'Available', 8),
('Toyota', 'RAV4', 'SUV', 'Available', 9),
('Honda', 'CR-V', 'SUV', 'Available', 10),
('Ford', 'Escape', 'SUV', 'Available', 1),
('Nissan', 'X-Trail', 'SUV', 'Available', 2),
('Volkswagen', 'Tiguan', 'SUV', 'Available', 3),
('Chevrolet', 'Equinox', 'SUV', 'Available', 4),
('BMW', 'X3', 'SUV', 'Available', 5),
('Mercedes-Benz', 'GLC', 'SUV', 'Available', 6),
('Audi', 'Q5', 'SUV', 'Available', 7),
('Kia', 'Sportage', 'SUV', 'Available', 8),
('Hyundai', 'Tucson', 'SUV', 'Available', 9),
('Mazda', 'CX-5', 'SUV', 'Available', 10);

