-- Reset the complete database

-- Drop all tables
DROP TABLE Assignment_Result;
DROP TABLE Assignment;
DROP TABLE Grade;
DROP TABLE Fee_payment;
DROP TABLE Department;
DROP TABLE Module_Student;
DROP TABLE Module_Teacher;
DROP TABLE Module;
DROP TABLE Attendance;
DROP TABLE Student;
DROP TABLE Teacher;
DROP TABLE Address_Person;
DROP TABLE Address;
DROP TABLE Person;

-- Drop all sequences
DROP SEQUENCE Person_Sequence;
DROP SEQUENCE Address_Sequence;
DROP SEQUENCE Module_Sequence;
DROP SEQUENCE Department_Sequence;
DROP SEQUENCE Fee_Payment_Sequence;
DROP SEQUENCE Assignment_Sequence;
DROP SEQUENCE Attendance_Sequence;
