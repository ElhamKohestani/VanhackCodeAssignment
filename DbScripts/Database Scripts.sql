

USE [BaseCodeTest]
GO


CREATE SCHEMA CRS;
GO

CREATE TABLE CRS.CourseCategory
(
	ID SMALLINT IDENTITY(1,1) NOT NULL,
	CategoryIdentifier VARCHAR(60) NOT NULL,

	CreatedOn DATETIME2 NOT NULL,
	CreatedBy BIGINT NOT NULL
);
ALTER TABLE CRS.CourseCategory ADD CONSTRAINT PK_CourseCategoryID PRIMARY KEY (ID);
ALTER TABLE CRS.CourseCategory ADD CONSTRAINT DF_CourseCategoryCreatedOn DEFAULT GETDATE() FOR CreatedOn;


CREATE TABLE CRS.Course
(
	ID INT IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(250) NOT NULL,
	[Description] NVARCHAR(500),
	CategoryID SMALLINT,

	CreatedOn DATETIME2 NOT NULL,
	CreatedBy BIGINT NOT NULL
);

ALTER TABLE CRS.Course ADD CONSTRAINT PK_CourseID PRIMARY KEY (ID);
ALTER TABLE CRS.Course ADD CONSTRAINT FK_CourseCategoryID FOREIGN KEY (CategoryID) REFERENCES
CRS.CourseCategory (ID) ON DELETE SET NULL;

ALTER TABLE CRS.Course ADD CONSTRAINT DF_CourseCreatedOn DEFAULT GETDATE() FOR CreatedOn;

CREATE TABLE CRS.CourseRecordings
(
	ID INT IDENTITY(1,1),
	Title NVARCHAR(250) NOT NULL,
	[Description] NVARCHAR(500),
	[Order] SMALLINT NOT NULL,
	Link NVARCHAR(max),
	CourseID INT,

	CreatedOn DATETIME2 NOT NULL,
	CreatedBy BIGINT NOT NULL
);

ALTER TABLE CRS.CourseRecordings ADD CONSTRAINT PK_CourseRecordingID PRIMARY KEY (ID);

ALTER TABLE CRS.CourseRecordings ADD CONSTRAINT FK_CourseRecordingCourseID FOREIGN KEY (CourseID) REFERENCES
CRS.Course (ID) ON DELETE SET NULL;

ALTER TABLE CRS.CourseRecordings ADD CONSTRAINT DF_CourseRecordingCreatedOn DEFAULT GETDATE() FOR CreatedOn;





-- Implementation of the bridge table for the *:* relationship of a Course can be accessed by 1..* roles and a role can have access to 0..* courses
CREATE TABLE CRS.CourseAccessLevel
(
	ID INT IDENTITY(1,1) NOT NULL,
	CourseID INT NOT NULL,
	RoleID INT NOT NULL
);

ALTER TABLE CRS.CourseAccessLevel ADD CONSTRAINT PK_CourseAccessLevel_ID PRIMARY KEY (ID);
ALTER TABLE CRS.CourseAccessLevel ADD CONSTRAINT FK_CourseAccessLevel_CourseID FOREIGN KEY(CourseID)
REFERENCES CRS.Course (ID) ON DELETE CASCADE;



-- initial seeding.
INSERT INTO CRS.CourseCategory(CategoryIdentifier, CreatedOn, CreatedBy) VALUES 
('Language Preparation Courses', GETDATE(), 1), 
('Job Interview Courses', GETDATE(), 1);


