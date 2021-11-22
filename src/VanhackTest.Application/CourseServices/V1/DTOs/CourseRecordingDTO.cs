using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanhackTest.CourseServices.V1.DTOs
{
    public class CourseRecordingDTO
    {
        public int RecordingId { get; set; }
        public string RecordingTitle { get; set; }
        public string RecordingDescription { get; set; }
        public short RecordingOrder { get; set; }
        public string RecordingLink { get; set; }
        public int? CourseId { get; set; }

        public string CourseText { get; set; }
    }
}
