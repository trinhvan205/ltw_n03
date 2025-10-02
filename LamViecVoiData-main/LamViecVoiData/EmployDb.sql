
USE EmployeeDb;
GO

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Gender INT NOT NULL, -- 0 = Male, 1 = Female, 2 = Other
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(256) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL,
    Status INT NOT NULL -- 0 = Inactive, 1 = Active
);
GO

-- Thêm dữ liệu mẫu
INSERT INTO Employees (FullName, Gender, Phone, Email, Salary, Status) VALUES
(N'Nguyen Van A', 0, '0912345678', 'a@example.com', 1200.50, 1),
(N'Tran Thi B', 1, '0987654321', 'b@example.com', 1500.00, 1),
(N'Le Van C', 0, '0901122334', 'c@example.com', 800.00, 0);
GO
select * from Employees