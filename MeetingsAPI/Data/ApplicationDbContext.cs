using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MeetingsAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json;

namespace MeetingsAPI.Data
{
    public class UserSeedModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        //DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Meetings> Meetings { get; set; }

        public DbSet<Attendee> Attendee { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public static List<UserSeedModel> LoadJsonData(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserSeedModel>>(json);
        }

        public static List<Meetings> LoadJsonDataMeeting(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Meetings>>(json);
        }   

        public static List<Attendee> LoadJsonDataAttendee(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Attendee>>(json);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Many-to-Many relationship
            modelBuilder.Entity<Attendee>()
                .HasKey(a => new { a.ApplicationUserId, a.MeetingId }); // Composite key

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(u => u.Attendees)
                .HasForeignKey(a => a.ApplicationUserId);

            //modelBuilder.Entity<Attendee>()
            //    .HasOne(a => a.ApplicationUser)
            //    .WithMany(u => u.Attendees)
            //    .HasForeignKey(a => a.Email);

            modelBuilder.Entity<ApplicationUser>()
            .HasIndex(u => u.Email)
            .IsUnique();  // Enforce unique constraint on Email


            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Meeting)
                .WithMany(m => m.Attendees)
                .HasForeignKey(a => a.MeetingId);

            //var passwordHasher = new PasswordHasher<ApplicationUser>();

            //// Define the users
            //var user1 = new ApplicationUser
            //{
            //    Id = "12",
            //    UserName = "john.doe",
            //    NormalizedUserName = "JOHN.DOE",
            //    Email = "john.doe@example.com",
            //    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
            //    EmailConfirmed = true,
            //    PhoneNumber = "1234567890",
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D")
            //};

            //var user2 = new ApplicationUser
            //{
            //    Id = "13",
            //    UserName = "jane.smith",
            //    NormalizedUserName = "JANE.SMITH",
            //    Email = "jane.smith@example.com",
            //    NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
            //    EmailConfirmed = true,
            //    PhoneNumber = "9876543210",
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D")
            //};

            //// Hash the passwords
            //user1.PasswordHash = passwordHasher.HashPassword(user1, "Password123!");
            //user2.PasswordHash = passwordHasher.HashPassword(user2, "Password123!");

            //// Seed the users
            //modelBuilder.Entity<ApplicationUser>().HasData(user1, user2);

            //var meetings = new List<Meetings>
            //{
            //    new Meetings
            //    {
            //        Id = 1,
            //        Name = "Test",
            //        Description = "Test",
            //        Date = DateOnly.FromDateTime(DateTime.Now),
            //        startTime = new TimeOnly(9,30,0),
            //        endTime = new TimeOnly(10,30,0),
            //    },
            //    new Meetings
            //    {
            //        Id = 2,
            //        Name = "Test",
            //        Description = "Test",
            //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            //        startTime = new TimeOnly(9,30,0),
            //        endTime = new TimeOnly(10,30,0),
            //    }
            //};

            //modelBuilder.Entity<Meetings>().HasData(meetings);

            //var attendee = new List<Attendee>{
            //            new Attendee
            //            {
            //                ApplicationUserId = user1.Id,
            //                //Email = user1.Email,
            //                MeetingId = 1,
            //            },
            //            new Attendee
            //            {
            //                ApplicationUserId = user2.Id,
            //                //Email = user2.Email,
            //                MeetingId = 1,
            //            },
            //            new Attendee
            //            {
            //                ApplicationUserId = user2.Id,
            //                //Email = user2.Email,
            //                MeetingId = 2,
            //            }
            //        };
            //modelBuilder.Entity<Attendee>().HasData(attendee);


            //    var readerRoleId = "a71a55d6-99d7-4123-b4e0-1218ecb90e3e";
            //    var writerRoleId = "c309fa92-2123-47be-b397-a1c77adb502c";

            //    var roles = new List<IdentityRole>
            //{
            //    new IdentityRole
            //    {
            //        Id = readerRoleId,
            //        ConcurrencyStamp = readerRoleId,
            //        Name = "Reader",
            //        NormalizedName = "Reader".ToUpper()
            //    },
            //    new IdentityRole
            //    {
            //        Id = writerRoleId,
            //        ConcurrencyStamp = writerRoleId,
            //        Name = "Writer",
            //        NormalizedName = "Writer".ToUpper()
            //    }
            //};

            //    modelBuilder.Entity<IdentityRole>().HasData(roles);


            var users = LoadJsonData("users.raw.json");

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var seedUsers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var appUser = new ApplicationUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    NormalizedUserName = user.UserName.ToUpper(),
                    NormalizedEmail = user.Email.ToUpper(),
                    EmailConfirmed = true
                };

                // Hash the password
                appUser.PasswordHash = passwordHasher.HashPassword(appUser, user.Password);

                seedUsers.Add(appUser);
            }
            // Seed users
            modelBuilder.Entity<ApplicationUser>().HasData(seedUsers);

            var Meetings = LoadJsonDataMeeting("meetings.json");
            var SeedMeeting = new List<Meetings>();

            foreach(var meeting in Meetings)
            {
                var appMeeting = new Meetings
                {
                    Id = meeting.Id,
                    Name = meeting.Name,
                    Description = meeting.Description,
                    Date = DateOnly.Parse(meeting.Date.ToString()),
                    startTime = TimeOnly.Parse(meeting.startTime.ToString()),
                    endTime = TimeOnly.Parse(meeting.endTime.ToString()),
                };
                SeedMeeting.Add(appMeeting);
            }

            modelBuilder.Entity<Meetings>().HasData(SeedMeeting);


            var AttendeeData = LoadJsonDataAttendee("attendee.json");
            var SeedAttendee = new List<Attendee>();

            foreach(var attendee in AttendeeData)
            {
                var appAttendee = new Attendee
                {
                    ApplicationUserId = attendee.ApplicationUserId,
                    MeetingId = attendee.MeetingId
                };
                SeedAttendee.Add(appAttendee);
            }

            modelBuilder.Entity<Attendee>().HasData(SeedAttendee);

        }
    }

}
