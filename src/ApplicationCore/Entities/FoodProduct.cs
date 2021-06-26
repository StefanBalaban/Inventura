using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using System.ComponentModel.DataAnnotations;
using Inventura.ApplicationCore.Constants;
using Inventura.ApplicationCore.Filters;
using Inventura.ApplicationCore.Interfaces;

namespace Inventura.ApplicationCore.Entities
{
    public class FoodProduct : BaseEntity, IAggregateRoot
    {
        [Dto]
        [Get]
        [Post]
        [Put]
        [Required]
        public string Name { get; set; }

        [Get(FilterConstants.INCLUDE)]
        public UnitOfMeasure UnitOfMeasure { get; set; }

        [Get]
        [Post]
        [Put]
        [Required]
        [Range(1, Int32.MaxValue)]
        public int UnitOfMeasureId { get; set; }

        [Dto]
        [Get(FilterConstants.GTE, FilterConstants.LTE)]
        [Post]
        [Put]
        public float Calories { get; set; }

        [Dto]
        [Get(FilterConstants.EQUAL)]
        [Post]
        [Put]
        public float Protein { get; set; }

        [Post]
        [Put]
        public float Carbohydrates { get; set; }

        [Get]
        [Post]
        public float Fats { get; set; }

        public FoodProduct()
        {
        }

        public void EditNutritionalValue(float calories, float protein, float carbohydrates, float fats)
        {
            Calories = calories;
            Protein = protein;
            Carbohydrates = carbohydrates;
            Fats = fats;
        }

        public void EditName(string name)
        {
            Guard.Against.Null(name, nameof(name));

            Name = name;
        }
    }
}