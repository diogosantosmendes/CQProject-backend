using System.Data.Entity;

namespace CQPROJ.Data.DB.Models
{
    public partial class DBContextModel : DbContext
    {
        public DBContextModel()
            : base("name=DBContextModel")
        {
        }

        public virtual DbSet<TblActions> TblActions { get; set; }
        public virtual DbSet<TblClasses> TblClasses { get; set; }
        public virtual DbSet<TblClassUsers> TblClassUsers { get; set; }
        public virtual DbSet<TblDocuments> TblDocuments { get; set; }
        public virtual DbSet<TblDone> TblDone { get; set; }
        public virtual DbSet<TblEvaluations> TblEvaluations { get; set; }
        public virtual DbSet<TblEvaluationStudents> TblEvaluationStudents { get; set; }
        public virtual DbSet<TblFloors> TblFloors { get; set; }
        public virtual DbSet<TblLessons> TblLessons { get; set; }
        public virtual DbSet<TblLessonStudents> TblLessonStudents { get; set; }
        public virtual DbSet<TblNotices> TblNotices { get; set; }
        public virtual DbSet<TblNotifications> TblNotifications { get; set; }
        public virtual DbSet<TblParenting> TblParenting { get; set; }
        public virtual DbSet<TblRecords> TblRecords { get; set; }
        public virtual DbSet<TblRoles> TblRoles { get; set; }
        public virtual DbSet<TblRooms> TblRooms { get; set; }
        public virtual DbSet<TblSchedules> TblSchedules { get; set; }
        public virtual DbSet<TblSchools> TblSchools { get; set; }
        public virtual DbSet<TblSensors> TblSensors { get; set; }
        public virtual DbSet<TblSubjects> TblSubjects { get; set; }
        public virtual DbSet<TblTasks> TblTasks { get; set; }
        public virtual DbSet<TblTimes> TblTimes { get; set; }
        public virtual DbSet<TblUserRoles> TblUserRoles { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }
        public virtual DbSet<TblValidations> TblValidations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { }
    }
}
