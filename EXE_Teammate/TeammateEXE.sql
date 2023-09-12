USE [master]

--Use this query when error "Cannot drop database because it is currently in use."
ALTER DATABASE [TeammateEXE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE

GO
DROP DATABASE IF EXISTS [TeammateEXE]

GO
CREATE DATABASE [TeammateEXE]

GO
USE [TeammateEXE]

CREATE TABLE [dbo].[Major](
	[MajorCode] [nvarchar](255) NOT NULL UNIQUE,
	[MajorName] [nvarchar](255) NOT NULL UNIQUE,
	[MajorDescription] [nvarchar](255),
	[isDeleted] [bit],

	CONSTRAINT PK_Major PRIMARY KEY ([MajorCode])
)


CREATE TABLE [dbo].[Grade](
	[GradeCode] [nvarchar](255) NOT NULL UNIQUE,
	[GradeDescription] [nvarchar](255),
	[GradeStartDate] [date],
	[GradeEndDate] [date],
	[isDeleted] [bit],

	CONSTRAINT PK_Grade PRIMARY KEY ([GradeCode])
)

CREATE TABLE [dbo].[Student](
	[StudentId] [nvarchar](255) NOT NULL UNIQUE,
	[MajorCode] [nvarchar](255) NOT NULL REFERENCES [Major](MajorCode) on delete cascade on update cascade,
	[GradeCode] [nvarchar](255) NOT NULL REFERENCES [Grade](GradeCode) on delete cascade on update cascade,
	[StudentFullName] [nvarchar](255),
	[StudentPhone] [int] NOT NULL UNIQUE,
	[StudentEmail] [nvarchar](255) NOT NULL UNIQUE,
	[StudentGender] bit,
	[isDeleted] [bit],

	CONSTRAINT PK_Student PRIMARY KEY ([StudentId])
)

CREATE TABLE [dbo].[Subject](
	[SubjectCode] [nvarchar](255) UNIQUE,
	[SubjectDescription] [nvarchar](255),
	[isDeleted] [bit],

	CONSTRAINT PK_Subject PRIMARY KEY ([SubjectCode])

)

CREATE TABLE [dbo].[Semester](
	[SemesterCode] [nvarchar](255) NOT NULL UNIQUE,
	[SemesterStartDate] [date],
	[SemesterEndDate] [date],
	[SemesterDescription] [nvarchar](255),
	[isDeleted] [bit],

	CONSTRAINT PK_Semester PRIMARY KEY ([SemesterCode])

)

CREATE TABLE [dbo].[Course](
	[CourseCode] [nvarchar](255) NOT NULL UNIQUE,
	[SubjectCode] [nvarchar](255) NOT NULL REFERENCES [Subject](SubjectCode) on delete cascade on update cascade,
	[SemesterCode] [nvarchar](255) NOT NULL REFERENCES [Semester](SemesterCode) on delete cascade on update cascade,
	[CourseStartDate] [date],
	[CourseEndDate] [date],
	[isDeleted] [bit],

	CONSTRAINT PK_Course PRIMARY KEY ([CourseCode])
)

CREATE TABLE [dbo].[StudentInCourse](
	[SICId] [nvarchar](255) NOT NULL REFERENCES [Student](StudentId) on delete cascade on update cascade,
	[CourseCode] [nvarchar](255) NOT NULL REFERENCES [Course](CourseCode) on delete cascade on update cascade,
	[isInTeam] [bit],
	[isDeleted] [bit],

	CONSTRAINT PK_StudentInCourse PRIMARY KEY ([SICId])

)

CREATE TABLE [dbo].[Team](
	[TeamName] [nvarchar](255) NOT NULL UNIQUE,
	[LeaderId] [int] NOT NULL,
	[CreateDate] [date],
	[NumberOfMembers] [int] NOT NULL,
	[isDeleted] [bit],

	CONSTRAINT PK_Team PRIMARY KEY ([TeamName])
)

CREATE TABLE [dbo].[Teammate](
	[TeammateId] [nvarchar](255) NOT NULL REFERENCES [StudentInCourse](SICId) on delete cascade on update cascade,
	[TeamName] [nvarchar](255) NOT NULL REFERENCES [Team](TeamName) on delete cascade on update cascade,
	[TeammateRole] [int],
	[TeammateJoinDate] [date],
	[isDeleted] [bit], 

	CONSTRAINT PK_Teammate PRIMARY KEY ([TeammateId])

)

CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [int] IDENTITY (1, 1),
	[TeammateId] [nvarchar](255) NOT NULL REFERENCES [Teammate](TeammateId) on delete cascade on update cascade,
	[TeammateFeedbackId] [nvarchar](255) NOT NULL,
	[Score1] [int],
	[Score2] [int],
	[Score3] [int],
	[Comment] [nvarchar](255),
	[isDeleted] [bit],

	CONSTRAINT PK_Feedback PRIMARY KEY ([FeedbackId])
)

CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY (1, 1),
	[TeamName] [nvarchar](255) NOT NULL REFERENCES [Team](TeamName) on delete cascade on update cascade,
	[TaskName] [nvarchar](255),
	[TaskDescription] [nvarchar](255),
	[TaskStartDate] [datetime],
	[TaskEndDate] [datetime],
	[ProductLink] [nvarchar](255),
	[Status] [int],
	[isDeleted] [bit],

	CONSTRAINT PK_Task PRIMARY KEY ([TaskId])
)



CREATE TABLE [dbo].[TaskParticipant](
	[TPId] [int] IDENTITY (1, 1),
	[TeammateId] [nvarchar](255) NOT NULL REFERENCES [Teammate](TeammateId),
	[TaskId] [int] NOT NULL REFERENCES [Task](TaskId) on delete cascade on update cascade,
	[isDeleted] [bit],
	CONSTRAINT PK_TaskPariticipant PRIMARY KEY ([TPId])
)



