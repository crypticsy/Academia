-- initial query for syntax formating

set lines 256
set trimout on
set tab off
set pagesize 100
set colsep " | "

-- Display data for all tables in  database

SELECT * FROM Assignment_Result;
SELECT * FROM Assignment;
SELECT * FROM Grade;
SELECT * FROM Fee_payment;
SELECT * FROM Department;
SELECT * FROM Module_Student;
SELECT * FROM Module_Teacher;
SELECT * FROM Module;
SELECT * FROM Attendance;
SELECT * FROM Student;
SELECT * FROM Teacher;
SELECT * FROM Address_Person;
SELECT * FROM Address;
SELECT * FROM Person;
