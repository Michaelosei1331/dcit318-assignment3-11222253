namespace Assignment3.Question2_Healthcare
{
    public class Patient
    {
        public int Id { get; }
        public string Name { get; }
        public int Age { get; }

        public Patient(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString() => $"Patient: {Name}, Age: {Age}, ID: {Id}";
    }
}
