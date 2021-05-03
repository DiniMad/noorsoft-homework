DROP DATABASE NoorsoftHomework
GO

CREATE DATABASE NoorsoftHomework
GO

USE NoorsoftHomework
GO

CREATE TABLE Employee (
	Id int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(255) NOT NULL,
	LastName nvarchar(255) NOT NULL,
	BirthDate date NOT NULL,
	RecruitmentDate date NOT NULL,
	SupervisorId int FOREIGN KEY REFERENCES Employee(Id)
	)
GO

CREATE TABLE ChangeLogType(
	Id TINYINT PRIMARY KEY,
	LogType VARCHAR(10) NOT NULL
	)
GO

INSERT INTO ChangeLogType VALUES (1,'Inserted'), (2,'Modified'), (3,'Deleted')
GO

CREATE TABLE ChangeLog(
	Id int PRIMARY KEY IDENTITY(1,1),
	DateTime datetimeoffset(0),
	ChangeLogType TINYINT FOREIGN KEY REFERENCES ChangeLogType(Id),
	EffectedRecordId int,
	ModifiedFirstName nvarchar(255),
	ModifiedLastName nvarchar(255),
	ModifiedBirthDate date,
	ModifiedRecruitmentDate date,
	ModifiedSupervisorId int
	)
GO

CREATE PROCEDURE AuditLog
	@ChangeLogType TINYINT,
	@EffectedRecordId int,
	@ModifiedFirstName nvarchar(255),
	@ModifiedLastName nvarchar(255),
	@ModifiedBirthDate date,
	@ModifiedRecruitmentDate date,
	@ModifiedSupervisorId int
AS
INSERT INTO ChangeLog (DateTime,ChangeLogType,EffectedRecordId,ModifiedFirstName,ModifiedLastName,ModifiedBirthDate,ModifiedRecruitmentDate,ModifiedSupervisorId)
			VALUES (SYSDATETIMEOFFSET(), @ChangeLogType, @EffectedRecordId, @ModifiedFirstName, @ModifiedLastName, @ModifiedBirthDate, @ModifiedRecruitmentDate, @ModifiedSupervisorId)
GO

CREATE PROCEDURE GetEmployees 
	@ColumnNameToOrderBy VARCHAR(20), 
	@DirectionToOrderBy VARCHAR(4), 
	@Offset int,
	@Count int
AS
DECLARE @query VARCHAR(MAX) = 'SELECT * FROM Employee ORDER BY ' + @ColumnNameToOrderBy + ' ' + @DirectionToOrderBy +
							  ' OFFSET ' + CAST(@Offset AS varchar) + ' ROWS FETCH FIRST ' + CAST(@Count AS varchar) + ' ROWS ONLY;'
EXEC (@query)
GO

CREATE PROCEDURE GetEmployeesCount 
AS
SELECT COUNT(Id) FROM Employee
GO



CREATE PROCEDURE InsertEmployee
	@FirstName nvarchar(255),
	@LastName nvarchar(255),
	@BirthDate date,
	@RecruitmentDate date,
	@SupervisorId int
AS
BEGIN TRANSACTION [InsertEmployee]
	BEGIN TRY
		INSERT INTO Employee (FirstName, LastName, BirthDate, RecruitmentDate, SupervisorId) VALUES (@FirstName, @LastName, @BirthDate, @RecruitmentDate, @SupervisorId)
		DECLARE @effectedRecordId INT = SCOPE_IDENTITY()
		EXEC AuditLog @ChangeLogType = 1, @EffectedRecordId = @effectedRecordId, @ModifiedFirstName = @FirstName, @ModifiedLastName = @LastName,
					  @ModifiedBirthDate = @BirthDate, @ModifiedRecruitmentDate = @RecruitmentDate, @ModifiedSupervisorId = @SupervisorId
		COMMIT TRANSACTION [InsertEmployee]
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [InsertEmployee]

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
GO

CREATE PROCEDURE UpdateEmployee
	@Id int,
	@FirstName nvarchar(255),
	@LastName nvarchar(255),
	@BirthDate date,
	@RecruitmentDate date,
	@SupervisorId int
AS
BEGIN TRANSACTION [UpdateEmployee]
	BEGIN TRY
		UPDATE Employee SET FirstName = @FirstName,LastName = @LastName,BirthDate = @BirthDate,RecruitmentDate = @RecruitmentDate,SupervisorId = @SupervisorId WHERE Id = @Id
		EXEC AuditLog @ChangeLogType = 2, @EffectedRecordId = @Id, @ModifiedFirstName = @FirstName, @ModifiedLastName = @LastName,
					  @ModifiedBirthDate = @BirthDate, @ModifiedRecruitmentDate = @RecruitmentDate, @ModifiedSupervisorId = @SupervisorId

		COMMIT TRANSACTION [UpdateEmployee]
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [UpdateEmployee]

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
GO

CREATE PROCEDURE DeleteEmployee
	@Id int
AS
BEGIN TRANSACTION [DeleteEmployee]
	BEGIN TRY
		DELETE FROM Employee WHERE Id = @Id
		EXEC AuditLog @ChangeLogType = 3, @EffectedRecordId = @Id, @ModifiedFirstName = NULL, @ModifiedLastName = NULL,
					  @ModifiedBirthDate = NULL, @ModifiedRecruitmentDate = NULL, @ModifiedSupervisorId = NULL

		COMMIT TRANSACTION [DeleteEmployee]
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [DeleteEmployee]

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
GO