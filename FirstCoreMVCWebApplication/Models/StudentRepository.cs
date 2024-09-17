namespace FirstCoreMVCWebApplication.Models
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {
            //Please Change the Path to your file path
            string filePath = @"C:\Kamal\.net Training\Log\Log.txt";
            string contentToWrite = $"StudentRepository Object Created: @{DateTime.Now.ToString()}";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(contentToWrite);
            }
        }

        public List<Student> DataSource()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
                new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
                new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
        }

        public Student GetStudentById(int StudentID)
        {
            return DataSource().FirstOrDefault(e => e.StudentId == StudentID) ?? new Student();
        }

        public List<Student> GetAllStudent()
        {
            return DataSource().ToList();
        }
    }
}
