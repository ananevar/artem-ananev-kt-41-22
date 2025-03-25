namespace Ananev_Artem_Kt_41_22.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
