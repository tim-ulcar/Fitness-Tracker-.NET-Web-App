using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FitnessTrackerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any exercises.
            if (context.Exercises.Any())
            {
                return;   // DB has been seeded
            }


            var roles = new IdentityRole[] {
                new IdentityRole{Id="1", Name="User"},
                new IdentityRole{Id="2", Name="Administrator"}
            };

            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }
            context.SaveChanges();


            var user = new ApplicationUser {
                FirstName = "Bob",
                LastName = "Dilon",
                City = "Ljubljana",
                Email = "bob@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "bob@example.com",
                NormalizedUserName = "bob@example.com",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName)) {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Bob123!");
                user.PasswordHash = hashed;
                context.Users.Add(user);
            }
            context.SaveChanges();


            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=user.Id},
                new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=user.Id},
            };

            foreach (IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }
            context.SaveChanges();

 
            var exercises = new Exercise[]
            {
            new Exercise{exerciseName="Bench Press",musclesWorked="Chest, Triceps"},
            new Exercise{exerciseName="Bent Over Rows",musclesWorked="Back, Biceps"},
            new Exercise{exerciseName="Overhead Press",musclesWorked="Shoulders, Triceps"},
            new Exercise{exerciseName="Deadlift",musclesWorked="Back, Legs"},
            new Exercise{exerciseName="Lateral Raises",musclesWorked="Shoulders"},
            new Exercise{exerciseName="Biceps Curls",musclesWorked="Biceps"},
            new Exercise{exerciseName="Chest Flies",musclesWorked="Chest"},
            new Exercise{exerciseName="Pull Ups",musclesWorked="Back"},
            new Exercise{exerciseName="Squats",musclesWorked="Legs"}
            };
            foreach (Exercise e in exercises)
            {
                context.Exercises.Add(e);
            }
            context.SaveChanges();

            
            var exercisesPerformed = new ExercisePerformed[]
            {
            new ExercisePerformed{userId=user,exerciseName="Bench Press",time=new DateTime(2021, 5, 1, 8, 30, 22),weight=10,sets=5,reps=12},
            new ExercisePerformed{userId=user,exerciseName="Bent Over Rows",time=new DateTime(2021, 6, 1, 11, 6, 22),weight=20,sets=4,reps=8},
            new ExercisePerformed{userId=user,exerciseName="Overhead Press",time=new DateTime(2021, 7, 1, 5, 32, 52),weight=20,sets=3,reps=8},
            new ExercisePerformed{userId=user,exerciseName="Deadlift",time=new DateTime(2021, 7, 5, 6, 11, 52),weight=50,sets=4,reps=12},
            new ExercisePerformed{userId=user,exerciseName="Bench Press",time=new DateTime(2021, 6, 1, 8, 30, 52),weight=30,sets=5,reps=8},
            new ExercisePerformed{userId=user,exerciseName="Overhead Press",time=new DateTime(2021, 8, 1, 8, 30, 52),weight=10,sets=4,reps=10},
            new ExercisePerformed{userId=user,exerciseName="Lateral Raises",time=new DateTime(2021, 9, 1, 8, 30, 52),weight=20,sets=5,reps=12},
            new ExercisePerformed{userId=user,exerciseName="Lateral Raises",time=new DateTime(2021, 2, 1, 8, 30, 52),weight=50,sets=3,reps=10},
            new ExercisePerformed{userId=user,exerciseName="Pull Ups",time=new DateTime(2021, 3, 1, 8, 30, 52),weight=20,sets=5,reps=12},
            new ExercisePerformed{userId=user,exerciseName="Squats",time=new DateTime(2021, 4, 1, 8, 30, 52),weight=10,sets=3,reps=8}
            };
            foreach (ExercisePerformed e in exercisesPerformed)
            {
                context.ExercisesPerformed.Add(e);
            }
            context.SaveChanges();

           var bodyWeights = new BodyWeight[]
            {
            new BodyWeight{userId=user,time=new DateTime(2021, 5, 1, 8, 30, 22),weight=80,bodyFat=12},
            new BodyWeight{userId=user,time=new DateTime(2021, 6, 1, 11, 6, 22),weight=85,bodyFat=13},
            new BodyWeight{userId=user,time=new DateTime(2021, 7, 1, 5, 32, 52),weight=90,bodyFat=12},
            new BodyWeight{userId=user,time=new DateTime(2021, 7, 5, 6, 11, 52),weight=70,bodyFat=13},
            new BodyWeight{userId=user,time=new DateTime(2021, 6, 1, 8, 30, 52),weight=73,bodyFat=13},
            new BodyWeight{userId=user,time=new DateTime(2021, 8, 1, 8, 30, 52),weight=80,bodyFat=14},
            new BodyWeight{userId=user,time=new DateTime(2021, 9, 1, 8, 30, 52),weight=40,bodyFat=15},
            new BodyWeight{userId=user,time=new DateTime(2021, 2, 1, 8, 30, 52),weight=50,bodyFat=11},
            new BodyWeight{userId=user,time=new DateTime(2021, 3, 1, 8, 30, 52),weight=50,bodyFat=10},
            new BodyWeight{userId=user,time=new DateTime(2021, 4, 1, 8, 30, 52),weight=40,bodyFat=11}
            };
            foreach (BodyWeight b in bodyWeights)
            {
                context.BodyWeights.Add(b);
            }
            context.SaveChanges();

            var nutritions = new Nutrition[]
            {
            new Nutrition{userId=user,time=new DateTime(2021, 5, 1, 8, 30, 22),calories=2333,protein=120,carbohydrates=100,fat=20},
            new Nutrition{userId=user,time=new DateTime(2021, 6, 1, 11, 6, 22),calories=2533,protein=130,carbohydrates=120,fat=40},
            new Nutrition{userId=user,time=new DateTime(2021, 7, 1, 5, 32, 52),calories=2553,protein=140,carbohydrates=140,fat=40},
            new Nutrition{userId=user,time=new DateTime(2021, 7, 5, 6, 11, 52),calories=2755,protein=120,carbohydrates=90,fat=60},
            new Nutrition{userId=user,time=new DateTime(2021, 6, 1, 8, 30, 52),calories=2344,protein=140,carbohydrates=100,fat=20},
            new Nutrition{userId=user,time=new DateTime(2021, 8, 1, 8, 30, 52),calories=2222,protein=140,carbohydrates=100,fat=60},
            new Nutrition{userId=user,time=new DateTime(2021, 9, 1, 8, 30, 52),calories=2333,protein=150,carbohydrates=60,fat=20},
            new Nutrition{userId=user,time=new DateTime(2021, 2, 1, 8, 30, 52),calories=2666,protein=150,carbohydrates=180,fat=40},
            new Nutrition{userId=user,time=new DateTime(2021, 3, 1, 8, 30, 52),calories=2877,protein=120,carbohydrates=100,fat=20},
            new Nutrition{userId=user,time=new DateTime(2021, 4, 1, 8, 30, 52),calories=2333,protein=150,carbohydrates=200,fat=40}
            };
            foreach (Nutrition n in nutritions)
            {
                context.Nutritions.Add(n);
            }
            context.SaveChanges();

        }
    }
}