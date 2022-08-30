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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''864e6910-925f-4cef-b1cc-258e592a376c'' AND [UserId] = ''6d32c0f0-0e91-4e22-80de-71105dc54a8a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''ecb15d95-f0b2-4b4b-97ee-51ba5cf78756'' AND [UserId] = ''6d32c0f0-0e91-4e22-80de-71105dc54a8a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''864e6910-925f-4cef-b1cc-258e592a376c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''ecb15d95-f0b2-4b4b-97ee-51ba5cf78756'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''6d32c0f0-0e91-4e22-80de-71105dc54a8a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (''b220aec4-87d7-4640-9dc3-18f641d99f0f'', N''9367b118-a3b9-4116-b1b8-b2abcd85b59f'', N''User'', N''USER'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (''f996ef7b-24f2-4c31-a69a-d39dc0bee721'', N''9663f319-ad2d-4027-ac0f-c14fa7636f0c'', N''Admin'', N''ADMIN'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ActivationKey', N'ConcurrencyStamp', N'CreatedAt', N'Email', N'EmailConfirmed', N'FirstName', N'Is18OrAbove', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'ResetKey', N'SecurityStamp', N'TwoFactorEnabled', N'UpdatedAt', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ActivationKey], [ConcurrencyStamp], [CreatedAt], [Email], [EmailConfirmed], [FirstName], [Is18OrAbove], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [ResetKey], [SecurityStamp], [TwoFactorEnabled], [UpdatedAt], [UserName])
    VALUES (''e229df1a-0941-4ba6-b234-37828ae475e2'', 0, N'''', N'''', ''2022-08-30T10:35:44.3957587+08:00'', N''anders@jensenwaud.com'', CAST(1 AS bit), N''Anders Admin'', CAST(1 AS bit), N''Jensen'', CAST(0 AS bit), NULL, N''anders@jensenwaud.com'', N''Admin'', N''AQAAAAEAACcQAAAAEFj+UUInmGyNCEAl1WScalAy+mVMhOVAQuGlJlgd8DdwzNC2And9FteVYeB+8J6ILA=='', N''00000000'', CAST(1 AS bit), N'''', N'''', CAST(0 AS bit), ''2022-08-30T10:35:44.3957606+08:00'', N''Admin'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ActivationKey', N'ConcurrencyStamp', N'CreatedAt', N'Email', N'EmailConfirmed', N'FirstName', N'Is18OrAbove', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'ResetKey', N'SecurityStamp', N'TwoFactorEnabled', N'UpdatedAt', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (''b220aec4-87d7-4640-9dc3-18f641d99f0f'', ''e229df1a-0941-4ba6-b234-37828ae475e2'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (''f996ef7b-24f2-4c31-a69a-d39dc0bee721'', ''e229df1a-0941-4ba6-b234-37828ae475e2'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220830023544_mssql.azure_migration_970')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220830023544_mssql.azure_migration_970', N'6.0.7');
END;
GO

COMMIT;
GO

