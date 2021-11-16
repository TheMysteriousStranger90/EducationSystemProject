using System.Collections.Generic;
using EducationSystemLibrary.Models;

namespace EducationSystemLibrary.Context
{
    public class ArchiveItem
    {
        public Teacher Teacher { get; set; }
        public CourseProcessing CourseManager { get; set; }
        public List<Achievement> StudentsAndRates { get; set; }
    }
}