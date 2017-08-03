CREATE TABLE [dbo].[TableDefinition](
[RegionCode] [nvarchar](15) NOT NULL,
	[OfficeCode] [nvarchar](15) NOT NULL,
	[BusinessType] [nvarchar](15) NOT NULL,
	[BusinessCode] [nvarchar](15) NOT NULL,
	[DocumentType] [nvarchar](15) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[ColumnName] [nvarchar](50) NOT NULL,
	[DataType] [nvarchar](50) NOT NULL,
	[PrimaryKey] [nchar](1) NOT NULL,
	[AllowNulls] [nchar](1) NOT NULL,
	[SerialNo] [numeric](4, 0) NOT NULL,
	[ColumnNameAudit] [nvarchar](50) NULL,
 CONSTRAINT [PK_TableDefinition] PRIMARY KEY CLUSTERED 
(
	[RegionCode] ASC,
	[OfficeCode] ASC,
	[BusinessType] ASC,
	[BusinessCode] ASC,
	[DocumentType] ASC,
	[TableName] ASC,
	[ColumnName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-------------
CREATE TABLE [dbo].[ClientMaster](
	[RegionCode] [nvarchar](15) NOT NULL,
	[OfficeCode] [nvarchar](15) NOT NULL,
	[BusinessType] [nvarchar](15) NOT NULL,
	[BusinessCode] [nvarchar](15) NOT NULL,
	[DocumentType] [nvarchar](15) NOT NULL,
	[ClientCode] [nvarchar](15) NOT NULL,
	[ClientName] [varchar](50) NULL,
	[LicenceNo] [varchar](50) NULL,
	[DateCreated] [date] NULL,
	[CurrentDate] [date] NULL,
	[Address] [varchar](50) NULL

 CONSTRAINT [PK_ClientMaster] PRIMARY KEY CLUSTERED 
(
	[RegionCode] ASC,
	[OfficeCode] ASC,
	[BusinessType] ASC,
	[BusinessCode] ASC,
	[DocumentType] ASC,
	[ClientCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-------------
CREATE TABLE [dbo].[ClientLog](
	[RegionCode] [nvarchar](15) NOT NULL,
	[OfficeCode] [nvarchar](15) NOT NULL,
	[BusinessType] [nvarchar](15) NOT NULL,
	[BusinessCode] [nvarchar](15) NOT NULL,
	[DocumentType] [nvarchar](15) NOT NULL,
	[ClientCode] [nvarchar](15) NOT NULL,
	[ClientSubCode] [varchar](15) NULL,
	[DTableName] [varchar](50) NULL,
	[DFieldName] [varchar](50) NULL,
	[FunctionCode] [varchar](15) NULL

 CONSTRAINT [PK_ClientLog] PRIMARY KEY CLUSTERED 
(
	[RegionCode] ASC,
	[OfficeCode] ASC,
	[BusinessType] ASC,
	[BusinessCode] ASC,
	[DocumentType] ASC,
	[ClientCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-------------Do we have to add Client Code?
CREATE TABLE [dbo].[ChangeLog1](
	[RegionCode] [nvarchar](15) NOT NULL,
	[OfficeCode] [nvarchar](15) NOT NULL,
	[BusinessType] [nvarchar](15) NOT NULL,
	[BusinessCode] [nvarchar](15) NOT NULL,
	[DocumentType] [nvarchar](15) NOT NULL,
	[DTableName] [varchar](50) NOT NULL,
	[DFieldName] [varchar](50) NOT NULL,
	[FunctionCode] [varchar](15) NULL,
	[DateCreated] [date] NULL,
 CONSTRAINT [PK_ChangeLog1] PRIMARY KEY CLUSTERED 
(
	[RegionCode] ASC,
	[OfficeCode] ASC,
	[BusinessType] ASC,
	[BusinessCode] ASC,
	[DocumentType] ASC,
	[DTableName] ASC,
	[DFieldName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
------------------
CREATE TABLE [dbo].[CR](
	[RegionCode] [nvarchar](15) NOT NULL,
	[OfficeCode] [nvarchar](15) NOT NULL,
	[BusinessType] [nvarchar](15) NOT NULL,
	[BusinessCode] [nvarchar](15) NOT NULL,
	[DocumentType] [nvarchar](15) NOT NULL,
	[CRNo] [varchar](50) NOT NULL,
	[SNo] [varchar](50) NOT NULL,
	[ClientCode] [varchar](15) NULL,
	[ShortDescription] [varchar](50) NULL,
	[DetailDescription] [varchar](200) NULL,
	[CollectedFrom] [varchar](50) NULL,
	[CollectedBy] [varchar](50)  NULL,
	[CollectedCreated] [date] NULL,
	[RequestedDate] [date] NULL,
 CONSTRAINT [PK_CR] PRIMARY KEY CLUSTERED 
(
	[RegionCode] ASC,
	[OfficeCode] ASC,
	[BusinessType] ASC,
	[BusinessCode] ASC,
	[DocumentType] ASC,
	[CRNo] ASC,
	[SNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------
CREATE TABLE [dbo].[TR](
	[RegionCode] [nvarchar](15) NOT NULL,
	[OfficeCode] [nvarchar](15) NOT NULL,
	[BusinessType] [nvarchar](15) NOT NULL,
	[BusinessCode] [nvarchar](15) NOT NULL,
	[DocumentType] [nvarchar](15) NOT NULL,
	[TRNo] [varchar](50) NOT NULL,
	[SNo] [varchar](50) NOT NULL,
	[ClientCode] [varchar](15) NULL,
	[CRNo] [varchar](50) NULL,
	[DTableName] [varchar](50) NULL,
	[DFieldName] [varchar](50)  NULL,
 CONSTRAINT [PK_TR] PRIMARY KEY CLUSTERED 
(
	[RegionCode] ASC,
	[OfficeCode] ASC,
	[BusinessType] ASC,
	[BusinessCode] ASC,
	[DocumentType] ASC,
	[TRNo] ASC,
	[SNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------END OF FILE

/****** Object:  Table [dbo].[Role]    Script Date: 04/17/2012 12:48:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [smallint] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](30) NOT NULL,
	[IsEnabled] [bit] NULL,
	[AuditUserID] [int] NULL,
	[AuditDate] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF

/****** Object:  StoredProcedure [dbo].[spGetRolesList]    Script Date: 04/17/2012 12:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRolesList]
AS
BEGIN
	SELECT RoleID, RoleName AS [Role]
	FROM [Role]
	WHERE IsEnabled = 1
END
GO
/****** Object:  StoredProcedure [dbo].[spGetRoles]    Script Date: 04/17/2012 12:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRoles]
(
	@RoleID int
)
AS
BEGIN
	SELECT RoleID, RoleName AS [Role], IsEnabled, AuditUserID, AuditDate
	FROM [Role]
	WHERE RoleID = @RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetRoleList]    Script Date: 04/17/2012 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRoleList]
AS
BEGIN
	SELECT RoleID = 0, RoleName = '--Select--'
	UNION
	SELECT RoleID, RoleName
	FROM [Role]
	WHERE IsEnabled = 1
	ORDER BY RoleName
END
GO

/****** Object:  StoredProcedure [dbo].[spGetEnabledDisabledRoles]    Script Date: 04/17/2012 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetEnabledDisabledRoles]
(
	@EnableDisable bit
)
AS
BEGIN
	SELECT RoleID, RoleName AS [Role], AuditUserID, IsEnabled, AuditDate
	FROM [Role]
	WHERE IsEnabled = @EnableDisable
	ORDER BY [RoleName]
END
GO

/****** Object:  StoredProcedure [dbo].[spEnableDisableRoles]    Script Date: 04/17/2012 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spEnableDisableRoles]
(
	@RoleID			int,
	@EnableDisable	bit
)
AS
BEGIN
	BEGIN TRANSACTION

	UPDATE [Role]
	SET IsEnabled = @EnableDisable
	WHERE RoleID = @RoleID

	IF @@ERROR > 0 GOTO PROBLEM
	COMMIT TRANSACTION
	RETURN 0

PROBLEM:
	ROLLBACK TRANSACTION
	RETURN -1
END
GO


/****** Object:  StoredProcedure [dbo].[spAddRoles]    Script Date: 04/17/2012 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddRoles]
(
	@Role			varchar(100),
	@AuditUserID	int,
	@IsEnabled		bit
)
AS
BEGIN
	INSERT INTO [Role]
	(
		[RoleName], AuditUserId, AuditDate, IsEnabled
	)
	VALUES
	(
		@Role, @AuditUserID, GETDATE(), @IsEnabled
	)

	IF @@ERROR > 0 GOTO PROBLEM
	RETURN 0

PROBLEM:
	RETURN -1
END
GO

/****** Object:  StoredProcedure [dbo].[spUpdateRoles]    Script Date: 04/17/2012 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateRoles]
(
	@RoleID			int,
	@Role			varchar(100),
	@AuditUserID	int
)
AS
BEGIN
	UPDATE [Role]
	SET RoleName = @Role,
	AuditDate = GETDATE()
	WHERE RoleID = @RoleID
	
	IF @@ERROR > 0 GOTO PROBLEM
	RETURN 0
PROBLEM:
	RETURN -1
END
GO

/****** Object:  StoredProcedure [dbo].[spDeleteRoles]    Script Date: 04/17/2012 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteRoles]
(
	@RoleID	int
)
AS
BEGIN
	-- TRANSACTION HANDLED IN THE Unit CLASS FILE
	DELETE FROM [Role]
	WHERE RoleID = @RoleID
	
	IF @@ERROR > 0 GOTO PROBLEM
	RETURN 0

PROBLEM:
	RETURN -1
END
GO