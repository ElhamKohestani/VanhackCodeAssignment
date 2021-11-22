using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.CourseServices.V1.DTOs;

namespace VanhackTest.CourseServices.V1
{
    public interface ICourseRecordingsService : IApplicationService
    {
        Task<CourseRecordingDTO> GetRecording(int id);
        Task<List<CourseRecordingDTO>> GetCourseRecordings(int? courseId);
        Task EditRecording(CourseRecordingDTO recording);
        Task AddRecording(CourseRecordingCreateDTO recording);
        Task RemoveRecording(int Id);
    }
}
