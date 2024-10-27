using ExamProctoringManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public UserDAO UserDAO { get; }
        public ExamDAO ExamDAO { get; }
        public FormSlotDAO FormSlotDAO { get; }
        public FormSwapDAO FormSwapDAO { get; }
        public GroupDAO GroupDAO { get; }
        public GroupRoomDAO GroupRoomDAO { get; }
        public ProctoringScheduleDAO ProctoringScheduleDAO { get; }
        public RegistrationFormDAO RegistrationFormDAO { get; }
        public ReportDAO ReportDAO { get; }
        public RoleDAO RoleDAO { get; }
        public RoomDAO RoomDAO { get; }
        public SemesterDAO SemesterDAO { get; }
        public SlotDAO SlotDAO { get; }
        public SlotReferenceDAO SlotReferenceDAO { get; }
        public SlotRoomSubjectDAO SlotRoomSubjectDAO { get; }
        public SubjectDAO SubjectDAO { get; }
        public RefreshTokenDAO RefreshTokenDAO { get; }
        public Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task<int> SaveChangesWithTransactionAsync();

    }
}
