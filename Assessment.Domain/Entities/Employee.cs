using Assessment.Domain.Common;
using Assessment.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Domain.Entities
{
    public class Employee : BaseEntity
    {
        [MaxLength(55)]
        public string Name { get; set; }

        [MaxLength(75)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }
        public DepartmentCategoriesEnum DepartmentCategoryId { get; set; }
    }
}
