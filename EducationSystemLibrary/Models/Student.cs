using System;
using EducationSystemLibrary.Context;
using EducationSystemLibrary.Enums;

namespace EducationSystemLibrary.Models
{
    public class Student
    {
        public Guid ID { get; }
        public string FullName { get; set; }
        public int Age { get; set; }

        public bool RecordToCourse(Teacher teacher, Course course)
        {
            var archiveItem = Archive.Instance.FindData(teacher, course);

            if (archiveItem.CourseManager.State != StateOFCourse.Recruitment)
                return false;

            archiveItem.StudentsAndRates.Add(new Achievement() {Student = this});
            return true;
        }

        public string StudyAtCourse() =>
            $"I am studying";
    }
}