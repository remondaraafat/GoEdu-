﻿--instructor
INSERT INTO Instructors (Name, Email, Age, Address, Phone, isDeleted)
VALUES (N'خالد', N'[email protected]', 40, N'الرياض', N'0501234567', 0);

INSERT INTO Instructors (Name, Email, Age, Address, Phone, isDeleted)
VALUES (N'منى', N'[email protected]', 35, N'جدة', N'0509876543', 0);
--course
INSERT INTO Courses ([Name], Price, [Hours], MaxViews, CourseLevel, StudentStage, StudentLevel, InstructorID, isDeleted,Semester)
VALUES (N'أساسيات البرمجة', 1000, 30, 100, 6, 1, 1, 1, 0,1);

INSERT INTO Courses ([Name], Price, [Hours], MaxViews, CourseLevel, StudentStage, StudentLevel, InstructorID, isDeleted,Semester)
VALUES (N'قواعد البيانات', 1500, 40, 200, 10, 1, 1, 2, 0,1);
--lecture
INSERT INTO Lectures (Title, VideoURL, LectureTime, Description, isDeleted, CourseID)
VALUES 
(N'مقدمة في البرمجة', N'http://example.com/intro.mp4', '2025-04-04 10:00:00.0000000', N'مقدمة عامة عن أساسيات البرمجة', 0, 6),

(N'تصميم الجداول', N'http://example.com/dbdesign.mp4', '2025-04-05 14:30:00.0000000', N'شرح مبادئ تصميم الجداول وعلاقاتها في قواعد البيانات', 0, 7);

--select
SELECT ID, Name FROM Courses;