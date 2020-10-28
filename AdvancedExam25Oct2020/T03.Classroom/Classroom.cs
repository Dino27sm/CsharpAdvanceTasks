using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return this.students.Count; } }

        public string RegisterStudent(Student student)
        {
            string textOut = $"No seats in the classroom";
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                textOut = $"Added student {student.FirstName} {student.LastName}";
            }
            return textOut;
        }

        public string DismissStudent(string firstName, string lastName)
        {
            string textOut = $"Student not found";
            //Student oneToRemove = this.students.Find(x => x.FirstName == firstName && x.LastName == lastName);
            if(this.students.Remove(this.students.Find(x => x.FirstName == firstName && x.LastName == lastName)))
            {
                textOut = $"Dismissed student {firstName} {lastName}";
            }
            return textOut;
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            string textOut = "No students enrolled for the subject";
            if (this.students.Find(x => x.Subject == subject) != null)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var item in this.students.Where(x => x.Subject == subject))
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
                textOut = sb.ToString().Trim();  // Check this Trim
            }
            return textOut;
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.Find(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
