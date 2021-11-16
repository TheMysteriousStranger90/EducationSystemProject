using System;
using System.Collections.Generic;
using EducationSystemLibrary.Enums;
using EducationSystemLibrary.Models;

namespace EducationSystemLibrary.Context
{
    public sealed class Archive
    {
        public List<ArchiveItem> ArchiveList { get; private set; } = new List<ArchiveItem>();
        
        private static readonly Lazy<Archive> lazy = new Lazy<Archive>(() => new Archive());
        
        private Archive() { }
        
        public static Archive Instance { get { return lazy.Value; } }
        
        public void AddData(ArchiveItem item) =>
            ArchiveList.Add(item);
        
        public void RemoveDataAt(int index) =>
            ArchiveList.RemoveAt(index);
        
        public ArchiveItem FindData(Teacher teacher, Course course) =>
            ArchiveList.Find(i => i.CourseManager.Course == course && i.Teacher == teacher);
        
        public void CreateCourse(Teacher teacher, Course course)
        {
            ArchiveList.Add(new ArchiveItem()
            {
                CourseManager = new CourseProcessing() { Course = course, State = StateOFCourse.Awaiting },
                Teacher = teacher,
                StudentsAndRates = null
            });
        }
        
        public void SetCourseState(Teacher teacher, Course course, StateOFCourse state) =>
            FindData(teacher, course).CourseManager.State = state;
    }
}