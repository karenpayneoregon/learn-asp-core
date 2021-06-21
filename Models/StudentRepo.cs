using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspCore.Models
{
    public class StudentRepo : IStudentRepository
    {
        private List<Student> _students;

        public StudentRepo()
        {
            _students = new List<Student>() {
                new Student(){ Address="xyz",Division=Divi.A_10, FullName="Sagar",StudentId=1},
                new Student(){ Address="abc",Division=Divi.B_9, FullName="RAM",StudentId=2},
                new Student(){ Address="def",Division=Divi.A_8, FullName="LAKHAN",StudentId=3}
            };
        }

        public Student AddStudent(Student student)
        {
            var studid = _students.Max(e => e.StudentId)+1;
            student.StudentId = studid;
            _students.Add(student);
            return student;
        }

        public Student DeleteStudent(int studentID)
        {
            var student = _students.Where(e => e.StudentId == studentID).FirstOrDefault();
            if (student != null)
            {
                _students.Remove(student);
            }

            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return this._students.AsEnumerable();
        }

        public Student GetStudents(int StudentID)
        {
            return _students.Where(r=>r.StudentId==StudentID).FirstOrDefault();
        }

        public Student UpdateStudent(Student student)
        {
            var theStudent = _students.Where(e => e.StudentId == student.StudentId).FirstOrDefault();
            if (theStudent != null)
            {
                theStudent.Address = student.Address;
                theStudent.FullName = student.FullName;
                theStudent.Division = student.Division;
            }

            return theStudent;
        }
    }
}
