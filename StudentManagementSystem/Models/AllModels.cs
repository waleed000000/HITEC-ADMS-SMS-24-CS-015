using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required] public string DeptName { get; set; } = "";
        [Required] public string DeptCode { get; set; } = "";
        public int EstablishedYear { get; set; } = 2000;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Student>? Students { get; set; }
        public ICollection<Faculty>? Faculty { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }

    public class AcademicProgram
    {
        [Key]
        public int ProgramID { get; set; }
        [Required] public string ProgramName { get; set; } = "";
        public int DepartmentID { get; set; }
        public int Duration { get; set; } = 4;
        public Department? Department { get; set; }
    }

    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required] public string FirstName { get; set; } = "";
        [Required] public string LastName { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; } = "";
        [Required] public string CNIC { get; set; } = "";
        public string? Phone { get; set; }
        public int DepartmentID { get; set; }
        public int ProgramID { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public Department? Department { get; set; }
        public AcademicProgram? AcademicProgram { get; set; }
    }

    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        [Required] public string FirstName { get; set; } = "";
        [Required] public string LastName { get; set; } = "";
        [Required] public string Email { get; set; } = "";
        public string? Phone { get; set; }
        public int DepartmentID { get; set; }
        public string? Designation { get; set; }
        public bool IsActive { get; set; } = true;
        public Department? Department { get; set; }
    }

    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required] public string CourseCode { get; set; } = "";
        [Required] public string CourseName { get; set; } = "";
        public int CreditHours { get; set; }
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
    }

    public class Section
    {
        [Key]
        public int SectionID { get; set; }
        [Required] public string SectionName { get; set; } = "";
        public int CourseID { get; set; }
        public int FacultyID { get; set; }
        public string? Semester { get; set; }
        public int MaxSeats { get; set; } = 30;
        public int AvailableSeats { get; set; } = 30;
        public Course? Course { get; set; }
        public Faculty? Faculty { get; set; }
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int SectionID { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Active";
        public Student? Student { get; set; }
        public Section? Section { get; set; }
    }

    public class Grade
    {
        [Key]
        public int GradeID { get; set; }
        public int EnrollmentID { get; set; }
        public decimal Marks { get; set; }
        public string? LetterGrade { get; set; }
        public decimal GradePoints { get; set; }
        public Enrollment? Enrollment { get; set; }
    }

    public class AttendanceRecord
    {
        [Key]
        public int AttendanceID { get; set; }
        public int StudentID { get; set; }
        public int SectionID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; } = "Present";
        public Student? Student { get; set; }
        public Section? Section { get; set; }
    }

    public class FeePayment
    {
        [Key]
        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string? PaymentMethod { get; set; }
        public string Status { get; set; } = "Paid";
        public Student? Student { get; set; }
    }

    public class LibraryItem
    {
        [Key]
        public int ItemID { get; set; }
        [Required] public string Title { get; set; } = "";
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int TotalCopies { get; set; } = 1;
        public int AvailableCopies { get; set; } = 1;
    }

    public class LibraryIssue
    {
        [Key]
        public int IssueID { get; set; }
        public int StudentID { get; set; }
        public int ItemID { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal Fine { get; set; } = 0;
        public Student? Student { get; set; }
        public LibraryItem? LibraryItem { get; set; }
    }

    public class AuditLog
    {
        [Key]
        public int LogID { get; set; }
        public string? TableName { get; set; }
        public string? Action { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.Now;
    }
}