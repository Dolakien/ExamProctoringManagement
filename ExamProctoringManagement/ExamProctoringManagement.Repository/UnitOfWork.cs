using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamProctoringManagementDBContext _context;
        private UserDAO _userDAO;
        private RefreshTokenDAO _refreshTokenDAO;
        private ExamDAO _examDAO;
        private FormSlotDAO _formSlotDAO;
        private FormSwapDAO _formSwapDAO;
        private GroupDAO _groupDAO;
        private GroupRoomDAO _groupRoomDAO;
        private ProctoringScheduleDAO _proctoringScheduleDAO;
        private RegistrationFormDAO _registrationFormDAO;
        private ReportDAO _reportDAO;
        private RoleDAO _roleDAO;
        private RoomDAO _roomDAO;
        private SemesterDAO _semesterDAO;
        private SlotDAO _slotDAO;
        private SlotReferenceDAO _slotReferenceDAO;
        private SlotRoomSubjectDAO _slotRoomSubjectDAO;
        private SubjectDAO _subjectDAO;

        public UnitOfWork(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }


        public RefreshTokenDAO RefreshTokenDAO => _refreshTokenDAO = new RefreshTokenDAO(_context);
        public UserDAO UserDAO => _userDAO = new UserDAO(_context);

        public ExamDAO ExamDAO => _examDAO = new ExamDAO(_context);

        public FormSlotDAO FormSlotDAO => _formSlotDAO = new FormSlotDAO(_context);

        public FormSwapDAO FormSwapDAO => _formSwapDAO = new FormSwapDAO(_context);

        public GroupDAO GroupDAO => _groupDAO = new GroupDAO(_context);

        public GroupRoomDAO GroupRoomDAO => _groupRoomDAO = new GroupRoomDAO(_context);

        public ProctoringScheduleDAO ProctoringScheduleDAO => _proctoringScheduleDAO = new ProctoringScheduleDAO(_context);

        public RegistrationFormDAO RegistrationFormDAO => _registrationFormDAO = new RegistrationFormDAO(_context);

        public ReportDAO ReportDAO => _reportDAO = new ReportDAO(_context);

        public RoleDAO RoleDAO => _roleDAO = new RoleDAO(_context);

        public RoomDAO RoomDAO => _roomDAO = new RoomDAO(_context);

        public SemesterDAO SemesterDAO => _semesterDAO = new SemesterDAO(_context);

        public SlotDAO SlotDAO => _slotDAO = new SlotDAO(_context);

        public SlotReferenceDAO SlotReferenceDAO => _slotReferenceDAO = new SlotReferenceDAO(_context);

        public SlotRoomSubjectDAO SlotRoomSubjectDAO => _slotRoomSubjectDAO = new SlotRoomSubjectDAO(_context);

        public SubjectDAO SubjectDAO => _subjectDAO = new SubjectDAO(_context);

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }
    }
}
