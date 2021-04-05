CREATE TABLE [dbo].[Inventory] (
    [Id]              BIGINT       IDENTITY (1, 1) NOT NULL,
    [StoreId]         INT          NOT NULL,
    [TransactionDate] DATETIME     NOT NULL,
    [Barcode]         VARCHAR (20) NOT NULL,
    [Quantity]        INT          NOT NULL,
    CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Inventory_Product] FOREIGN KEY ([Barcode]) REFERENCES [dbo].[Product] ([Barcode]),
    CONSTRAINT [FK_Inventory_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Identificador de transaccion de inventario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Inventory', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Identificador de la sucursal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Inventory', @level2type = N'COLUMN', @level2name = N'StoreId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de la transaccion', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Inventory', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Codigo de barras', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Inventory', @level2type = N'COLUMN', @level2name = N'Barcode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Cantidad de productos', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Inventory', @level2type = N'COLUMN', @level2name = N'Quantity';

