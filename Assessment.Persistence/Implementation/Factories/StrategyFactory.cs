using Assessment.Application.Contracts.Factories;
using Assessment.Application.Contracts.Strategies;
using Assessment.Domain.Enums;
using Assessment.Persistence.Implementation.Strategies.AddEmployee;

namespace Assessment.Persistence.Implementation.Factories
{
    internal class StrategyFactory : IStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGetEmployeeDescriptionStrategy GetEmployeeDescriptionStrategy(int departmentId)
        {
            switch (departmentId)
            {
                case (int)DepartmentCategoriesEnum.TECH:
                    return _serviceProvider.GetService(typeof(GetEmployeeTechDescriptionStrategy)) as IGetEmployeeDescriptionStrategy;
                case (int)DepartmentCategoriesEnum.OPERATIONS:
                    return _serviceProvider.GetService(typeof(GetEmployeeOperationsDescriptionStrategy)) as IGetEmployeeDescriptionStrategy;
                default:
                    return _serviceProvider.GetService(typeof(GetEmployeeUnassignedDescriptionStrategy)) as IGetEmployeeDescriptionStrategy;
            }
        }
    }

}
