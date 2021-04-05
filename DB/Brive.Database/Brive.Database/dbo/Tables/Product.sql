CREATE TABLE [dbo].[Product] (
    [Id]        BIGINT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (200)   NOT NULL,
    [UnitPrice] DECIMAL (18, 2) NOT NULL,
    [Barcode]   VARCHAR (20)    NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Product]
    ON [dbo].[Product]([Barcode] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Informacion de productos', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Identificador de producto', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre del producto', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Precio unitario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'UnitPrice';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Codigo de barras', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Product', @level2type = N'COLUMN', @level2name = N'Barcode';

