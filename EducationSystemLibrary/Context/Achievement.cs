using EducationSystemLibrary.Models;

namespace EducationSystemLibrary.Context
{
    public class Achievement
    {
        public Student Student { get; set; }
        public int Mark { get; set; }
    }
}