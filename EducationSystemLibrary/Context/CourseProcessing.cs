using EducationSystemLibrary.Enums;
using EducationSystemLibrary.Models;

namespace EducationSystemLibrary.Context
{
    public class CourseProcessing
    {
        public Course Course { get; set; }
        public StateOFCourse State { get; set; }
    }
}