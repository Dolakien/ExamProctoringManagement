using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Repository.Repositories;
using ExamProctoringManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Usecases
{
    public class ProctoringScheduleService : IProctoringScheduleService
    {
        private readonly IProctoringScheduleRepository _ProctoringScheduleRepository;
        private readonly ISlotReferenceRepository _SlotReferenceRepository;
        private readonly ISlotRepository _SlotRepository;
        private readonly IExamRepository _ExamRepository;
        private readonly ISemesterRepository _SemesterRepository;
        private readonly ISlotRoomSubjectRepository _SlotRoomSubjectRepository;
        private readonly ISubjectRepository _SubjectRepository;
        private readonly IGroupRepository _GroupRepository;
        private readonly IGroupRoomRepository _groupRoomRepository;
        private readonly IRoomRepository _RoomRepository;

        public ProctoringScheduleService(IProctoringScheduleRepository ProctoringScheduleRepository, ISlotReferenceRepository slotReferenceRepository, ISlotRepository slotRepository, IExamRepository examRepository, ISemesterRepository semesterRepository, ISlotRoomSubjectRepository slotRoomSubjectRepository, ISubjectRepository subjectRepository, IGroupRepository groupRepository, IGroupRoomRepository groupRoomRepository, IRoomRepository roomRepository)
        {
            _ProctoringScheduleRepository = ProctoringScheduleRepository;
            _SlotReferenceRepository = slotReferenceRepository;
            _SlotRepository = slotRepository;
            _ExamRepository = examRepository;
            _SemesterRepository = semesterRepository;
            _SlotRoomSubjectRepository = slotRoomSubjectRepository;
            _SubjectRepository = subjectRepository;
            _GroupRepository = groupRepository;
            _groupRoomRepository = groupRoomRepository;
            _RoomRepository = roomRepository;
        }

        public async Task<ProctoringSchedule> GetProctoringScheduleByIdAsync(string id)
        {
            return await _ProctoringScheduleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetAllProctoringSchedulesAsync()
        {
            return await _ProctoringScheduleRepository.GetAllAsync();
        }

        public async Task<string> CreateProctoringScheduleAsync(ProctoringScheduleDTO ProctoringSchedule)
            => await _ProctoringScheduleRepository.CreateAsync(ProctoringSchedule);


        public async Task<string> UpdateProctoringScheduleAsync(ProctoringScheduleDTO ProctoringSchedule)
            => await _ProctoringScheduleRepository.UpdateAsync(ProctoringSchedule);

        public async Task DeleteProctoringScheduleAsync(string id)
        {
            await _ProctoringScheduleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetProctoringSchedulesByUserIdAsync(string userId)
        {
            return await _ProctoringScheduleRepository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ProctoringSchedule>> GetProctoringSchedulesByUserIdAndIsFinishedAsync(string userId, bool f)
        {
            return await _ProctoringScheduleRepository.GetByUserIdAndIsFinishedAsync(userId, f);
        }

        public async Task<FullProctoringScheduleDto> GetFullProctoringScheduleByIdAsync(string id)
        {
            var dto = new FullProctoringScheduleDto();

            var p = await _ProctoringScheduleRepository.GetByIdAsync(id);
            
            dto.ScheduleId = p.ScheduleId; 
            dto.IsFinished = p.IsFinished;
            dto.Status = p.Status;
            dto.ProctorType = p.ProctorType;
            dto.UserId = p.UserId;

            var slotRef = await _SlotReferenceRepository.GetByIdAsync(p.SlotReferenceId);
            var slot = await _SlotRepository.GetByIdAsync(slotRef.SlotId);

            dto.SlotId = slot.SlotId;
            dto.Date = slot.Date;
            dto.Start = slot.Start;
            dto.End = slot.End;

            var exam = await _ExamRepository.GetByIdAsync(slot.ExamId);
            var semester = await _SemesterRepository.GetByIdAsync(exam.SemesterId);

            dto.ExamName = exam.ExamName;
            dto.SemesterName = semester.SemesterName;

            if (slotRef.RoomId != null)
            {
                var room = await _RoomRepository.GetByIdAsync(slotRef.RoomId);
                dto.RoomName = room.RoomName;

                List<SlotRoomSubject> slotRoomSubjects = new List<SlotRoomSubject>();
                var srs = await _SlotRoomSubjectRepository.GetAllAsync();

                foreach (var slotRoomSubject in srs)
                {
                    if (slotRoomSubject.SlotReferenceId == slotRef.SlotReferenceId)
                        slotRoomSubjects.Add(slotRoomSubject);
                }

                List<SubjectDto> subjects = new List<SubjectDto>();   
                foreach (var slotRS in slotRoomSubjects)
                {
                    var subjectDto = new SubjectDto();
                    var subject = await _SubjectRepository.GetByIdAsync(slotRS.SubjectId);
                    subjectDto.SubjectId = subject.SubjectId;
                    subjectDto.SubjectName = subject.SubjectName;
                    subjects.Add(subjectDto);
                }

                dto.Subjects = subjects;
            }

            else if (slotRef.GroupId != null)
            {
                var group = await _GroupRepository.GetByIdAsync(id);
                var list = await _groupRoomRepository.GetGroupRoomsByGroupAsync(group);
                List<Room> rooms = new List<Room>();
                foreach (var groupRoom in list)
                {
                    Room room = await _RoomRepository.GetByIdAsync(groupRoom.RoomId);
                    rooms.Add(room);
                }

                dto.GroupId = slotRef.GroupId;
                dto.Rooms = rooms;
            }

            return dto;
        }

        public async Task CountProctoringAsync(string id)
            => await _ProctoringScheduleRepository.CountProctoringAsync(id);
    }
}
