namespace Ananev_Artem_Kt_41_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int HeadTeacherId { get; set; }

        public virtual Teacher HeadTeacher { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}