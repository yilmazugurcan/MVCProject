namespace DataAccess.Migrations
{
    using DataAccess.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bogus;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.Context.AppDbContext context)
        {
            #region Manuel Seed Data
            List<Category> categories = new List<Category>()
            {
                new Category{ID=Guid.NewGuid(),CategoryName="Giyim"},
                new Category{ID=Guid.NewGuid(),CategoryName="Teknoloji"},
                new Category{ID=Guid.NewGuid(),CategoryName="Mobilya"}
            };



            //Category
            if (!context.Categories.Any())
            {
                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }

            }


            List<SubCategory> subCategories = new List<SubCategory>()
            {
                new SubCategory{ID=Guid.NewGuid(),CategoryId=context.Categories.Where(x=>x.CategoryName.Contains("Giyim")).FirstOrDefault().ID,SubCategoryName="Ayakkabı"},
                new SubCategory{ID=Guid.NewGuid(),CategoryId=context.Categories.Where(x=>x.CategoryName.Contains("Teknoloji")).FirstOrDefault().ID,SubCategoryName="Bilgisayar"},
                new SubCategory{ID=Guid.NewGuid(),CategoryId=context.Categories.Where(x=>x.CategoryName.Contains("Mobilya")).FirstOrDefault().ID,SubCategoryName="Koltuk"},


            };

            //SubCategory
            if (!context.SubCategories.Any())
            {
                foreach (var subCategory in subCategories)
                {
                    context.SubCategories.Add(subCategory);
                    context.SaveChanges();
                }
            }


            List<Product> products = new List<Product>()
            {
                new Product{ID=Guid.NewGuid(),ProductName="Nike Air",UnitPrice=600,SubCategoryId=context.SubCategories.Where(x=>x.SubCategoryName=="Ayakkabı").FirstOrDefault().ID,UnitsInStock=200},
                new Product{ID=Guid.NewGuid(),ProductName="MSI XYZ",UnitPrice=16000,SubCategoryId=context.SubCategories.Where(x=>x.SubCategoryName=="Bilgisayar").FirstOrDefault().ID,UnitsInStock=100},
                new Product{ID=Guid.NewGuid(),ProductName="L Koltuk",UnitPrice=6000,SubCategoryId=context.SubCategories.Where(x=>x.SubCategoryName=="Koltuk").FirstOrDefault().ID,UnitsInStock=10}
            };



            //Product
            if (!context.Products.Any())
            {
                foreach (var product in products)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            #endregion

            #region Bogus Fake Data
            //List<Category> categories = new List<Category>();

            //for (int i = 0; i < 20; i++)
            //{
            //    var testCategories = new Faker<Category>()
            //        .RuleFor(x => x.ID, f => f.Random.Guid())
            //        .RuleFor(x => x.CategoryName, f => f.Commerce.Categories(1).FirstOrDefault())
            //        .RuleFor(x => x.Description, f => f.Lorem.Word());

            //} 
            #endregion

        }
    }
}
