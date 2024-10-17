CREATE TRIGGER TRG_Familia_UpdateINumeroCuenta
    ON Catalogo.Familias
    AFTER INSERT AS
BEGIN
    UPDATE Catalogo.Familias
    SET iNumeroCuenta = SUBSTRING(CAST(iIdFamilia AS VARCHAR), 2, 1)
    FROM inserted
    WHERE Catalogo.Familias.iIdFamilia = inserted.iIdFamilia;
END;
GO

CREATE TRIGGER TRG_Subfamilia_UpdateINumeroCuenta
    ON Catalogo.Subfamilias
    AFTER INSERT AS
BEGIN
    UPDATE Catalogo.Subfamilias
    SET iNumeroCuenta = CAST(RIGHT(idSubfamilia, 1) AS INT)
    FROM inserted
    WHERE Catalogo.Subfamilias.iIdSubfamilia = inserted.iIdSubfamilia;
END;
GO