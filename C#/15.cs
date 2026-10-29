using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace StudentManagementSystem
{
    // ============================================================
    // STUDENT MANAGEMENT SYSTEM
    // Console application demonstrating core C# concepts.
    // ============================================================

    internal class Program
    {
        private static readonly StudentService StudentService = new StudentService();
        private static readonly ReportService ReportService = new ReportService();
        private static readonly string DataFile = "students.csv";

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            StudentService.LoadFromFile(DataFile);

            bool running = true;
            while (running)
            {
                DisplayMainMenu();
                int choice = InputHelper.ReadInt("Choose an option: ", 0, 12);

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayAllStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        UpdateStudent();
                        break;
                    case 5:
                        DeleteStudent();
                        break;
                    case 6:
                        ManageMarks();
                        break;
                    case 7:
                        SortStudents();
                        break;
                    case 8:
                        ShowStatistics();
                        break;
                    case 9:
                        ShowStudentReport();
                        break;
                    case 10:
                        ExportReport();
                        break;
                    case 11:
                        StudentService.SaveToFile(DataFile);
                        Console.WriteLine("Student data saved successfully.");
                        break;
                    case 12:
                        LoadData();
                        break;
                    case 0:
                        StudentService.SaveToFile(DataFile);
                        Console.WriteLine("Data saved. Goodbye!");
                        running = false;
                        break;
                }

                if (running)
                {
                    InputHelper.Pause();
                    Console.Clear();
                }
            }
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("          STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("==============================================");
            Console.WriteLine(" 1. Add student");
            Console.WriteLine(" 2. Display all students");
            Console.WriteLine(" 3. Search student");
            Console.WriteLine(" 4. Update student");
            Console.WriteLine(" 5. Delete student");
            Console.WriteLine(" 6. Manage student marks");
            Console.WriteLine(" 7. Sort students");
            Console.WriteLine(" 8. Show statistics");
            Console.WriteLine(" 9. View student report");
            Console.WriteLine("10. Export report to text file");
            Console.WriteLine("11. Save data");
            Console.WriteLine("12. Reload data from file");
            Console.WriteLine(" 0. Exit");
            Console.WriteLine("----------------------------------------------");
        }

        private static void AddStudent()
        {
            Console.WriteLine("ADD NEW STUDENT");
            Console.WriteLine("---------------");

            int id = InputHelper.ReadInt("Student ID: ", 1, int.MaxValue);
            if (StudentService.GetById(id) != null)
            {
                Console.WriteLine("A student with this ID already exists.");
                return;
            }

            string firstName = InputHelper.ReadRequiredText("First name: ");
            string lastName = InputHelper.ReadRequiredText("Last name: ");
            int age = InputHelper.ReadInt("Age: ", 1, 120);
            string gender = InputHelper.ReadRequiredText("Gender: ");
            string email = InputHelper.ReadRequiredText("Email: ");
            string phone = InputHelper.ReadRequiredText("Phone: ");
            string course = InputHelper.ReadRequiredText("Course: ");
            string address = InputHelper.ReadRequiredText("Address: ");

            Student student = new Student(
                id,
                firstName,
                lastName,
                age,
                gender,
                email,
                phone,
                course,
                address);

            StudentService.Add(student);
            Console.WriteLine("Student added successfully.");
        }

        private static void DisplayAllStudents()
        {
            Console.WriteLine("ALL STUDENTS");
            Console.WriteLine("------------");

            List<Student> students = StudentService.GetAll();
            if (students.Count == 0)
            {
                Console.WriteLine("No student records are available.");
                return;
            }

            StudentPrinter.PrintTable(students);
            Console.WriteLine("Total students: " + students.Count);
        }

        private static void SearchStudent()
        {
            Console.WriteLine("SEARCH STUDENT");
            Console.WriteLine("--------------");
            Console.WriteLine("1. Search by ID");
            Console.WriteLine("2. Search by name");
            int choice = InputHelper.ReadInt("Choose search type: ", 1, 2);

            List<Student> results;
            if (choice == 1)
            {
                int id = InputHelper.ReadInt("Enter student ID: ", 1, int.MaxValue);
                Student? student = StudentService.GetById(id);
                results = student == null ? new List<Student>() : new List<Student> { student };
            }
            else
            {
                string name = InputHelper.ReadRequiredText("Enter full or partial name: ");
                results = StudentService.SearchByName(name);
            }

            if (results.Count == 0)
            {
                Console.WriteLine("No matching student found.");
                return;
            }

            StudentPrinter.PrintTable(results);
        }

        private static void UpdateStudent()
        {
            Console.WriteLine("UPDATE STUDENT");
            Console.WriteLine("--------------");

            int id = InputHelper.ReadInt("Enter student ID: ", 1, int.MaxValue);
            Student? student = StudentService.GetById(id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Leave a field empty to keep its current value.");
            Console.WriteLine("Current name: " + student.FullName);

            string firstName = InputHelper.ReadOptionalText("First name [" + student.FirstName + "]: ");
            string lastName = InputHelper.ReadOptionalText("Last name [" + student.LastName + "]: ");
            string ageText = InputHelper.ReadOptionalText("Age [" + student.Age + "]: ");
            string gender = InputHelper.ReadOptionalText("Gender [" + student.Gender + "]: ");
            string email = InputHelper.ReadOptionalText("Email [" + student.Email + "]: ");
            string phone = InputHelper.ReadOptionalText("Phone [" + student.Phone + "]: ");
            string course = InputHelper.ReadOptionalText("Course [" + student.Course + "]: ");
            string address = InputHelper.ReadOptionalText("Address [" + student.Address + "]: ");

            if (!string.IsNullOrWhiteSpace(firstName)) student.FirstName = firstName;
            if (!string.IsNullOrWhiteSpace(lastName)) student.LastName = lastName;
            if (!string.IsNullOrWhiteSpace(gender)) student.Gender = gender;
            if (!string.IsNullOrWhiteSpace(email)) student.Email = email;
            if (!string.IsNullOrWhiteSpace(phone)) student.Phone = phone;
            if (!string.IsNullOrWhiteSpace(course)) student.Course = course;
            if (!string.IsNullOrWhiteSpace(address)) student.Address = address;

            if (!string.IsNullOrWhiteSpace(ageText))
            {
                if (int.TryParse(ageText, out int age) && age > 0 && age <= 120)
                {
                    student.Age = age;
                }
                else
                {
                    Console.WriteLine("Invalid age. The previous age was kept.");
                }
            }

            StudentService.Update(student);
            Console.WriteLine("Student updated successfully.");
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("DELETE STUDENT");
            Console.WriteLine("--------------");

            int id = InputHelper.ReadInt("Enter student ID: ", 1, int.MaxValue);
            Student? student = StudentService.GetById(id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Student: " + student.FullName);
            if (!InputHelper.Confirm("Are you sure you want to delete this student?"))
            {
                Console.WriteLine("Delete cancelled.");
                return;
            }

            StudentService.Delete(id);
            Console.WriteLine("Student deleted successfully.");
        }

        private static void ManageMarks()
        {
            Console.WriteLine("MANAGE MARKS");
            Console.WriteLine("------------");

            int id = InputHelper.ReadInt("Enter student ID: ", 1, int.MaxValue);
            Student? student = StudentService.GetById(id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Student: " + student.FullName);
            Console.WriteLine("1. Enter or update marks");
            Console.WriteLine("2. Display marks");
            int choice = InputHelper.ReadInt("Choose an option: ", 1, 2);

            if (choice == 1)
            {
                student.Marks.English = InputHelper.ReadDouble("English marks (0-100): ", 0, 100);
                student.Marks.Mathematics = InputHelper.ReadDouble("Mathematics marks (0-100): ", 0, 100);
                student.Marks.Science = InputHelper.ReadDouble("Science marks (0-100): ", 0, 100);
                student.Marks.Computer = InputHelper.ReadDouble("Computer marks (0-100): ", 0, 100);
                student.Marks.SocialStudies = InputHelper.ReadDouble("Social studies marks (0-100): ", 0, 100);
                StudentService.Update(student);
                Console.WriteLine("Marks saved successfully.");
            }
            else
            {
                ReportService.PrintMarks(student);
            }
        }

        private static void SortStudents()
        {
            Console.WriteLine("SORT STUDENTS");
            Console.WriteLine("-------------");
            Console.WriteLine("1. Sort by ID");
            Console.WriteLine("2. Sort by name");
            Console.WriteLine("3. Sort by marks (highest first)");
            Console.WriteLine("4. Sort by percentage (highest first)");

            int choice = InputHelper.ReadInt("Choose sort option: ", 1, 4);
            List<Student> students = StudentService.GetAll();

            switch (choice)
            {
                case 1:
                    students = students.OrderBy(s => s.Id).ToList();
                    break;
                case 2:
                    students = students.OrderBy(s => s.FullName).ToList();
                    break;
                case 3:
                    students = students.OrderByDescending(s => s.Marks.Total).ToList();
                    break;
                case 4:
                    students = students.OrderByDescending(s => s.Marks.Percentage).ToList();
                    break;
            }

            StudentPrinter.PrintTable(students);
        }

        private static void ShowStatistics()
        {
            Console.WriteLine("STUDENT STATISTICS");
            Console.WriteLine("------------------");

            List<Student> students = StudentService.GetAll();
            if (students.Count == 0)
            {
                Console.WriteLine("No data is available for statistics.");
                return;
            }

            int total = students.Count;
            double averageAge = students.Average(s => s.Age);
            double averagePercentage = students.Average(s => s.Marks.Percentage);
            int passed = students.Count(s => s.Marks.IsPassed);
            int failed = total - passed;
            Student? topStudent = students.OrderByDescending(s => s.Marks.Percentage).FirstOrDefault();

            Console.WriteLine("Total students       : " + total);
            Console.WriteLine("Average age          : " + averageAge.ToString("F1"));
            Console.WriteLine("Average percentage   : " + averagePercentage.ToString("F2") + "%");
            Console.WriteLine("Passed students      : " + passed);
            Console.WriteLine("Failed students      : " + failed);
            Console.WriteLine("Pass percentage      : " + (passed * 100.0 / total).ToString("F2") + "%");

            if (topStudent != null)
            {
                Console.WriteLine("Top student          : " + topStudent.FullName);
                Console.WriteLine("Top percentage       : " + topStudent.Marks.Percentage.ToString("F2") + "%");
            }

            Console.WriteLine();
            Console.WriteLine("Students by course:");
            foreach (IGrouping<string, Student> group in students.GroupBy(s => s.Course).OrderBy(g => g.Key))
            {
                Console.WriteLine(" - " + group.Key + ": " + group.Count());
            }
        }

        private static void ShowStudentReport()
        {
            Console.WriteLine("STUDENT REPORT");
            Console.WriteLine("--------------");

            int id = InputHelper.ReadInt("Enter student ID: ", 1, int.MaxValue);
            Student? student = StudentService.GetById(id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            ReportService.PrintFullReport(student);
        }

        private static void ExportReport()
        {
            Console.WriteLine("EXPORT REPORT");
            Console.WriteLine("-------------");

            string path = InputHelper.ReadOptionalText("Output file [student-report.txt]: ");
            if (string.IsNullOrWhiteSpace(path))
            {
                path = "student-report.txt";
            }

            try
            {
                ReportService.ExportAll(StudentService.GetAll(), path);
                Console.WriteLine("Report exported to: " + Path.GetFullPath(path));
            }
            catch (IOException ex)
            {
                Console.WriteLine("Could not write the report: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access denied: " + ex.Message);
            }
        }

        private static void LoadData()
        {
            Console.WriteLine("RELOAD DATA");
            Console.WriteLine("-----------");

            if (!InputHelper.Confirm("Reloading replaces the current in-memory list. Continue?"))
            {
                Console.WriteLine("Reload cancelled.");
                return;
            }

            StudentService.LoadFromFile(DataFile);
            Console.WriteLine("Data loaded. Current record count: " + StudentService.GetAll().Count);
        }
    }

    // ============================================================
    // STUDENT MODEL
    // ============================================================

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string FullName
        {
            get { return (FirstName + " " + LastName).Trim(); }
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public virtual string GetDescription()
        {
            return FullName + ", age " + Age;
        }
    }

    public class Student : Person
    {
        public int Id { get; private set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Course { get; set; }
        public string Address { get; set; }
        public StudentMarks Marks { get; set; }

        public Student(
            int id,
            string firstName,
            string lastName,
            int age,
            string gender,
            string email,
            string phone,
            string course,
            string address) : base(firstName, lastName, age)
        {
            Id = id;
            Gender = gender;
            Email = email;
            Phone = phone;
            Course = course;
            Address = address;
            Marks = new StudentMarks();
        }

        public override string GetDescription()
        {
            return "Student #" + Id + ": " + FullName + " (" + Course + ")";
        }

        public string ToCsv()
        {
            string[] fields =
            {
                Id.ToString(CultureInfo.InvariantCulture),
                Encode(FirstName),
                Encode(LastName),
                Age.ToString(CultureInfo.InvariantCulture),
                Encode(Gender),
                Encode(Email),
                Encode(Phone),
                Encode(Course),
                Encode(Address),
                Marks.English.ToString(CultureInfo.InvariantCulture),
                Marks.Mathematics.ToString(CultureInfo.InvariantCulture),
                Marks.Science.ToString(CultureInfo.InvariantCulture),
                Marks.Computer.ToString(CultureInfo.InvariantCulture),
                Marks.SocialStudies.ToString(CultureInfo.InvariantCulture)
            };

            return string.Join(",", fields);
        }

        public static Student? FromCsv(string line)
        {
            string[] fields = line.Split(',');
            if (fields.Length != 14)
            {
                return null;
            }

            try
            {
                Student student = new Student(
                    int.Parse(fields[0], CultureInfo.InvariantCulture),
                    Decode(fields[1]),
                    Decode(fields[2]),
                    int.Parse(fields[3], CultureInfo.InvariantCulture),
                    Decode(fields[4]),
                    Decode(fields[5]),
                    Decode(fields[6]),
                    Decode(fields[7]),
                    Decode(fields[8]));

                student.Marks.English = ParseMark(fields[9]);
                student.Marks.Mathematics = ParseMark(fields[10]);
                student.Marks.Science = ParseMark(fields[11]);
                student.Marks.Computer = ParseMark(fields[12]);
                student.Marks.SocialStudies = ParseMark(fields[13]);

                return student;
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
        }

        private static double ParseMark(string value)
        {
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        private static string Encode(string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value ?? string.Empty));
        }

        private static string Decode(string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }

    // ============================================================
    // MARKS MODEL
    // ============================================================

    public class StudentMarks
    {
        public double English { get; set; }
        public double Mathematics { get; set; }
        public double Science { get; set; }
        public double Computer { get; set; }
        public double SocialStudies { get; set; }

        public double Total
        {
            get
            {
                return English + Mathematics + Science + Computer + SocialStudies;
            }
        }

        public double MaximumMarks
        {
            get { return 500.0; }
        }

        public double Percentage
        {
            get { return Total / MaximumMarks * 100.0; }
        }

        public bool IsPassed
        {
            get
            {
                return English >= 35 &&
                       Mathematics >= 35 &&
                       Science >= 35 &&
                       Computer >= 35 &&
                       SocialStudies >= 35;
            }
        }

        public string Grade
        {
            get
            {
                if (!IsPassed) return "F";
                if (Percentage >= 90) return "A+";
                if (Percentage >= 80) return "A";
                if (Percentage >= 70) return "B";
                if (Percentage >= 60) return "C";
                if (Percentage >= 50) return "D";
                return "E";
            }
        }

        public StudentMarks Clone()
        {
            return new StudentMarks
            {
                English = English,
                Mathematics = Mathematics,
                Science = Science,
                Computer = Computer,
                SocialStudies = SocialStudies
            };
        }
    }

    // ============================================================
    // SERVICE LAYER
    // ============================================================

    public class StudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public void Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (GetById(student.Id) != null)
            {
                throw new InvalidOperationException("Student ID already exists.");
            }

            _students.Add(student);
        }

        public bool Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            int index = _students.FindIndex(s => s.Id == student.Id);
            if (index < 0)
            {
                return false;
            }

            _students[index] = student;
            return true;
        }

        public bool Delete(int id)
        {
            Student? student = GetById(id);
            if (student == null)
            {
                return false;
            }

            return _students.Remove(student);
        }

        public Student? GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetAll()
        {
            return new List<Student>(_students);
        }

        public List<Student> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<Student>();
            }

            return _students
                .Where(s => s.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s.FullName)
                .ToList();
        }

        public List<Student> SearchByCourse(string course)
        {
            if (string.IsNullOrWhiteSpace(course))
            {
                return new List<Student>();
            }

            return _students
                .Where(s => s.Course.Contains(course, StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s.FullName)
                .ToList();
        }

        public List<Student> GetPassedStudents()
        {
            return _students.Where(s => s.Marks.IsPassed).ToList();
        }

        public List<Student> GetFailedStudents()
        {
            return _students.Where(s => !s.Marks.IsPassed).ToList();
        }

        public List<Student> GetTopStudents(int count)
        {
            if (count < 1)
            {
                return new List<Student>();
            }

            return _students
                .OrderByDescending(s => s.Marks.Percentage)
                .ThenBy(s => s.FullName)
                .Take(count)
                .ToList();
        }

        public void SaveToFile(string path)
        {
            string[] lines = _students
                .OrderBy(s => s.Id)
                .Select(s => s.ToCsv())
                .ToArray();

            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        public void LoadFromFile(string path)
        {
            _students.Clear();

            if (!File.Exists(path))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(path, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                Student? student = Student.FromCsv(line);
                if (student != null && GetById(student.Id) == null)
                {
                    _students.Add(student);
                }
            }
        }
    }

    // ============================================================
    // REPORT SERVICE
    // ============================================================

    public class ReportService
    {
        public void PrintMarks(Student student)
        {
            Console.WriteLine();
            Console.WriteLine("MARKS");
            Console.WriteLine("-----");
            Console.WriteLine("English        : " + student.Marks.English.ToString("F1"));
            Console.WriteLine("Mathematics    : " + student.Marks.Mathematics.ToString("F1"));
            Console.WriteLine("Science        : " + student.Marks.Science.ToString("F1"));
            Console.WriteLine("Computer       : " + student.Marks.Computer.ToString("F1"));
            Console.WriteLine("Social studies : " + student.Marks.SocialStudies.ToString("F1"));
            Console.WriteLine("Total          : " + student.Marks.Total.ToString("F1") + "/500");
            Console.WriteLine("Percentage     : " + student.Marks.Percentage.ToString("F2") + "%");
            Console.WriteLine("Grade          : " + student.Marks.Grade);
            Console.WriteLine("Result         : " + (student.Marks.IsPassed ? "PASS" : "FAIL"));
        }

        public void PrintFullReport(Student student)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("               STUDENT REPORT");
            Console.WriteLine("==============================================");
            Console.WriteLine("Student ID : " + student.Id);
            Console.WriteLine("Name       : " + student.FullName);
            Console.WriteLine("Age        : " + student.Age);
            Console.WriteLine("Gender     : " + student.Gender);
            Console.WriteLine("Email      : " + student.Email);
            Console.WriteLine("Phone      : " + student.Phone);
            Console.WriteLine("Course     : " + student.Course);
            Console.WriteLine("Address    : " + student.Address);
            PrintMarks(student);
            Console.WriteLine("==============================================");
        }

        public void ExportAll(List<Student> students, string path)
        {
            List<string> lines = new List<string>
            {
                "STUDENT MANAGEMENT REPORT",
                "Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                new string('=', 72),
                string.Format(
                    CultureInfo.InvariantCulture,
                    "{0,-6} {1,-24} {2,-18} {3,10} {4,8}",
                    "ID", "Name", "Course", "Percent", "Result"),
                new string('-', 72)
            };

            foreach (Student student in students.OrderBy(s => s.Id))
            {
                lines.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "{0,-6} {1,-24} {2,-18} {3,9:F2}% {4,8}",
                    student.Id,
                    Truncate(student.FullName, 24),
                    Truncate(student.Course, 18),
                    student.Marks.Percentage,
                    student.Marks.IsPassed ? "PASS" : "FAIL"));
            }

            lines.Add(new string('=', 72));
            lines.Add("Total records: " + students.Count);
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        private static string Truncate(string value, int length)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= length)
            {
                return value;
            }

            return value.Substring(0, length - 3) + "...";
        }
    }

    // ============================================================
    // INPUT VALIDATION HELPERS
    // ============================================================

    public static class InputHelper
    {
        public static int ReadInt(string prompt, int minimum, int maximum)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value) &&
                    value >= minimum &&
                    value <= maximum)
                {
                    return value;
                }

                Console.WriteLine("Enter a whole number from " + minimum + " to " + maximum + ".");
            }
        }

        public static double ReadDouble(string prompt, double minimum, double maximum)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (double.TryParse(
                        input,
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out double value) &&
                    value >= minimum &&
                    value <= maximum)
                {
                    return value;
                }

                Console.WriteLine("Enter a number from " + minimum + " to " + maximum + ".");
            }
        }

        public static string ReadRequiredText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("This field cannot be empty.");
            }
        }

        public static string ReadOptionalText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static bool Confirm(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (y/n): ");
                string? answer = Console.ReadLine();

                if (string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(answer, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (string.Equals(answer, "n", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(answer, "no", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                Console.WriteLine("Please enter y or n.");
            }
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    // ============================================================
    // CONSOLE TABLE PRINTER
    // ============================================================

    public static class StudentPrinter
    {
        public static void PrintTable(List<Student> students)
        {
            const int idWidth = 6;
            const int nameWidth = 24;
            const int courseWidth = 18;
            const int percentWidth = 12;
            const int gradeWidth = 8;
            const int resultWidth = 8;

            string border =
                "+" + new string('-', idWidth + 2) +
                "+" + new string('-', nameWidth + 2) +
                "+" + new string('-', courseWidth + 2) +
                "+" + new string('-', percentWidth + 2) +
                "+" + new string('-', gradeWidth + 2) +
                "+" + new string('-', resultWidth + 2) + "+";

            Console.WriteLine(border);
            Console.WriteLine(
                "| " + Pad("ID", idWidth) +
                " | " + Pad("Name", nameWidth) +
                " | " + Pad("Course", courseWidth) +
                " | " + Pad("Percentage", percentWidth) +
                " | " + Pad("Grade", gradeWidth) +
                " | " + Pad("Result", resultWidth) + " |");
            Console.WriteLine(border);

            foreach (Student student in students)
            {
                Console.WriteLine(
                    "| " + Pad(student.Id.ToString(), idWidth) +
                    " | " + Pad(student.FullName, nameWidth) +
                    " | " + Pad(student.Course, courseWidth) +
                    " | " + Pad(student.Marks.Percentage.ToString("F2") + "%", percentWidth) +
                    " | " + Pad(student.Marks.Grade, gradeWidth) +
                    " | " + Pad(student.Marks.IsPassed ? "PASS" : "FAIL", resultWidth) + " |");
            }

            Console.WriteLine(border);
        }

        private static string Pad(string value, int width)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            if (value.Length > width)
            {
                value = value.Substring(0, width - 3) + "...";
            }

            return value.PadRight(width);
        }
    }
}
