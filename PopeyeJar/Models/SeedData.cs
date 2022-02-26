using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PopeyeJar.Data;
using System;
using System.Linq;

namespace PopeyeJar.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new PopeyeJarContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PopeyeJarContext>>()))
            {
                if (context.Jar.Any())
                {
                    return;
                }

                context.Jar.AddRange(
                    new Jar
                    {
                        
                        Colour = "Purple",
                        Material = "Ceramic",
                        Shape = "Round",
                        Capacity = "5 quarts",
                        Rating = 2
                        
                    },
                    new Jar
                    {
                        
                        Colour = "Clear",
                        Material = "Glass",
                        Shape = "Pineapple",
                        Capacity = "2 quarts",
                        Rating = 4
                    },
                    new Jar
                    {
                        
                        Colour = "Yellow",
                        Material = "Ceramic",
                        Shape = "Hive",
                        Capacity = "6 quarts",
                        Rating = 5
                    },
                    new Jar
                    {
                        
                        Colour = "Silver",
                        Material = "Silver",
                        Shape = "Square",
                        Capacity = "10 quarts",
                        Rating = 5
                    },
                    new Jar
                    {
                       
                        Colour = "Pink",
                        Material = "Ceramic",
                        Shape = "Butterfly",
                        Capacity = "3 quarts",
                        Rating = 4
                    },
                    new Jar
                    {
                        
                        Colour = "Brown",
                        Material = "Wood",
                        Shape = "EGG",
                        Capacity = "12 quarts",
                        Rating = 5
                    },
                    new Jar
                    {
                        
                        Colour = "Mustard",
                        Material = "Plastic",
                        Shape = "Cylinder",
                        Capacity = "13 quarts",
                        Rating = 4
                    },
                    new Jar
                    {
                        
                        Colour = "White",
                        Material = "Glass",
                        Shape = "Bird",
                        Capacity = "5 quarts",
                        Rating = 1
                    },
                    new Jar
                    {
                        
                        Colour = "Black",
                        Material = "Ceramic",
                        Shape = "Round",
                        Capacity = "14 quarts",
                        Rating = 5
                    },
                    new Jar
                    {
                        
                        Colour = "Grey",
                        Material = "Steel",
                        Shape = "Round",
                        Capacity = "2 quarts",
                        Rating = 1
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
