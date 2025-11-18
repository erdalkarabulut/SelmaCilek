
/****** Object:  Table [dbo].[STMALT]    Script Date: 21.12.2024 22:53:30 ******/

ALTER TABLE [dbo].[STMALT]
	
	add [RNKBDN] [bit] NULL;
	


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Renk Benden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STMALT', @level2type=N'COLUMN',@level2name=N'RNKBDN'
GO



