using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Inventura.ApplicationCore.Entities.MealAggregate;
using Inventura.ApplicationCore.Interfaces;

namespace Inventura.ApplicationCore.Entities.DietPlanAggregate
{
    public class DietPlan : BaseEntity
    {
        private readonly List<Meal> _meals = new List<Meal>();
        public IReadOnlyList<Meal> Meals => _meals.AsReadOnly();
        public string Name { get; private set; }

        public DietPlan()
        {
        }

        public DietPlan(List<Meal> meals, string name)
        {
            Guard.Against.Null(meals, nameof(meals));
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            _meals = meals;
            Name = name;
        }

        public void EditName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            Name = name;
        }

        public void AddMeals(List<Meal> meals)
        {
            Guard.Against.Null(meals, nameof(meals));

            _meals.AddRange(meals);
        }

        public void RemoveMeals(List<Meal> meals)
        {
            Guard.Against.Null(meals, nameof(meals));

            meals.ForEach(meal =>
            {
                var mealToRemove = _meals.SingleOrDefault(y => y.Id == meal.Id);
                if (mealToRemove != null) _meals.Remove(meal);
            });
        }
    }
}