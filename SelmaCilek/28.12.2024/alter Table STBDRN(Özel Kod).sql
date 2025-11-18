USE [EFISELMACILEK]
GO

/****** Object:  Table [dbo].[STBDRN]    Script Date: 28.12.2024 00:37:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter TABLE [dbo].[STBDRN]
 add	[STOZEL] [nvarchar](20) NULL;
 

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Özel Kod' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STBDRN', @level2type=N'COLUMN',@level2name=N'STOZEL'
GO

