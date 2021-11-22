using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanhackTest.CourseServices.V1.DTOs
{
    public class CourseRecordingCreateDTO
    {
        public string RecordingTitle { get; set; }
        public string RecordingDescription { get; set; }
        public short RecordingOrder { get; set; }
        public string RecordingLink { get; set; }
        
        [Required]
        public int? CourseId { get; set; }
    }
}
