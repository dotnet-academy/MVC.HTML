SET XACT_ABORT ON;  

CREATE DATABASE [Movies];
GO

BEGIN TRANSACTION;

USE [Movies];

CREATE TABLE [ContentRating] (
	[ContentRatingId] TINYINT NOT NULL,
	[Symbol] VARCHAR(5) NOT NULL,
	[ShortDescription] NVARCHAR(64) NOT NULL,
	[LongDescription] NVARCHAR(256) NULL

	CONSTRAINT [PK_ContentRating] PRIMARY KEY ([ContentRatingId]),
	CONSTRAINT [AK_ContentRating_Name] UNIQUE ([Symbol])
);

CREATE TABLE [Actor] (
	[ActorId] INT NOT NULL IDENTITY,
	[FirstName] NVARCHAR(40) NULL,
	[LastName] NVARCHAR(40) NULL,
	[ProfilePictureUrl] NVARCHAR(256) NULL,
	[ShortBio] NVARCHAR(256) NULL,
	[Birthday] DATE NULL,

	CONSTRAINT [PK_Actor] PRIMARY KEY ([ActorId])
);

CREATE TABLE [Movie] (
	[MovieId] INT NOT NULL IDENTITY,
	[Title] NVARCHAR(100) NOT NULL,
	[Revenue] DECIMAL(14,2) NULL,
	[PosterUrl] NVARCHAR(256) NULL,
	[VideoUrl] NVARCHAR(256) NULL,
	[VideoPosterUrl] NVARCHAR(256) NULL,
	[Summary] NVARCHAR(1024) NULL,
	[ReleaseDate] DATE NULL,
	[ContentRatingId] TINYINT NOT NULL,

	CONSTRAINT [PK_Movie] PRIMARY KEY ([MovieId]),
	CONSTRAINT [FK_Movie_ContentRating_ContentRatingId]
		 FOREIGN KEY ([ContentRatingId]) REFERENCES [ContentRating] ([ContentRatingId])
);

CREATE TABLE [MovieActor] (
	[MovieId] INT NOT NULL,
	[ActorId] INT NOT NULL,

	CONSTRAINT [PK_MovieActor] PRIMARY KEY ([MovieId], [ActorId]),
	CONSTRAINT [FK_MovieActor_Movie_MovieId]
		 FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([MovieId]),
	CONSTRAINT [FK_MovieActor_Actor_ActorId]
		 FOREIGN KEY ([ActorId]) REFERENCES [Actor] ([ActorId]),
);

CREATE TABLE [Review] (
	[ReviewId] INT NOT NULL,
	[MovieId] INT NOT NULL,
	[Reviewer] NVARCHAR(100) NOT NULL,
	[Text] NVARCHAR(1024) NOT NULL,
	[Score] DECIMAL(3,1) NOT NULL,

	CONSTRAINT [PK_Review] PRIMARY KEY ([ReviewId]),
	CONSTRAINT [FK_Review_Movie_MovieId]
		 FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([MovieId])
);

ALTER TABLE [Review] ADD CONSTRAINT CC_Review_Score   
   CHECK (Score >= 0 AND Score <= 10);  
GO 

COMMIT TRANSACTION;