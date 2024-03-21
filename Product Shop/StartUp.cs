using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOClassesMapping;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


        }

        // Problem - 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            return "";
        }

        // Problem - 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p =>  p.Price >= 500m && p.Price <= 1000m)
                .OrderBy(x=>x.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            //File.WriteAllText("products-in-range.json",query);
            string productsJson = JsonConvert.SerializeObject(products,Formatting.Indented);

            return productsJson;
        }

        // Problem - 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            // Option -- 1
            List<CategoryProduct> catProduct = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            // Option--2
            //CategoryProductDTO[] categoryProducts = JsonConvert.DeserializeObject<CategoryProductDTO[]>(inputJson);
            //ICollection<CategoryProduct> categoryProductsCollection = new List<CategoryProduct>();
            //
            //foreach (CategoryProductDTO catPro in categoryProducts)
            //{
            //    CategoryProduct prod = Mapper.Map<CategoryProduct>(catPro);
            //    categoryProductsCollection.Add(prod);
            //}


            context.AddRange(catProduct);
            context.SaveChanges();

            return $"Successfully imported {catProduct.Count}";
        }

        // Problem - 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            // option to import -- 1
            //List<Category> Categories = new List<Category>();
            //Categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
            ICollection<Category> Categories = new List<Category>();

            foreach (ImportCategoryDto cat in categoryDtos)
            {
                if (cat.Name == null)
                {
                    continue;
                }
                Category category = Mapper.Map<Category>(cat);
                Categories.Add(category);
            }


            context.AddRange(Categories);
            context.SaveChanges();

            return $"Successfully imported {Categories.Count}";
        }

        // Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            // Option - 1
            //List<Product> products = new List<Product>();
            //
            //products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            // Option - 2
            ImportProductDto[] products = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            ICollection<Product> allProducts = new List<Product>();

            foreach (ImportProductDto product in products)
            {
                Product prod = Mapper.Map<Product>(product);
                allProducts.Add(prod);
            }

            context.AddRange(allProducts);
            context.SaveChanges();

            return $"Successfully imported {allProducts.Count}";
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            // option - 1
            // List<User> users= new List<User>();
            //
            // users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            //
            // context.Users.AddRange(users);
            // context.SaveChanges();

            // option - 2
            UsersDto[] usersdto = JsonConvert.DeserializeObject<UsersDto[]>(inputJson);
            ICollection<User> users = new List<User>();

            foreach (UsersDto usr in usersdto)
            {
                User user = Mapper.Map<User>(usr);
                users.Add(user);
            }

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}