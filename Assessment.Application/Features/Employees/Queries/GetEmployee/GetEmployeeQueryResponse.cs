namespace Assessment.Application.Features.Employees.Queries.GetEmployee
{
    public class GetEmployeeQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DepartmentCategory { get; set; }
    }
}