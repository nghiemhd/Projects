CREATE TABLE [InvoiceDetail] (
    [Id] [int] NOT NULL IDENTITY,
    [InvoiceId] [int],
    [Description] [nvarchar](max),
    [Quantity] [int] NOT NULL DEFAULT 0,
    [Price] [decimal](18, 2) NOT NULL DEFAULT 0,
    [IsDeleted] [bit] NOT NULL DEFAULT 0,
    [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [UpdatedBy] [varchar](50) NOT NULL DEFAULT suser_name(),
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [CreatedBy] [varchar](50) NOT NULL DEFAULT suser_name(),
    [RowRevision] rowversion NOT NULL,
    CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_InvoiceId] ON [InvoiceDetail]([InvoiceId])
CREATE TABLE [Invoice] (
    [Id] [int] NOT NULL IDENTITY,
    [InvoiceDate] [datetime] NOT NULL,
    [ShippingFee] [decimal](18, 2) NOT NULL DEFAULT 0,
    [VAT] [decimal](18, 2) NOT NULL DEFAULT 0,
    [IsDeleted] [bit] NOT NULL DEFAULT 0,
    [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [UpdatedBy] [varchar](50) NOT NULL DEFAULT suser_name(),
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [CreatedBy] [varchar](50) NOT NULL DEFAULT suser_name(),
    [RowRevision] rowversion NOT NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY ([Id])
)
CREATE TABLE [User] (
    [Id] [int] NOT NULL IDENTITY,
    [Username] [varchar](50) NOT NULL,
    [Password] [varchar](255) NOT NULL,
    [Email] [varchar](100),
    [IsActive] [bit] NOT NULL,
    [IsDeleted] [bit] NOT NULL DEFAULT 0,
    [UpdatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [UpdatedBy] [varchar](50) NOT NULL DEFAULT suser_name(),
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [CreatedBy] [varchar](50) NOT NULL DEFAULT suser_name(),
    [RowRevision] rowversion NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
)
ALTER TABLE [InvoiceDetail] ADD CONSTRAINT [FK_InvoiceDetail_Invoice_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice] ([Id])