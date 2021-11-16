using System.Collections.Generic;
using EducationSystemLibrary.Models;

namespace EducationSystemLibrary.Interfaces
{
    public interface ISetCourses
    {
        public void CreateCourse(Course course);
        public void StartRecordToCourse(Course course);
        public void StartCourse(Course course);
        public void FinishCourse(Course course, List<int> studentsMarks);
    }
}