🎓 University Management System (Web API)
📌 Project Overview

This project is a University Management System (UMS) implemented as a RESTful Web API, with a primary focus on the Student Course Enrollment System.
The system manages core academic entities such as students, departments, and courses, while emphasizing real-world enrollment workflows including course enrollment, course dropping,
🏗 Architecture

The project strictly follows N-Tier Architecture:


📁 AppLayerAPI  
📁 BLL  
 ├─ Services  
 ├─ DTOs  
 └─ MapperConfig  
📁 DAL  
 ├─ EF  
 │ ├─ Models  
 │ └─ DbContext  
 ├─ Interfaces  
 └─ Repositories 



Layer Responsibilities

Presentation Layer (API Controllers)
Handles HTTP requests and responses (JSON only).

Business Logic Layer (BLL)
Contains validation rules, workflows, and decision-making logic.

Data Access Layer (DAL)
Handles database operations using Entity Framework Core.

🛠 Technologies Used

ASP.NET Core Web API

Entity Framework Core

SQL Server

AutoMapper

Swagger (OpenAPI)

Git & GitHub

🗄 Database Design
Main Entities

Department

Student

Course

Enrollment

Relationships

One Department → Many Students

One Department → Many Courses

One Student → Many Enrollments

One Course → Many Enrollments

🚀 Functional Features (Beyond CRUD)

The following non-CRUD features are implemented:

1️⃣ Advanced Student Search

Search students by:

Name

Department

Student ID

2️⃣ Enrollment Business Rules

CGPA-based enrollment validation

Course capacity check

Duplicate enrollment prevention

Re-enroll after dropping a course (updates existing record)

3️⃣ Course Drop Feature

A student can drop an enrolled course

Dropped courses free up capacity for others

4️⃣ Course Completion Feature

Students can mark courses as Completed

Completed courses cannot be dropped or re-enrolled

5️⃣ Automatic Student Status
CGPA < 2.0 → Probation

CGPA ≥ 2.0 → Active
📡 API Features

RESTful endpoints

Proper HTTP methods (GET, POST, PUT, DELETE)

JSON request & response format

Swagger UI for API testing

🔐 Validation & Error Handling

Business rules enforced in BLL

Invalid operations return meaningful error messages

Controllers return proper HTTP status codes (200, 400)

▶ How to Run the Project

Clone the repository

git clone https://github.com/nuhu78/EnrollmentSystem.git


Update the database connection string in appsettings.json

Run migrations:

dotnet ef database update --project DAL --startup-project AppLayerAPI


Run the API project

Open Swagger:

https://localhost:<port>/swagger

📘 Academic Purpose

This project is developed as part of a Web API & N-Tier Architecture academic assignment.
It demonstrates:

Proper layered architecture

Business logic separation

Entity Framework usage

RESTful API design

👤 Author

Name: MD TANGIMUL ANJAM NUHU
University: AIUB
Course: 

