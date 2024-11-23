using Assessment.Application.Contracts.Strategies;

namespace Assessment.Application.Contracts.Factories
{
    public interface IStrategyFactory
    {
        IGetEmployeeDescriptionStrategy GetEmployeeDescriptionStrategy(int departmentId);
    }
}
