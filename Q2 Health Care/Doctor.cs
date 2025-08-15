namespace Assignment3.Question2_Healthcare
{
    public class Doctor
    {
        public int Id { get; }
        public string Name { get; }
        public string Specialty { get; }

        public Doctor(int id, string name, string specialty)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
        }

        public override string ToString() => $"Dr. {Name} ({Specialty}), ID: {Id}";
    }
}
