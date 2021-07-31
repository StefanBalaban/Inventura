using Ardalis.GuardClauses;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Entities.MealAggregate
{
    public class Meal : BaseEntity, IAggregateRoot
    {
        private readonly List<MealItem> _items = new List<MealItem>();
        public IReadOnlyList<MealItem> Items => _items.AsReadOnly();
        public string Name { get; private set; }

        public Meal()
        {
        }

        public Meal(List<MealItem> items, string name)
        {
            Guard.Against.Null(items, nameof(items));
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            _items = items;
            Name = name;
        }

        public void EditName(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            Name = name;
        }

        public void AddMeals(List<MealItem> items)
        {
            Guard.Against.Null(items, nameof(items));

            _items.AddRange(items);
        }

        public void RemoveMeals(List<MealItem> items)
        {
            Guard.Against.Null(items, nameof(items));

            items.ForEach(item =>
            {
                var mealItemToRemove = _items.SingleOrDefault(y => y.Id == item.Id);
                if (mealItemToRemove != null) _items.Remove(item);
            });
        }
    }
}