namespace MinimalCrud.Model
{
    public class StudentModel
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}
