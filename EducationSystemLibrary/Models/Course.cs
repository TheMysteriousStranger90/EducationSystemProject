using System;

namespace EducationSystemLibrary.Models
{
    public class Course
    {
        public string NameOfCourse { get; private set; }
        public string Desciption { get; private set; }
        public DateTime Time { get; private set; }
        public Teacher Teacher { get; private set; }
    }
}