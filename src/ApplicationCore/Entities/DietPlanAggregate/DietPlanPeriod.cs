using Ardalis.GuardClauses;
using System;

namespace ApplicationCore.Entities.DietPlanAggregate
{
    public class DietPlanPeriod : BaseEntity
    {
        public DietPlan DietPlan { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public DietPlanPeriod()
        {
        }

        public DietPlanPeriod(DietPlan dietPlan, DateTime startDate, DateTime endDate)
        {
            Guard.Against.Null(dietPlan, nameof(dietPlan));
            Guard.Against.Null(startDate, nameof(startDate));
            Guard.Against.Null(endDate, nameof(endDate));

            DietPlan = dietPlan;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void EditDietPlan(DietPlan dietPlan)
        {
            Guard.Against.Null(dietPlan, nameof(dietPlan));

            DietPlan = dietPlan;
        }

        public void EditStartDate(DateTime startDate)
        {
            Guard.Against.Null(startDate, nameof(startDate));

            StartDate = startDate;
        }

        public void EditEndDate(DateTime endDate)
        {
            Guard.Against.Null(endDate, nameof(endDate));

            EndDate = endDate;
        }
    }
}