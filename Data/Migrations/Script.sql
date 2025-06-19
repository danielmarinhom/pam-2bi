IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_USUARIO] (
    [Id] int NOT NULL IDENTITY,
    [Nome] Varchar(200) NOT NULL,
    [Senha] Varchar(200) NOT NULL,
    [Telefone] Varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_USUARIO] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_SUGESTAO] (
    [Id] int NOT NULL IDENTITY,
    [Text] Varchar(200) NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_TB_SUGESTAO] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_SUGESTAO_TB_USUARIO_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIO] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Senha', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_USUARIO]'))
    SET IDENTITY_INSERT [TB_USUARIO] ON;
INSERT INTO [TB_USUARIO] ([Id], [Nome], [Senha], [Telefone])
VALUES (1, 'João Silva', 'senha123', '11999999999'),
(2, 'Maria Oliveira', 'senha456', '11988888888'),
(3, 'Carlos Souza', 'senha789', '11977777777');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome', N'Senha', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_USUARIO]'))
    SET IDENTITY_INSERT [TB_USUARIO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Text', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[TB_SUGESTAO]'))
    SET IDENTITY_INSERT [TB_SUGESTAO] ON;
INSERT INTO [TB_SUGESTAO] ([Id], [Text], [UsuarioId])
VALUES (1, 'Pedir Ifood', 1),
(2, 'Ajuda no Uber', 1),
(3, 'Logar no email', 2),
(4, 'Mandar mensagem no Whatsapp', 3),
(5, 'Navegar pelo Facebook', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Text', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[TB_SUGESTAO]'))
    SET IDENTITY_INSERT [TB_SUGESTAO] OFF;
GO

CREATE INDEX [IX_TB_SUGESTAO_UsuarioId] ON [TB_SUGESTAO] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250619144714_AddUsuarioSugestao', N'8.0.0');
GO

COMMIT;
GO

