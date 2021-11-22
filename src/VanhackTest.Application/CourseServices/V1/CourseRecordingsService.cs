using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Authorization;
using VanhackTest.Core.Entities;
using VanhackTest.CourseServices.V1.DTOs;

namespace VanhackTest.CourseServices.V1
{
    [AbpAuthorize(PermissionNames.Pages_Courses)]
    public class CourseRecordingsService : VanhackTestAppServiceBase, ICourseRecordingsService
    {
        private IRepository<CourseRecording, int> _repository;
        private IMapper _mapper;

        public CourseRecordingsService(IRepository<CourseRecording, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddRecording(CourseRecordingCreateDTO recording)
        {

            await _repository.InsertAsync(_mapper.Map(source: recording, new CourseRecording()
            {
                CreatedBy = (await GetCurrentUserAsync()).Id,
                CreatedOn = DateTime.Now
            }));
        }

        /// <summary>
        /// Get the entity occurrence by its id and update is based on the data passed 
        /// in the recording parameter
        /// </summary>
        /// <param name="recording"></param>
        /// <returns></returns>
        public async Task EditRecording(CourseRecordingDTO recording)
        {
            try
            {
                CourseRecording entity = await _repository.GetAsync(recording.RecordingId);
                await _repository.UpdateAsync(_mapper.Map(source: recording, destination: entity));
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// Get all recordings for a related course.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<List<CourseRecordingDTO>> GetCourseRecordings(int? courseId)
        {
            
            try
            {
                List<CourseRecordingDTO> list = new List<CourseRecordingDTO>();
                list = (from x in (await _repository.GetAllListAsync(r => r.CourseId == courseId)).AsQueryable()
                        select _mapper.Map(x, new CourseRecordingDTO())).ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
          

        }


        /// <summary>
        /// Get a specific recording by passing its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CourseRecordingDTO> GetRecording(int id)
        {

            try
            {
                return  _mapper.Map(await _repository.GetAsync(id), new CourseRecordingDTO());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Remove a recording by passing its id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task RemoveRecording(int Id)
        {
            await _repository.DeleteAsync(Id);
        }
    }
}
