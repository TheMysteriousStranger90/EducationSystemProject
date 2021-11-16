using System;
using System.Collections.Generic;
using EducationSystemLibrary.Context;
using EducationSystemLibrary.Enums;
using EducationSystemLibrary.Interfaces;

namespace EducationSystemLibrary.Models
{
    public class Teacher : ISetCourses
    {
        public Guid ID { get; }
        public string FullName { get; set; }
        public int AgeOfExpirience { get; set; }
        public string Rank { get; set; }

        public void CreateCourse(Course course)
        {
            Archive.Instance.CreateCourse(this, course);
        }

        public void StartRecordToCourse(Course course)
        {
            Archive.Instance.SetCourseState(this, course, StateOFCourse.Recruitment);
        }

        public void StartCourse(Course course)
        {
            Archive.Instance.SetCourseState(this, course, StateOFCourse.AtProcess);
            StudyAllStudentInCourse(course);
        }

        public void FinishCourse(Course course, List<int> studentsMarks)
        {
            var arhiveItem = Archive.Instance.FindData(this, course);

            if (arhiveItem.StudentsAndRates.Count != studentsMarks.Count)
                throw new ArgumentException(
                    $"Different counts between {nameof(arhiveItem.StudentsAndRates)} and {nameof(studentsMarks)}");

            RateTheStudents(arhiveItem, studentsMarks);

            arhiveItem.CourseManager.State = StateOFCourse.Finished;
        }

        private void StudyAllStudentInCourse(Course course)
        {
            var arhiveItem = Archive.Instance.FindData(this, course);
            foreach (var item in arhiveItem.StudentsAndRates)
            {
                item.Student.StudyAtCourse();
            }
        }

        private void RateTheStudents(ArchiveItem arhiveItem, List<int> studentsMarks)
        {
            for (int i = 0; i < arhiveItem.StudentsAndRates.Count; i++)
            {
                arhiveItem.StudentsAndRates[i].Mark = studentsMarks[i];
            }
        }
    }
}