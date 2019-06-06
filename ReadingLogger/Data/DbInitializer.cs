using IdentityExample.Models;
using Microsoft.AspNetCore.Identity;
using ReadingLogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingLogger.Models
{
    public static class DbInitializer
    {
        public static UserManager<AppUser> UserManager { get; set; }

        public static void EnsureSeeded(this ApplicationDbContext context)
        {
            if (UserManager.FindByEmailAsync("scott@eventmanagement.local").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Scott",
                    LastName = "Kuhl",
                    UserName = "scott@identity.local",
                    Email = "scott@idenity.local",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "P@ssword1").GetAwaiter().GetResult();
            }
        }
        public static void Initialize(LoggerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }
            var students = new Student[]
           {
                new Student { FirstName = "Molly",   LastName = "Matheny",
                    Teacher = "Restivo", CurrentBook = "Harry Potter", Section = "4R" },
                new Student { FirstName = "Celina",   LastName = "Zabala",
                    Teacher = "Hudgens", CurrentBook = "Squirm", Section = "4H" },
                new Student { FirstName = "Vivian",   LastName = "Streit",
                    Teacher = "Siegler", CurrentBook = "Sisters", Section = "4S" },
                new Student { FirstName = "Blake",   LastName = "Keller",
                    Teacher = "Restivo", CurrentBook = "Bone", Section = "4R" },
                new Student { FirstName = "Cooper",   LastName = "Krupnick",
                    Teacher = "Hudgens", CurrentBook = "Percy Jackson", Section = "4H" },
                new Student { FirstName = "Marcus",   LastName = "Helton",
                    Teacher = "Siegler", CurrentBook = "Spiderwick Chronicles", Section = "4S" },
                new Student{ FirstName = "Elysia",   LastName = "Zabala",
                    Teacher = "Carson", CurrentBook = "The Selection", Section = "7G" },
                new Student { FirstName = "Bradley",   LastName = "Rosborg",
                    Teacher = "Carson", CurrentBook = "Maze Runner", Section = "7F" },
           };
                foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            //if (context.Section.Any())
            //{
              //  return;   // DB has been seeded
            //}
           // var sections = new Section[]
            //{
             //   new Section {SectionID = 1050, Title = "4H",      Grade = 4},
               // new Section {SectionID = 1060, Title = "4S",      Grade = 4 },
                //new Section {SectionID = 1070, Title = "4R",      Grade = 4 },
                //new Section {SectionID = 1080, Title = "7G",      Grade = 7 },
                //new Section {SectionID = 1090, Title = "7C",      Grade = 7 },
               // new Section {SectionID = 2000, Title = "7F",      Grade = 7 },
               // new Section {SectionID = 2010, Title = "5F",      Grade = 5 },
            //};

           // foreach (Section s in sections)
            //{
             //   context.Section.Add(s);
            //}
           // context.SaveChanges();

            //if (context.Entry.Any())
            //{
             //   return;   // DB has been seeded
            //}
            var entries = new Entry[]
            {
            new Entry {StudentID = 1,  Book = "Harry Potter", Minutes = 20 , Pages = 15, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 1, Book = "Harry Potter", Minutes = 30 , Pages = 20, LogDate = DateTime.Parse("2013-09-02"), },
            new Entry {StudentID = 2,  Book = "Squirm", Minutes = 20 , Pages = 15, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 2,  Book = "Squirm", Minutes = 15 , Pages = 10, LogDate = DateTime.Parse("2013-09-02"), },
            new Entry {StudentID = 3,  Book = "Sisters", Minutes = 45 , Pages = 30, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 4,  Book = "Bone", Minutes = 20 , Pages = 25, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 4,  Book = "Bone", Minutes = 30 , Pages = 45, LogDate = DateTime.Parse("2013-09-02"), },
            new Entry {StudentID = 5,  Book = "Percy Jackson", Minutes = 20 , Pages = 15, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 6, Book = "Spiderwick Chronicles", Minutes = 30 , Pages = 20, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 7,  Book = "The Selection", Minutes = 90 , Pages = 60, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 1,  Book = "Harry Potter", Minutes = 20 , Pages = 15, LogDate = DateTime.Parse("2013-09-01"), },
            new Entry {StudentID = 2,  Book = "Squirm", Minutes = 60 , Pages = 45, LogDate = DateTime.Parse("2013-09-03"), }
            };
            foreach (Entry e in entries)
            {
                context.Entry.Add(e);
            }
            
                context.SaveChanges();
            

        }
    
        
    }
}
