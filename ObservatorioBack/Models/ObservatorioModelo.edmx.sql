
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/12/2020 15:31:47
-- Generated from EDMX file: D:\Dropbox\Dropbox\DESI\Projetos\Observatorio\ObservatorioBackend\ObservatorioBack\Models\ObservatorioModelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Observatorio];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EstadoResposta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Respostas] DROP CONSTRAINT [FK_EstadoResposta];
GO
IF OBJECT_ID(N'[dbo].[FK_RespostaEstado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Respostas] DROP CONSTRAINT [FK_RespostaEstado];
GO
IF OBJECT_ID(N'[dbo].[FK_DetentoProcesso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Processos] DROP CONSTRAINT [FK_DetentoProcesso];
GO
IF OBJECT_ID(N'[dbo].[FK_ProcessoAcompanhamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Acompanhamentos] DROP CONSTRAINT [FK_ProcessoAcompanhamento];
GO
IF OBJECT_ID(N'[dbo].[FK_AcompanhamentoEstado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Acompanhamentos] DROP CONSTRAINT [FK_AcompanhamentoEstado];
GO
IF OBJECT_ID(N'[dbo].[FK_AcompanhamentoAcompanhamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Acompanhamentos] DROP CONSTRAINT [FK_AcompanhamentoAcompanhamento];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Detentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detentos];
GO
IF OBJECT_ID(N'[dbo].[Acompanhamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Acompanhamentos];
GO
IF OBJECT_ID(N'[dbo].[Estados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estados];
GO
IF OBJECT_ID(N'[dbo].[Respostas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Respostas];
GO
IF OBJECT_ID(N'[dbo].[Processos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Processos];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Detentos'
CREATE TABLE [dbo].[Detentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Acompanhamentos'
CREATE TABLE [dbo].[Acompanhamentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DataInicio] datetime  NOT NULL,
    [DataFim] datetime  NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [Processo_Id] int  NOT NULL,
    [Estado_Id] int  NOT NULL,
    [AcompanhamentoOrigem_Id] int  NOT NULL
);
GO

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Espera] int  NOT NULL,
    [Pergunta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Respostas'
CREATE TABLE [dbo].[Respostas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Comentario] nvarchar(max)  NOT NULL,
    [Estado_Id] int  NOT NULL,
    [EstadoDestino_Id] int  NOT NULL
);
GO

-- Creating table 'Processos'
CREATE TABLE [dbo].[Processos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] nvarchar(max)  NOT NULL,
    [DataInicio] datetime  NOT NULL,
    [Detento_Id] int  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Detentos'
ALTER TABLE [dbo].[Detentos]
ADD CONSTRAINT [PK_Detentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Acompanhamentos'
ALTER TABLE [dbo].[Acompanhamentos]
ADD CONSTRAINT [PK_Acompanhamentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Respostas'
ALTER TABLE [dbo].[Respostas]
ADD CONSTRAINT [PK_Respostas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Processos'
ALTER TABLE [dbo].[Processos]
ADD CONSTRAINT [PK_Processos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Estado_Id] in table 'Respostas'
ALTER TABLE [dbo].[Respostas]
ADD CONSTRAINT [FK_EstadoResposta]
    FOREIGN KEY ([Estado_Id])
    REFERENCES [dbo].[Estados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoResposta'
CREATE INDEX [IX_FK_EstadoResposta]
ON [dbo].[Respostas]
    ([Estado_Id]);
GO

-- Creating foreign key on [EstadoDestino_Id] in table 'Respostas'
ALTER TABLE [dbo].[Respostas]
ADD CONSTRAINT [FK_RespostaEstado]
    FOREIGN KEY ([EstadoDestino_Id])
    REFERENCES [dbo].[Estados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RespostaEstado'
CREATE INDEX [IX_FK_RespostaEstado]
ON [dbo].[Respostas]
    ([EstadoDestino_Id]);
GO

-- Creating foreign key on [Detento_Id] in table 'Processos'
ALTER TABLE [dbo].[Processos]
ADD CONSTRAINT [FK_DetentoProcesso]
    FOREIGN KEY ([Detento_Id])
    REFERENCES [dbo].[Detentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetentoProcesso'
CREATE INDEX [IX_FK_DetentoProcesso]
ON [dbo].[Processos]
    ([Detento_Id]);
GO

-- Creating foreign key on [Processo_Id] in table 'Acompanhamentos'
ALTER TABLE [dbo].[Acompanhamentos]
ADD CONSTRAINT [FK_ProcessoAcompanhamento]
    FOREIGN KEY ([Processo_Id])
    REFERENCES [dbo].[Processos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcessoAcompanhamento'
CREATE INDEX [IX_FK_ProcessoAcompanhamento]
ON [dbo].[Acompanhamentos]
    ([Processo_Id]);
GO

-- Creating foreign key on [Estado_Id] in table 'Acompanhamentos'
ALTER TABLE [dbo].[Acompanhamentos]
ADD CONSTRAINT [FK_AcompanhamentoEstado]
    FOREIGN KEY ([Estado_Id])
    REFERENCES [dbo].[Estados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcompanhamentoEstado'
CREATE INDEX [IX_FK_AcompanhamentoEstado]
ON [dbo].[Acompanhamentos]
    ([Estado_Id]);
GO

-- Creating foreign key on [AcompanhamentoOrigem_Id] in table 'Acompanhamentos'
ALTER TABLE [dbo].[Acompanhamentos]
ADD CONSTRAINT [FK_AcompanhamentoAcompanhamento]
    FOREIGN KEY ([AcompanhamentoOrigem_Id])
    REFERENCES [dbo].[Acompanhamentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcompanhamentoAcompanhamento'
CREATE INDEX [IX_FK_AcompanhamentoAcompanhamento]
ON [dbo].[Acompanhamentos]
    ([AcompanhamentoOrigem_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------