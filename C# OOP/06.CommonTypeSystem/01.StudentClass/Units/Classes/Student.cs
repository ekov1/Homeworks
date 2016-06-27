namespace _01.StudentClass.Units.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enums;
    using Utils;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int ssnNumber;
        private string permAdress;
        private string phoneNumber;
        private string email;
        private string course;
        private Specialties specialty;
        private Universities university;
        private Faculties faculty;

        public Student(string firstName, string middleName, string lastName, int ssnNumber, string permAdress, string phoneNumber
            , string email, string course, Specialties specialty, Universities university, Faculties faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssnNumber;
            this.PermanentAdress = permAdress;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Verification.NullVerification(value);
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                Verification.NullVerification(value);
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Verification.NullVerification(value);
                this.lastName = value;
            }
        }

        public int SSN
        {
            get
            {
                return this.ssnNumber;
            }
            private set
            {
                Verification.ZeroOrNegative(value);
                this.ssnNumber = value;
            }
        }

        public string PermanentAdress
        {
            get
            {
                return this.permAdress;
            }
            private set
            {
                Verification.NullVerification(value);
                this.permAdress = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            internal set
            {
                Verification.NullVerification(value);
                this.phoneNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            internal set
            {
                Verification.NullVerification(value);
                this.email = value;
            }
        }

        public string Course
        {
            get
            {
                return this.course;
            }
            internal set
            {
                Verification.NullVerification(value);
                this.course = value;
            }
        }

        public Specialties Specialty
        {
            get
            {
                return this.specialty;
            }
            internal set
            {
                this.specialty = value;
            }
        }

        public Universities University
        {
            get
            {
                return this.university;
            }
            internal set
            {
                this.university = value;
            }
        }

        public Faculties Faculty
        {
            get
            {
                return this.faculty;
            }
            internal set
            {
                this.faculty = value;
            }
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (this.SSN == student.SSN)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Student data");
            builder.AppendLine(new string('=', 50));
            builder.AppendLine($"Full name : {this.FirstName} {this.MiddleName} {this.LastName}");
            builder.AppendLine($"SSN Number : {this.SSN}");
            builder.AppendLine($"Adress: {this.PermanentAdress}");
            builder.AppendLine($"Phone number : {this.PhoneNumber}");
            builder.AppendLine($"Email : {this.Email}");
            builder.AppendLine($"Course : {this.Course}");
            builder.AppendLine($"Specialty : {this.Specialty}");
            builder.AppendLine($"University : {this.University}");
            builder.AppendLine($"Faculty : {this.Faculty}");


            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return (this.SSN.GetHashCode() + this.PhoneNumber.GetHashCode());
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }

        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAdress, this.PhoneNumber,
                this.Email, this.Course, this.Specialty, this.University, this.Faculty);
        }

        public int CompareTo(Student otherStudent)
        {
            var stCompare = new List<Student> { this, otherStudent };
            Student sorted;
            if (this.FirstName != otherStudent.FirstName && this.MiddleName != otherStudent.MiddleName && this.LastName != otherStudent.LastName)
            {
                sorted = stCompare
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.MiddleName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                    .FirstOrDefault();

                if (sorted == this)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (this.SSN != otherStudent.SSN)
            {
                sorted = stCompare
                    .OrderBy(x => x.SSN)
                    .ToList()
                    .FirstOrDefault();

                if (this.SSN == sorted.SSN)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
