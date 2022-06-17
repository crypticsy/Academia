-- Creation of Person Table

CREATE TABLE person (
    person_id    VARCHAR2(10) NOT NULL,
    first_name   VARCHAR2(25) NOT NULL,
    last_name    VARCHAR2(25) NOT NULL,
    dob          DATE NOT NULL,
    gender       VARCHAR2(10) NOT NULL,
    email        VARCHAR2(50) NOT NULL,
    phone_number VARCHAR2(10) NOT NULL
);

ALTER TABLE person ADD CONSTRAINT person_pk PRIMARY KEY ( person_id );

ALTER TABLE person ADD CONSTRAINT person__un_email UNIQUE ( email );

ALTER TABLE person ADD CONSTRAINT person__un_phone UNIQUE ( phone_number );



-- Creation of Address Table

CREATE TABLE address (
    address_id VARCHAR2(10) NOT NULL,
    country    VARCHAR2(25) NOT NULL,
    street     VARCHAR2(50) NOT NULL,
    zip_code   VARCHAR2(5) NOT NULL
);

ALTER TABLE address ADD CONSTRAINT address_pk PRIMARY KEY ( address_id );



-- Creation of Address_Person Table

CREATE TABLE address_person (
    address_id VARCHAR2(10) NOT NULL,
    person_id  VARCHAR2(10) NOT NULL
);

ALTER TABLE address_person ADD CONSTRAINT address_person_pk PRIMARY KEY ( address_id,
                                                                          person_id );

ALTER TABLE address_person
    ADD CONSTRAINT table_5_address_fk FOREIGN KEY ( address_id )
        REFERENCES address ( address_id )
            ON DELETE CASCADE;

ALTER TABLE address_person
    ADD CONSTRAINT table_5_person_fk FOREIGN KEY ( person_id )
        REFERENCES person ( person_id )
            ON DELETE CASCADE;



-- Creation of Teacher Table
        
CREATE TABLE teacher (
    teacher_id      VARCHAR2(10) NOT NULL,
    hire_date       DATE NOT NULL,
    employment_type VARCHAR2(25),
    designation     VARCHAR2(25) NOT NULL,
    salary          INTEGER NOT NULL
);

ALTER TABLE teacher ADD CONSTRAINT staff_pk PRIMARY KEY ( teacher_id );

ALTER TABLE teacher
    ADD CONSTRAINT teacher_person_fk FOREIGN KEY ( teacher_id )
        REFERENCES person ( person_id )
            ON DELETE CASCADE;



-- Creation of Student Table
        
CREATE TABLE student (
    student_id                VARCHAR2(10) NOT NULL,
    enroll_date               DATE NOT NULL,
    emergency_contact         VARCHAR2(10),
    "Is_Fee_Due?"             CHAR(1) NOT NULL,
    "Is_Attendance_Eligible?" CHAR(1) NOT NULL,
    "Is_Graduate?"            CHAR(1) NOT NULL
);

ALTER TABLE student ADD CONSTRAINT student_pk PRIMARY KEY ( student_id );

ALTER TABLE student
    ADD CONSTRAINT student_person_fk FOREIGN KEY ( student_id )
        REFERENCES person ( person_id )
            ON DELETE CASCADE;



-- Creation of Attendance Table
        
CREATE TABLE attendance (
    attendance_id VARCHAR2(10) NOT NULL,
    student_id    VARCHAR2(10) NOT NULL,
    total_days    INTEGER NOT NULL,
    present_days  INTEGER NOT NULL
);

ALTER TABLE attendance ADD CONSTRAINT attendance_pk PRIMARY KEY ( attendance_id );

ALTER TABLE attendance
    ADD CONSTRAINT attendance_student_fk FOREIGN KEY ( student_id )
        REFERENCES student ( student_id )
            ON DELETE CASCADE;



-- Creation of Module Table

CREATE TABLE module (
    module_code  VARCHAR2(10) NOT NULL,
    module_name  VARCHAR2(50) NOT NULL,
    credit_hours INTEGER NOT NULL,
    total_days   INTEGER NOT NULL
);

ALTER TABLE module ADD CONSTRAINT module_pk PRIMARY KEY ( module_code );



-- Creation of Module_Teacher Table

CREATE TABLE module_teacher (
    module_code VARCHAR2(10) NOT NULL,
    teacher_id  VARCHAR2(10) NOT NULL
);

ALTER TABLE module_teacher ADD CONSTRAINT module_teacher_pk PRIMARY KEY ( module_code,
                                                                          teacher_id );

ALTER TABLE module_teacher
    ADD CONSTRAINT module_teacher_module_fk FOREIGN KEY ( module_code )
        REFERENCES module ( module_code )
            ON DELETE CASCADE;

ALTER TABLE module_teacher
    ADD CONSTRAINT module_teacher_teacher_fk FOREIGN KEY ( teacher_id )
        REFERENCES teacher ( teacher_id )
            ON DELETE CASCADE;



-- Creation of Module_Student Table
        
CREATE TABLE module_student (
    module_code VARCHAR2(10) NOT NULL,
    student_id  VARCHAR2(10) NOT NULL
);

ALTER TABLE module_student ADD CONSTRAINT course_student_pkv2 PRIMARY KEY ( module_code,
                                                                            student_id );

ALTER TABLE module_student
    ADD CONSTRAINT module_student_module_fk FOREIGN KEY ( module_code )
        REFERENCES module ( module_code )
            ON DELETE CASCADE;

ALTER TABLE module_student
    ADD CONSTRAINT module_student_student_fk FOREIGN KEY ( student_id )
        REFERENCES student ( student_id )
            ON DELETE CASCADE;



-- Creation of Department Table
    
CREATE TABLE department (
    department_id   VARCHAR2(10) NOT NULL,
    department_name VARCHAR2(50) NOT NULL,
    department_type VARCHAR2(25) NOT NULL,
    building        VARCHAR2(50) NOT NULL,
    room            VARCHAR2(25) NOT NULL
);

ALTER TABLE department ADD CONSTRAINT department_pk PRIMARY KEY ( department_id );



-- Creation of Fee_Payment Table

CREATE TABLE fee_payment (
    fee_id        VARCHAR2(10) NOT NULL,
    student_id    VARCHAR2(10) NOT NULL,
    department_id VARCHAR2(10) NOT NULL,
    fee_type      VARCHAR2(25) NOT NULL,
    fee_amount    INTEGER NOT NULL,
    payment_date  DATE NOT NULL,
    payment_type  VARCHAR2(15) NOT NULL
);

ALTER TABLE fee_payment ADD CONSTRAINT fee_payment_pk PRIMARY KEY ( fee_id );

ALTER TABLE fee_payment
    ADD CONSTRAINT fee_payment_department_fk FOREIGN KEY ( department_id )
        REFERENCES department ( department_id )
            ON DELETE CASCADE;

ALTER TABLE fee_payment
    ADD CONSTRAINT fee_payment_student_fk FOREIGN KEY ( student_id )
        REFERENCES student ( student_id )
            ON DELETE CASCADE;



-- Creation of Assignemnt Table

CREATE TABLE assignment (
    assignment_id        VARCHAR2(10) NOT NULL,
    assignment_name      VARCHAR2(100) NOT NULL,
    assignment_type      VARCHAR2(25) NOT NULL,
    assignment_weightage FLOAT NOT NULL
);

ALTER TABLE assignment ADD CONSTRAINT assignment_detail_pk PRIMARY KEY ( assignment_id );



-- Creation of Grade Table

CREATE TABLE grade (
    grade  VARCHAR2(10) NOT NULL,
    status VARCHAR2(10) NOT NULL
);

ALTER TABLE grade ADD CONSTRAINT grade_pk PRIMARY KEY ( grade );



-- Creation of Assignment Result Table

CREATE TABLE assignment_result (
    assignment_id  VARCHAR2(10) NOT NULL,
    student_id     VARCHAR2(10) NOT NULL,
    module_code    VARCHAR2(10) NOT NULL,
    marks          INTEGER NOT NULL,
    grade          VARCHAR2(10) NOT NULL,
    due_date       DATE NOT NULL,
    submitted_date DATE NOT NULL,
    department_id  VARCHAR2(10) NOT NULL
);

ALTER TABLE assignment_result
    ADD CONSTRAINT assignment_pk PRIMARY KEY ( module_code,
                                               student_id,
                                               assignment_id );

ALTER TABLE assignment_result
    ADD CONSTRAINT assign_assignment_fk FOREIGN KEY ( assignment_id )
        REFERENCES assignment ( assignment_id )
            ON DELETE CASCADE;

ALTER TABLE assignment_result
    ADD CONSTRAINT assign_department_fk FOREIGN KEY ( department_id )
        REFERENCES department ( department_id )
            ON DELETE CASCADE;

ALTER TABLE assignment_result
    ADD CONSTRAINT assignment_grade_fk FOREIGN KEY ( grade )
        REFERENCES grade ( grade )
            ON DELETE CASCADE;

ALTER TABLE assignment_result
    ADD CONSTRAINT assignment_module_student_fk FOREIGN KEY ( module_code,
                                                              student_id )
        REFERENCES module_student ( module_code,
                                    student_id )
            ON DELETE CASCADE;
        





-- Create the sequence & triggers for auto generating primary keys for the tables

CREATE SEQUENCE Person_Sequence START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Address_Sequence START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Module_Sequence START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Department_Sequence START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Fee_Payment_Sequence START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Assignment_Sequence START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE Attendance_Sequence START WITH 1 INCREMENT BY 1;
/
CREATE OR REPLACE TRIGGER Person_on_insert
    BEFORE INSERT ON Person
    FOR EACH ROW
BEGIN
    SELECT CONCAT('P-', CAST(Person_Sequence.nextval as varchar(10)))
    INTO :new.Person_ID
    FROM Dual;
END;
/
CREATE OR REPLACE TRIGGER Address_on_insert
    BEFORE INSERT ON Address
    FOR EACH ROW
BEGIN
    SELECT CONCAT('A-', CAST(Address_Sequence.nextval as varchar(10)))
    INTO :new.Address_ID
    FROM Dual;
END;
/
CREATE OR REPLACE TRIGGER Module_on_insert
    BEFORE INSERT ON Module
    FOR EACH ROW
BEGIN
    SELECT CONCAT('M-',CAST(Module_Sequence.nextval as varchar(10)))
    INTO :new.Module_Code
    FROM Dual;
END;
/
CREATE OR REPLACE TRIGGER Department_on_insert
    BEFORE INSERT ON Department
    FOR EACH ROW
BEGIN
    SELECT CONCAT('D-',CAST(Department_Sequence.nextval as varchar(10)))
    INTO :new.Department_ID
    FROM Dual;
END;
/
CREATE OR REPLACE TRIGGER Fee_Payment_on_insert
    BEFORE INSERT ON Fee_Payment
    FOR EACH ROW
BEGIN
    SELECT CONCAT('F-',CAST(Fee_Payment_Sequence.nextval as varchar(10)))
    INTO :new.Fee_ID
    FROM Dual;
END;
/
CREATE OR REPLACE TRIGGER Assignment_on_insert
    BEFORE INSERT ON Assignment
    FOR EACH ROW
BEGIN
    SELECT CONCAT('AS-',CAST(Assignment_Sequence.nextval as varchar(10)))
    INTO :new.Assignment_ID
    FROM Dual;
END;
/
CREATE OR REPLACE TRIGGER Attendance_on_insert
    BEFORE INSERT ON Attendance
    FOR EACH ROW
BEGIN
    SELECT CONCAT('AT-',CAST(Attendance_Sequence.nextval as varchar(10)))
    INTO :new.Attendance_ID
    FROM Dual;
END;
/
COMMIT;
/
