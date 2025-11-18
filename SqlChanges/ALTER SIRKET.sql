
/****** Object:  Table [dbo].[SIRKET]    Script Date: 21.12.2024 21:34:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE [dbo].[SIRKET]
	
	add [RNKBDN] [bit] NULL;
	


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Renk Benden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SIRKET', @level2type=N'COLUMN',@level2name=N'RNKBDN'
GO



