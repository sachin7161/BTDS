create database BTDSDb
use BTDSDb





CREATE TABLE Gates
(
    GateId INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(20) NOT NULL UNIQUE,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    SequenceNo INT NOT NULL,
    DurationWeeks INT NOT NULL DEFAULT(0),
    TotalCards INT NOT NULL DEFAULT(0),
    IsActive BIT NOT NULL DEFAULT(1),
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL,
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT(0)
);


CREATE TABLE Modules
(
     ModuleId INT IDENTITY(1,1) PRIMARY KEY,
    GateId INT , -- constraint  FK_Modules_Gates references Gates(Id) NOT NULL, 
    Code NVARCHAR(20) NOT NULL, 
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    SequenceNo INT NOT NULL,
    EstimatedHours DECIMAL(6,2) NOT NULL DEFAULT(0), 
    IsMandatory BIT NOT NULL DEFAULT(1), 
    IsActive BIT NOT NULL DEFAULT(1),
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL,
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT(0),

    CONSTRAINT UQ_Modules
        UNIQUE(GateId, Code)
);

--CREATE INDEX IX_Modules_GateId
--ON Modules(GateId);


CREATE TABLE DifficultyLevels
(
    DifficultyLevelId INT IDENTITY PRIMARY KEY, 
    Name NVARCHAR(50) NOT NULL,
    SequenceNo INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT(1),
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL,
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT(0)
);


CREATE TABLE CardTypes
(
    CardTypeId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL, 
    IsActive BIT NOT NULL DEFAULT(1),
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL, 
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL, 
    IsDeleted BIT NOT NULL DEFAULT(0)
);


CREATE TABLE Cards
(
    CardsId INT IDENTITY(1,1) PRIMARY KEY, 
    ModuleId INT NOT NULL, 
    CardTypeId INT NOT NULL, 
    DifficultyLevelId INT NOT NULL, 
    Code NVARCHAR(30) NOT NULL,
    Title NVARCHAR(300) NOT NULL,
    LearningObjective NVARCHAR(MAX), 
    Description NVARCHAR(MAX),
    EstimatedMinutes INT NOT NULL DEFAULT(30), 
    SequenceNo INT NOT NULL,
    PassingMarks DECIMAL(5,2),
    MaxMarks DECIMAL(5,2),
    IsMandatory BIT NOT NULL DEFAULT(1),
    AllowRetake BIT NOT NULL DEFAULT(1),
    IsActive BIT NOT NULL DEFAULT(1), 
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(), 
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL, 
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT(0),

  --  CONSTRAINT FK_Cards_Modules FOREIGN KEY(ModuleId) REFERENCES Modules(Id),

   -- CONSTRAINT FK_Cards_CardTypes FOREIGN KEY(CardTypeId) REFERENCES CardTypes(Id),

   -- CONSTRAINT FK_Cards_DifficultyLevels FOREIGN KEY(DifficultyLevelId) REFERENCES DifficultyLevels(Id),

    CONSTRAINT UQ_Cards UNIQUE(ModuleId, Code)
);

--CREATE INDEX IX_Cards_ModuleId ON Cards(ModuleId);

--CREATE INDEX IX_Cards_CardTypeId ON Cards(CardTypeId);





CREATE TABLE CardTasks
(
    CardTaskId INT IDENTITY PRIMARY KEY, 
    CardId INT NOT NULL, 
    Title NVARCHAR(300) NOT NULL,
    Description NVARCHAR(MAX), 
    SequenceNo INT NOT NULL, 
    EstimatedMinutes INT NOT NULL DEFAULT(10), 
    IsMandatory BIT NOT NULL DEFAULT(1), 
    IsSubmissionRequired BIT NOT NULL DEFAULT(0),
    IsApprovalRequired BIT NOT NULL DEFAULT(0),
    IsActive BIT NOT NULL DEFAULT(1),
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL, 
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT(0),
    --CONSTRAINT FK_CardTasks_Cards FOREIGN KEY(CardId) REFERENCES Cards(Id)
);

--CREATE INDEX IX_CardTasks_CardId ON CardTasks(CardId);



CREATE TABLE ResourceTypes
(
    ResourceTypeId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT(1),
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL,
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT(0)
);


CREATE TABLE CardResources
(
    CardResourceId INT IDENTITY PRIMARY KEY,
    CardId INT NOT NULL,
    ResourceTypeId INT NOT NULL,
    Title NVARCHAR(300) NOT NULL,
    Url NVARCHAR(1000),
    FileName NVARCHAR(300),
    FilePath NVARCHAR(1000),
    Thumbnail NVARCHAR(500),
    SequenceNo INT NOT NULL,
    IsDownloadable BIT NOT NULL DEFAULT(1),
    IsActive BIT NOT NULL DEFAULT(1),
    CreatedBy INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedBy INT NULL,
    UpdatedAt DATETIME2 NULL,
    DeletedBy INT NULL,
    DeletedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT(0)
    --CONSTRAINT FK_CardResources_Cards FOREIGN KEY(CardId) REFERENCES Cards(Id),
    --CONSTRAINT FK_CardResources_ResourceTypes FOREIGN KEY(ResourceTypeId) REFERENCES ResourceTypes(Id)
);

--CREATE INDEX IX_CardResources_CardId ON CardResources(CardId);



1. Students

Exam देणारे विद्यार्थी.

student
-------
StudentId          bigint Identity Primary Key
FullName        varchar(100)      NOT NULL
Email           varchar(100)      NOT NULL UNIQUE
PasswordHash    varchar(500)      NOT NULL
Mobile          varchar(15)       NOT NULL
Qualification   varchar(50)       NOT NULL
College         varchar(150)      NOT NULL
IsActive        bit               DEFAULT 1
CreatedAt       datetime          DEFAULT GETDATE()




2. ExamCategories

Exam चे प्रकार.
-----------------------------------

CategoryId   int Identity Primary Key
Name         varchar(50) NOT NULL UNIQUE
Description  varchar(250) NULL
IsActive     bit DEFAULT 1
CreatedAt    datetime DEFAULT GETDATE()




3. Exams

Exam ची माहिती.

ExamId              bigint Identity Primary Key
CategoryId          int Not Null
Title               varchar(150) Not Null
Description         varchar(500) Null
DurationMinutes     int Not Null
TotalMarks          int Not Null
PassingMarks        int Not Null
TotalQuestions      int Not Null
MaxAttempts         int Default 1
RandomQuestions     bit Default 0
RandomOptions       bit Default 0
NegativeMarking     bit Default 0
NegativeMarks       decimal(5,2) Default 0
StartDate           datetime Null
EndDate             datetime Null
IsPublished         bit Default 0
CreatedAt           datetime Default GETDATE()
UpdatedAt           datetime Null
IsDeleted           bit Default 0



4. Questions

Question Bank.

QuestionId          bigint Identity Primary Key
ExamId              bigint Not Null
QuestionText        varchar(MAX) Not Null
QuestionType        varchar(20) Not Null
Marks               decimal(5,2) Default 1
Explanation         varchar(MAX) Null
DifficultyLevel     varchar(20) Default 'Easy'
SequenceNo          int Default 1
IsActive            bit Default 1
CreatedAt           datetime Default GETDATE()
UpdatedAt           datetime Null

5. QuestionOptions

फक्त MCQ साठी.

OptionId        bigint Identity Primary Key
QuestionId      bigint Not Null
OptionText      varchar(500) Not Null
IsCorrect       bit Default 0
SequenceNo      int Not Null
CreatedAt       datetime Default GETDATE()



6. ExamInstructions

Exam सुरू होण्यापूर्वी Rules.

InstructionId      bigint Identity Primary Key
ExamId             bigint Not Null
Instruction        varchar(500) Not Null
SequenceNo         int Not Null
CreatedAt          datetime Default GETDATE()

7. ExamAttempts

Student ने Exam Start केला.

AttemptId       bigint Identity Primary Key
UserId          bigint Not Null
ExamId          bigint Not Null
AttemptNo       int Default 1
StartedAt       datetime Not Null
SubmittedAt     datetime Null
TimeTaken       int Null
TotalMarks      decimal(5,2) Not Null
ObtainedMarks   decimal(5,2) Default 0
Percentage      decimal(5,2) Default 0
Result          varchar(10) Null
Status          varchar(20) Default 'InProgress'
CreatedAt       datetime Default GETDATE()



8. StudentAnswers

Student ची उत्तरे.

StudentAnswerId     bigint Identity Primary Key
AttemptId           bigint Not Null
QuestionId          bigint Not Null
SelectedOptionId    bigint Not Null
MarksObtained       decimal(5,2) Default 0
IsCorrect           bit Default 0
AnsweredAt          datetime Default GETDATE()
CreatedAt           datetime Default GETDATE()



select * from Gates

select * from Modules

select * from DifficultyLevels

select * from CardTypes
select * from Cards
select * from CardTasks

select * from ResourceTypes

select * from CardResources
