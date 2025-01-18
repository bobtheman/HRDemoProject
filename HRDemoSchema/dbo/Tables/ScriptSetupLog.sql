CREATE TABLE [dbo].[ScriptSetupLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Started] [smalldatetime] NOT NULL,
	[Duration] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[Error] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Scripts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

