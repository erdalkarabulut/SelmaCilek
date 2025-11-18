/****** Object:  Table [dbo].[STCRKD]    Script Date: 23.12.2024 10:58:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[STCRKD](
	[Id] [int] NOT NULL,
	[SIRKID] [int] NOT NULL,
	[URYRKD] [nvarchar](20) NOT NULL,
	[CRKODU] [nvarchar](25) NOT NULL,
	[STKODU] [nvarchar](25) NOT NULL,
	[VRKODU] [nvarchar](25) NULL,
	[VRYTNM] [nvarchar](40) NULL,
	[RENKKD] [nvarchar](20) NULL,
	[BEDNKD] [nvarchar](20) NULL,
	[DROPKD] [nvarchar](20) NULL,
	[CRSTKO] [nvarchar](25) NULL,
	[EANTKD] [nvarchar](20) NULL,
	[EANKOD] [nvarchar](40) NULL,
	[ACTIVE] [bit] NOT NULL,
	[SLINDI] [bit] NOT NULL,
	[EKKULL] [nvarchar](20) NOT NULL,
	[ETARIH] [datetime] NOT NULL,
	[DEKULL] [nvarchar](20) NULL,
	[DTARIH] [datetime] NULL,
	[KYNKKD] [nvarchar](20) NOT NULL,
	[CHKCTR] [bit] NOT NULL,
	[TIMSTM] [timestamp] NULL,
 CONSTRAINT [PK_STCRKD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[STCRKD] ADD  CONSTRAINT [DF_STCRKD_CHKCTR]  DEFAULT ((0)) FOR [CHKCTR]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Þirket Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'SIRKID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Üretim Yeri Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'URYRKD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cari Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'CRKODU'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stok Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'STKODU'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Varyant Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'VRKODU'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Varyant Tanýmý' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'VRYTNM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Renk Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'RENKKD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beden Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'BEDNKD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tedarikçi Stok Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'CRSTKO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ean Tipi Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'EANTKD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EAN Kodu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'EANKOD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Durum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'ACTIVE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Silindi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'SLINDI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ekleyen Kullanýcý' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'EKKULL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eklenme Tarihi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'ETARIH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deðiþtiren Kullanýcý' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'DEKULL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deðiþiklik Tarihi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'DTARIH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kaynak Kod' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'KYNKKD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kontrol' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'CHKCTR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TimeStamp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD', @level2type=N'COLUMN',@level2name=N'TIMSTM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tedarikçi Stok Kodlarý Tablosu' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'STCRKD'
GO


