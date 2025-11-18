USE [EFISELMACILEK]
GO

/****** Object:  Table [dbo].[STMALT]    Script Date: 27.12.2024 23:51:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Alter TABLE [dbo].[STMALT]
   drop column [RNKBDN] ;

Alter TABLE [dbo].[STMALT]
  add 	[STRENK] [bit] NULL,
   	[STBDEN] [bit] NULL,
   	[STDROP] [bit] NULL;
 
	


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Renk' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STMALT', @level2type=N'COLUMN',@level2name=N'STRENK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STMALT', @level2type=N'COLUMN',@level2name=N'STBDEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Drop' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STMALT', @level2type=N'COLUMN',@level2name=N'STDROP'
GO

