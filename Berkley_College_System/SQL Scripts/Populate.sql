-- Insert Data into Independent Tables

INSERT ALL
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('John', 'Green', TO_DATE('19/1/1998', 'DD/MM/YYYY'), 'Male', 'john@green.com', '9861222332')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Aryan', 'Jayanta', TO_DATE('3/3/1997', 'DD/MM/YYYY'), 'Male', 'j_aryan@yahoo.com', '9816603353')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Amita', 'Rayen', TO_DATE('11/5/1982', 'DD/MM/YYYY'), 'Female', 'amitaa_@gmail.com', '9774235065')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Akansha', 'Kanti', TO_DATE('23/3/1934', 'DD/MM/YYYY'), 'Female', 'akan_kan@gmail.com', '9771913033')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Sumit', 'Dhananjay', TO_DATE('22/2/1953', 'DD/MM/YYYY'), 'Male', 'sumit_dj@hotmail.com', '9792998026')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Veda', 'Jyothi', TO_DATE('15/7/1956', 'DD/MM/YYYY'), 'Female', 'veda_j@gmail.com', '9757112134')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Shivali', 'Basuda', TO_DATE('13/8/1957', 'DD/MM/YYYY'), 'Female', 'shiva_metoo@yahoo.com', '9785211050')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Jaywant', 'Chandan', TO_DATE('24/2/1995', 'DD/MM/YYYY'), 'Male', 'jeywant.chandan@gmail.com', '9771481431')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Vikram', 'Awali', TO_DATE('4/3/1993', 'DD/MM/YYYY'), 'Male', 'viki_awali@gmail.com', '9772547404')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Kishor', 'Thapa', TO_DATE('19/5/1969', 'DD/MM/YYYY'), 'Male', 'kishwo_t@gmail.com', '9767051704')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Praveena', 'Rathore', TO_DATE('13/5/1979', 'DD/MM/YYYY'), 'Other', 'pravina_rr@hotmail.com', '9715239112')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Samantha', 'Upathya', TO_DATE('14/6/1997', 'DD/MM/YYYY'), 'Female', 'samantha_u@gmail.com', '9755957074')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Ankita', 'Lilavita', TO_DATE('27/2/1955', 'DD/MM/YYYY'), 'Female', 'guitarhead_ankita123@gmail.com', '9741583012')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Devak', 'Nanook', TO_DATE('22/3/1961', 'DD/MM/YYYY'), 'Other', 'dev_133nanook@gmail.com', '9760623035')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Abha', 'Meitha', TO_DATE('21/10/1964', 'DD/MM/YYYY'), 'Female', 'abha_meth@gmail.com', '9783955742')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Neeraj', 'Narayan', TO_DATE('17/1/1974', 'DD/MM/YYYY'), 'Male', 'nar.neeraj@gmail.com', '9755292774')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Manoj', 'Shasant', TO_DATE('15/4/1977', 'DD/MM/YYYY'), 'Male', 'shashant_manoj@hotmail.com', '9771887378')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Hari', 'Narayan', TO_DATE('24/7/1957', 'DD/MM/YYYY'), 'Male', 'narayan_h@yahoo.com', '9780536533')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Suresh', 'Gewali', TO_DATE('25/6/1987', 'DD/MM/YYYY'), 'Male', 'suuresh@hotmail.com', '9771835678')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Manish', 'Piya', TO_DATE('24/3/1997', 'DD/MM/YYYY'), 'Male', 'manish_piya@yahoo.com', '9780436534')
    INTO Person (First_Name, Last_Name, DOB, Gender, Email, Phone_Number) VALUES('Himesh', 'Raut', TO_DATE('24/3/1997', 'DD/MM/YYYY'), 'Male', 'himesh@yahoo.com', '9780434434')
SELECT 1 FROM dual;


INSERT ALL 
    INTO Address(Country, Street, ZIP_Code) VALUES('Nepal', 'Willow Street, Kathmandu', '44700')
    INTO Address(Country, Street, ZIP_Code) VALUES('United States of America', '5th Street, Pennsylvania Avenue, Virginia', '88390')
    INTO Address(Country, Street, ZIP_Code) VALUES('Republic of the Congo', 'Franklin Street, Fieldstone', '56909')
    INTO Address(Country, Street, ZIP_Code) VALUES('Venezuela', '2nd Street East, Willow Lane, Orchard', '93730')
    INTO Address(Country, Street, ZIP_Code) VALUES('Italy', 'Elm Avenue, Lilac', '34423')
    INTO Address(Country, Street, ZIP_Code) VALUES('Venezuela', 'Broad Street West, Somerset', '93143')
    INTO Address(Country, Street, ZIP_Code) VALUES('Argentina', 'Locust Lane, Hawthorne', '35333')
    INTO Address(Country, Street, ZIP_Code) VALUES('Nepal', 'Canterbury Tole, Chitwan', '44300')
    INTO Address(Country, Street, ZIP_Code) VALUES('Trinidad and Tobago', 'Morris Street, Buckinghampton', '45902')
    INTO Address(Country, Street, ZIP_Code) VALUES('Dominican Republic', 'Maple Street, Route 6, Delawavpe', '55990')
SELECT 1 FROM dual;


INSERT ALL 
    INTO Module(Module_Name, Credit_Hours, Total_Days) VALUES('Advanced Database', 30, 15)
    INTO Module(Module_Name, Credit_Hours, Total_Days) VALUES('Software Engineering', 12, 12)
    INTO Module(Module_Name, Credit_Hours, Total_Days) VALUES('Statistics and Trigonometry', 22, 11)
    INTO Module(Module_Name, Credit_Hours, Total_Days) VALUES('Logical Reasoning and Problem Solving', 24, 12)
    INTO Module(Module_Name, Credit_Hours, Total_Days) VALUES('3D Modeling and Character Development', 13, 13)
    INTO Module(Module_Name, Credit_Hours, Total_Days) VALUES('Photography and Creative Arts', 14, 14)
    INTO Module(Module_Name, Credit_Hours, Total_Days) VALUES('Network Administration and Security', 24, 12)
SELECT 1 FROM dual;


INSERT ALL 
    INTO Department(Department_Name, Department_Type, Building, Room) VALUES('Student Accounts Department', 'Student Fee', 'Stephen A. Schwarzman Center','Maiden Floor, 1')
    INTO Department(Department_Name, Department_Type, Building, Room) VALUES('Student Service', 'Student Guide', 'Granoff Center for the Creative Arts','Creative Arts Floor, 3')
    INTO Department(Department_Name, Department_Type, Building, Room) VALUES('Student Advisor Department', 'Student Guide', 'Calhoun Lofts Center','Mansueto Floor, 4')
    INTO Department(Department_Name, Department_Type, Building, Room) VALUES('RTE Department', 'Student Assignment', 'Hoover Tower','The Commons, 14')
    INTO Department(Department_Name, Department_Type, Building, Room) VALUES('Student Council', 'Student Body', 'Student Recreation and Wellness Center','Main Campus, 7')
SELECT 1 FROM dual;


INSERT ALL 
    INTO Assignment(Assignment_Name, Assignment_Type, Assignment_Weightage) VALUES('Coursework 1: Database Management System Development in C#', 'Individual Coursework', 10.00)
    INTO Assignment(Assignment_Name, Assignment_Type, Assignment_Weightage) VALUES('Coursework 1: Linear Regression Model Questionaire', 'Unseen Examination', 25.00)
    INTO Assignment(Assignment_Name, Assignment_Type, Assignment_Weightage) VALUES('Coursework 1: Inventory Management System in C#', 'Group Coursework', 35.00)
    INTO Assignment(Assignment_Name, Assignment_Type, Assignment_Weightage) VALUES('Coursework 2: Movie Booking System Development in ASP.NET', 'Group Coursework', 50.00)
    INTO Assignment(Assignment_Name, Assignment_Type, Assignment_Weightage) VALUES('Coursework 1: SQL Queries in Oracle DBMS', 'In class Test', 40.00)
    INTO Assignment(Assignment_Name, Assignment_Type, Assignment_Weightage) VALUES('Coursework 3: Networking Model Architecture for Desired Company', 'Individual Coursework', 15.00)
SELECT 1 FROM dual;


INSERT ALL 
    INTO Grade(Grade, Status) VALUES('A', 'Pass')
    INTO Grade(Grade, Status) VALUES('B', 'Pass')
    INTO Grade(Grade, Status) VALUES('C', 'Pass')
    INTO Grade(Grade, Status) VALUES('D', 'Pass')
    INTO Grade(Grade, Status) VALUES('E', 'Pass')
    INTO Grade(Grade, Status) VALUES('F', 'Fail')
SELECT 1 FROM dual;

COMMIT;





-- Insert Data into Primary Dependent Tables

INSERT ALL 
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-1', 'P-1')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-2', 'P-2')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-3', 'P-2')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-4', 'P-3')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-5', 'P-4')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-6', 'P-5')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-7', 'P-6')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-8', 'P-7')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-9', 'P-8')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-10', 'P-9')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-4', 'P-10')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-7', 'P-11')
    INTO Address_Person(Address_ID, Person_ID) VALUES('A-2', 'P-12')
SELECT 1 FROM dual;

INSERT ALL
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-4', TO_DATE('13/1/1978', 'DD/MM/YYYY'), 'Full Time', 'Lecturer', 39000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-5', TO_DATE('5/2/1988', 'DD/MM/YYYY'), 'Part Time', 'Lecturer', 18000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-6', TO_DATE('26/1/1998', 'DD/MM/YYYY'), 'Full Time', 'Module Leader', 55000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-7', TO_DATE('3/1/1998', 'DD/MM/YYYY'), 'Full Time', 'Lecturer', 39000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-10', TO_DATE('16/3/1998', 'DD/MM/YYYY'), 'Part Time', 'Tutor', 18000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-11', TO_DATE('23/4/2001', 'DD/MM/YYYY'), 'Full Time', 'Tutor', 39000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-13', TO_DATE('9/5/2001', 'DD/MM/YYYY'), 'Full Time', 'Module Leader', 55000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-15', TO_DATE('29/7/2010', 'DD/MM/YYYY'), 'Full Time', 'Lecturer', 39000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-17', TO_DATE('1/12/2021', 'DD/MM/YYYY'), 'Part Time', 'Lecturer', 18000)
    INTO Teacher(Teacher_ID, Hire_Date, Employment_Type, Designation, Salary) VALUES('P-18', TO_DATE('14/2/2015', 'DD/MM/YYYY'), 'Full Time', 'Module Leader', 55000)
SELECT 1 FROM dual;


INSERT ALL 
    INTO Student(Student_ID, Enroll_Date, Emergency_Contact,"Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-1',  TO_DATE('21/3/2021', 'DD/MM/YYYY'), '9877379210','T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-2',  TO_DATE('21/3/2021', 'DD/MM/YYYY'), 'T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-3',  TO_DATE('21/3/2021', 'DD/MM/YYYY'),'T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-8',  TO_DATE('21/3/2021', 'DD/MM/YYYY'), 'T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-9',  TO_DATE('21/3/2021', 'DD/MM/YYYY'), 'T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-12',  TO_DATE('21/3/2021', 'DD/MM/YYYY'), 'T','T','F')
    INTO Student(Student_ID, Enroll_Date, Emergency_Contact,"Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-14',  TO_DATE('21/3/2021', 'DD/MM/YYYY'), '9877333210','T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-16',  TO_DATE('21/3/2021', 'DD/MM/YYYY'), 'T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-19',  TO_DATE('21/3/2019', 'DD/MM/YYYY'), 'T','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-20',  TO_DATE('21/3/2019', 'DD/MM/YYYY'), 'F','T','F')
    INTO Student(Student_ID, Enroll_Date, "Is_Fee_Due?", "Is_Attendance_Eligible?", "Is_Graduate?") VALUES('P-21',  TO_DATE('21/3/2019', 'DD/MM/YYYY'), 'T','F','F')
SELECT 1 FROM dual;

COMMIT;



-- Insert Data into Secondary Dependent Tables

INSERT ALL 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-1', 'P-4') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-2', 'P-4') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-2', 'P-5') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-3', 'P-6') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-4', 'P-7') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-5', 'P-10') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-6', 'P-11') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-7', 'P-13') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-7', 'P-15') 
    INTO Module_Teacher(Module_Code, Teacher_ID) VALUES('M-6', 'P-17')
SELECT 1 FROM dual;


INSERT ALL 
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-1')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-2')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-3')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-8')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-9')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-12')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-14')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-1', 'P-16')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-1')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-2')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-3')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-8')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-9')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-12')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-14')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-2', 'P-16')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-3', 'P-1')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-4', 'P-1')
    INTO Module_Student(Module_Code, Student_ID) VALUES('M-5', 'P-1')
SELECT 1 FROM dual;


INSERT ALL 
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-1', 'D-1', '1st Semester Fee', 120000, TO_DATE('21/8/2021', 'DD/MM/YYYY'), 'Cash')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-2', 'D-1', '1st Semester Fee', 120000, TO_DATE('21/8/2020', 'DD/MM/YYYY'), 'Cash')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-3', 'D-1', '1st Semester Fee', 120000, TO_DATE('21/8/2019', 'DD/MM/YYYY'), 'Esewa')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-8', 'D-1', '1st Semester Fee', 120000, TO_DATE('21/8/2020', 'DD/MM/YYYY'), 'Cheque')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-9', 'D-1', '1st Semester Fee', 120000, TO_DATE('21/8/2019', 'DD/MM/YYYY'), 'Khalti')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-12', 'D-1', '1st Semester Fee', 120000, TO_DATE('21/8/2018', 'DD/MM/YYYY'), 'Cash')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-1', 'D-1', 'University Fee', 185000, TO_DATE('20/12/2017', 'DD/MM/YYYY'), 'Cash')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-2', 'D-1', 'University Fee', 185000, TO_DATE('20/12/2017', 'DD/MM/YYYY'), 'Cheque')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-3', 'D-1', 'University Fee', 185000, TO_DATE('20/12/2021', 'DD/MM/YYYY'), 'Cheque')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-8', 'D-1', 'University Fee', 185000, TO_DATE('20/12/2016', 'DD/MM/YYYY'), 'Cash')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-1', 'D-1', '2nd Semester Fee', 135000, TO_DATE('11/5/2022', 'DD/MM/YYYY'), 'Cash')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-2', 'D-1', '2nd Semester Fee', 135000, TO_DATE('11/5/2016', 'DD/MM/YYYY'), 'Cash')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-9', 'D-1', '2nd Semester Fee', 135000, TO_DATE('11/5/2022', 'DD/MM/YYYY'), 'Esewa')
    INTO Fee_Payment(Student_ID, Department_ID, Fee_Type, Fee_Amount, Payment_Date, Payment_Type) VALUES('P-12', 'D-1', '2nd Semester Fee', 135000, TO_DATE('11/5/2022', 'DD/MM/YYYY'), 'Cash')
SELECT 1 FROM dual;


INSERT ALL 
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-1',  120, 108)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-2',  120, 111)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-3',  120, 119)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-8',  120, 96)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-9',  120, 103)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-12',  120, 101)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-14',  120, 104)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-16',  120, 104)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-19',  120, 106)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-20',  125, 112)
    INTO Attendance(Student_ID, Total_Days, Present_Days) VALUES('P-21',  125, 68)
SELECT 1 FROM dual;

COMMIT;



-- Insert Data into Tertiary Dependent Tables

INSERT ALL 
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-1', 'M-1', 77,'C', TO_DATE('21/05/2021', 'DD/MM/YYYY'), TO_DATE('21/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-2', 'M-1', 74,'C', TO_DATE('21/05/2021', 'DD/MM/YYYY'), TO_DATE('20/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-3', 'M-1', 54,'E', TO_DATE('21/05/2021', 'DD/MM/YYYY'), TO_DATE('20/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-8', 'M-1', 56,'E', TO_DATE('21/05/2021', 'DD/MM/YYYY'), TO_DATE('19/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-9', 'M-1', 84,'B', TO_DATE('21/05/2021', 'DD/MM/YYYY'), TO_DATE('15/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-12', 'M-1', 91,'A', TO_DATE('21/05/2021', 'DD/MM/YYYY'), TO_DATE('21/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-14', 'M-1', 62,'D', TO_DATE('21/05/2021', 'DD/MM/YYYY'), TO_DATE('21/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-1', 'P-16', 'M-1', 89,'B', TO_DATE('1/07/2021', 'DD/MM/YYYY'), TO_DATE('20/05/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-3', 'P-1', 'M-1', 85,'B', TO_DATE('1/07/2021', 'DD/MM/YYYY'), TO_DATE('1/07/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-3', 'P-2', 'M-1', 75,'C', TO_DATE('1/07/2021', 'DD/MM/YYYY'), TO_DATE('1/07/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-3', 'P-3', 'M-1', 71,'C', TO_DATE('1/07/2021', 'DD/MM/YYYY'), TO_DATE('1/07/2021', 'DD/MM/YYYY'),'D-4')
    INTO Assignment_Result(Assignment_ID, Student_ID, Module_Code, Marks, Grade, Due_Date, Submitted_Date, Department_ID) VALUES('AS-3', 'P-8', 'M-1', 72,'C', TO_DATE('1/07/2021', 'DD/MM/YYYY'), TO_DATE('1/07/2021', 'DD/MM/YYYY'),'D-4')
SELECT 1 FROM dual;

COMMIT;