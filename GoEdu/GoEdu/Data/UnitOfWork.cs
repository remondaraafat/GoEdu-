using GoEdu.Models;
using GoEdu.Repositories;

namespace GoEdu.Data
{
    public class UnitOfWork
    {
        private readonly GoEduContext context;
        private IAnswerRepository _AnswerRepo;
        private IAttendRepository _AttendRepo;
        private ICommentRepository _CommentRepo;
        private ICourseRepository _CourseRepo;
        private IExamPerLectureRepository _ExamPerLectureRepo;
        private IExamQuestionRepository _ExamQuestionRepo;
        private IExamRepository _ExamRepo;
        private IInstructorRepository _InstructorRepo;
        private ILectureRepository _LectureRepo;
        private IOptionRepository _OptionRepo;
        private IQuestionRepository _QuestionRepo;
        private IRegisterRepository _RegisterRepo;
        private IStudentPerformanceExamRepository _StudentPerformanceExamRepo;
        private IStudentRepository _StudentRepo;

        public UnitOfWork(GoEduContext ctx)
        {
            context = ctx;
        }

        public IAnswerRepository AnswerRepo
        {
            get
            {
                if (_AnswerRepo == null)
                    _AnswerRepo = new AnswerRepository(context);
                return _AnswerRepo;
            }
        }
        public void save()
        {
            context.SaveChanges();
        }

        public IAttendRepository AttendRepo
        {
            get
            {
                if (_AttendRepo == null)
                    _AttendRepo = new AttendRepository(context);
                return _AttendRepo;
            }
        }

        public ICommentRepository CommentRepo
        {
            get
            {
                if (_CommentRepo == null)
                    _CommentRepo = new CommentRepository(context);
                return _CommentRepo;
            }
        }

        public ICourseRepository CourseRepo
        {
            get
            {
                if (_CourseRepo == null)
                    _CourseRepo = new CourseRepository(context);
                return _CourseRepo;
            }
        }

        public IExamPerLectureRepository ExamPerLectureRepo
        {
            get
            {
                if (_ExamPerLectureRepo == null)
                    _ExamPerLectureRepo = new ExamPerLectureRepository(context);
                return _ExamPerLectureRepo;
            }
        }

        public IExamQuestionRepository ExamQuestionRepo
        {
            get
            {
                if (_ExamQuestionRepo == null)
                    _ExamQuestionRepo = new ExamQuestionRepository(context);
                return _ExamQuestionRepo;
            }
        }

        public IExamRepository ExamRepo
        {
            get
            {
                if (_ExamRepo == null)
                    _ExamRepo = new ExamRepository(context);
                return _ExamRepo;
            }
        }

        public IInstructorRepository InstructorRepo
        {
            get
            {
                if (_InstructorRepo == null)
                    _InstructorRepo = new InstructorRepository(context);
                return _InstructorRepo;
            }
        }

        public ILectureRepository LectureRepo
        {
            get
            {
                if (_LectureRepo == null)
                    _LectureRepo = new LectureRepository(context);
                return _LectureRepo;
            }
        }

        public IOptionRepository OptionRepo
        {
            get
            {
                if (_OptionRepo == null)
                    _OptionRepo = new OptionRepository(context);
                return _OptionRepo;
            }
        }

        public IQuestionRepository QuestionRepo
        {
            get
            {
                if (_QuestionRepo == null)
                    _QuestionRepo = new QuestionRepository(context);
                return _QuestionRepo;
            }
        }

        public IRegisterRepository RegisterRepo
        {
            get
            {
                if (_RegisterRepo == null)
                    _RegisterRepo = new RegisterRepository(context);
                return _RegisterRepo;
            }
        }

        public IStudentPerformanceExamRepository StudentPerformanceExamRepo
        {
            get
            {
                if (_StudentPerformanceExamRepo == null)
                    _StudentPerformanceExamRepo = new StudentPerformanceExamRepository(context);
                return _StudentPerformanceExamRepo;
            }
        }

        public IStudentRepository StudentRepo
        {
            get
            {
                if (_StudentRepo == null)
                    _StudentRepo = new RegisterRepository(context);
                return _StudentRepo;
            }
        }

        
    }
}
