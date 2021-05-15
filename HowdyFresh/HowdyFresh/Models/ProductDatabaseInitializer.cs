using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Models
{
    public class ProductDatabaseInitializer<ApplicationDbContext> : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }
        private static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Food"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Decorations"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Utensils"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Furniture"
                }
            };
            return categories;
        }
        private static List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    Productname = "Tomatoes",
                    Description = "Delicious vine-ripened tomatoes grown locally. Prices per pound.",
                    UnitPrice = 1.89,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 2,
                    Productname = "Eggs",
                    Description = "Farm fresh eggs! Prices per dozen.",
                    UnitPrice = 1.25,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 3,
                    Productname = "Ground Chicken",
                    Description = "Fresh chicken ground at a local butcher shop. Prices per pound.",
                    UnitPrice = 3.50,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 4,
                    Productname = "Ground Beef",
                    Description = "Fresh beef ground at a local butcher shop. Prices per pound.",
                    UnitPrice = 4.00,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 5,
                    Productname = "Ribeye Steaks",
                    Description = "Fresh ribeye steaks cut at a local butcher shop. Prices per pound.",
                    UnitPrice = 13.99,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 6,
                    Productname = "Milk",
                    Description = "Delicious whole milk from local dairy cows. Prices per gallon.",
                    UnitPrice = 2.99,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 7,
                    Productname = "Lemons",
                    Description = "Freshly grown lemons! Prices per pound.",
                    UnitPrice = 1.85,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 8,
                    Productname = "Yellow Squash",
                    Description = "Delicious, organic yellow squash! Prices per pound.",
                    UnitPrice = 1.99,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 9,
                    Productname = "Garlic",
                    Description = "Locally grown bulbs of garlic! Prices per pound.",
                    UnitPrice = 2.00,
                    CategoryID = 1,
                },
                new Product
                {
                    ProductID = 10,
                    Productname = "Wooden Chair",
                    Description = "A hand-crafted wooden chair, perfect for seating. Prices per chair.",
                    UnitPrice = 45.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 11,
                    Productname = "Wooden Table (small)",
                    Description = "A charming hand-crafted wooden table which can seat two people. Prices per table.",
                    UnitPrice = 70.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 12,
                    Productname = "Wooden Table (large)",
                    Description = "A beautiful hand-crafted wooden table which can seat up to six people. Prices per table.",
                    UnitPrice = 150.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 13,
                    Productname = "Diner-Style Booth",
                    Description = "Looking for a more retro style for your restaurant? This delightful diner-style booth is perfect! It can seat up to four, and comes with a table included. Prices per unit.",
                    UnitPrice = 275.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 14,
                    Productname = "Metal Chair",
                    Description = "A metal, weather-resistant chair, pefect for outdoor seating. Prices per chair.",
                    UnitPrice = 80.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 15,
                    Productname = "Metal Table (small)",
                    Description = "A small metal table that can seat two comfortably. Prices per table.",
                    UnitPrice = 120.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 16,
                    Productname = "Metal Table (medium)",
                    Description = "A medium metal that can comfortably seat four. Prices per table.",
                    UnitPrice = 170.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 17,
                    Productname = "Metal Table (large)",
                    Description = "A large metal table that can comfortably seat six. Perfect for outdoor brunch! Prices per table.",
                    UnitPrice = 250.00,
                    CategoryID = 4,
                },
                new Product
                {
                    ProductID = 18,
                    Productname = "Set of Silverware",
                    Description = "A perfectly crafted set of silverware. Sets include 10 forks, 10 salad forks, 10 butter knives, 10 spoons, and 10 soup spoons. Prices per set.",
                    UnitPrice = 16.00,
                    CategoryID = 3,
                },
                new Product
                {
                    ProductID = 19,
                    Productname = "Set of Flatware",
                    Description = "Beatiful cermaic set of plates and bowls. Set includes 10 dinner plates, 10 small plates, 10 soup bowls, and 10 salad bowls. Prices per set.",
                    UnitPrice = 90.00,
                    CategoryID = 3,
                },
                new Product
                {
                    ProductID = 20,
                    Productname = "Full Set of Pots and Pans",
                    Description = "This fantastic set of pots and pans is perfect for any kitchen! Prices per set.",
                    UnitPrice = 275.00,
                    CategoryID = 3,
                },
                new Product
                {
                    ProductID = 21,
                    Productname = "Cooking Utensil Set",
                    Description = "Fantastic set of spatulas, large spoons, whisks, tongs, ladles, and sauce brushes! Prices per set.",
                    UnitPrice = 56.00,
                    CategoryID = 3,
                },
                new Product
                {
                    ProductID = 22,
                    Productname = "Kitschy Wall Decorations",
                    Description = "A randomized, 20 pc set of assorted, generic wall art pieces, including paintings, posters, mountable objects, and decals. Prices per set.",
                    UnitPrice = 45.00,
                    CategoryID = 2,
                },
                new Product
                {
                    ProductID = 23,
                    Productname = "Scentless Candles",
                    Description = "A set of 20 unscented candles, perfect for setting the ambience for an evening out. Prices per set.",
                    UnitPrice = 20.00,
                    CategoryID = 2,
                },
                new Product
                {
                    ProductID = 24,
                    Productname = "Dark Blue Tablecloths",
                    Description = "A set of dark blue tablecloths that includes one small, one medium, and one large. Prices per set.",
                    UnitPrice = 30.00,
                    CategoryID = 2,
                },
                new Product
                {
                    ProductID = 25,
                    Productname = "Large Umbrella",
                    Description = "These are large umbrellas designed to be weighted down to provide shade for outdoor seating. Prices per umbrella.",
                    UnitPrice = 20.00,
                    CategoryID = 2,
                }
            };
            return products;
        }
    }
}
