namespace rabotyagiszavoda.Model
{
    public class Projects
    {
        public int ProjId { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public int? WorkerId { get; set; }

        public  Workers Worker { get; set; }
    }
}
