/* =========================================================
   Examen Final Programación II - Tema II
   Autora: Daniela Paola Grajeda Sandoval (sufijo DG)
   Script NO destructivo: solo crea lo que no existe.
   ========================================================= */
IF DB_ID(N'ExamenFinalProductosDG') IS NULL
    CREATE DATABASE ExamenFinalProductosDG;
GO

USE ExamenFinalProductosDG;
GO

IF OBJECT_ID(N'dbo.tblProductoDG', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.tblProductoDG
    (
        IdProductoDG    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_tblProductoDG PRIMARY KEY,
        CodigoDG        NVARCHAR(20)  NOT NULL CONSTRAINT UQ_tblProductoDG_Codigo UNIQUE,
        NombreDG        NVARCHAR(100) NOT NULL,
        PrecioDG        DECIMAL(10,2) NOT NULL CONSTRAINT CK_tblProductoDG_Precio CHECK (PrecioDG > 0),
        StockDG         INT           NOT NULL CONSTRAINT CK_tblProductoDG_Stock CHECK (StockDG >= 0),
        FechaRegistroDG DATETIME2(0)  NOT NULL CONSTRAINT DF_tblProductoDG_Fecha DEFAULT (SYSDATETIME())
    );
END
GO

/* Datos de ejemplo (requisito: al menos un dato con el nombre de la alumna) */
IF NOT EXISTS (SELECT 1 FROM dbo.tblProductoDG WHERE CodigoDG = N'PRD-001')
    INSERT INTO dbo.tblProductoDG (CodigoDG, NombreDG, PrecioDG, StockDG) VALUES (N'PRD-001', N'Laptop Educativa Daniela Grajeda', 450.00, 25);
IF NOT EXISTS (SELECT 1 FROM dbo.tblProductoDG WHERE CodigoDG = N'PRD-002')
    INSERT INTO dbo.tblProductoDG (CodigoDG, NombreDG, PrecioDG, StockDG) VALUES (N'PRD-002', N'Proyector LED', 299.99, 10);
IF NOT EXISTS (SELECT 1 FROM dbo.tblProductoDG WHERE CodigoDG = N'PRD-003')
    INSERT INTO dbo.tblProductoDG (CodigoDG, NombreDG, PrecioDG, StockDG) VALUES (N'PRD-003', N'Tablet Gráfica', 85.50, 40);
GO

SELECT IdProductoDG, CodigoDG, NombreDG, PrecioDG, StockDG FROM dbo.tblProductoDG ORDER BY CodigoDG;
GO
