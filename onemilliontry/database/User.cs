// using System.ComponentModel.DataAnnotations;
// using System.Linq.Expressions;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Razor;
// using Microsoft.EntityFrameworkCore;

// namespace onemilliontry
// {
//     // public class  UserContext:DbContext{
//     //     public UserContext(DbContextOptions<UserContext> options)
//     //         :base(options){
//     //             // Database.EnsureCreated();
//     //         }
//     //         public DbSet<User>Users{get;set;} = null!;

//     public class User
//     {
//         [Required]
//         public string Id { get; set; } = string.Empty;
//         [Required]
//         public string UserName { get; set; } = string.Empty;
//         [Required]
//         public string Password { get; set; } = string.Empty;
//         [Required]
//         public string Mail { get; set; } = string.Empty;
//         [Required]
//         public string Phone { get; set; } = string.Empty;
//         [Required]
//         public string Card { get; set; } = string.Empty;
//         [Required]
//         public string DateCreated { get; set; } = string.Empty;
//     }

//     public class UserDBModel:DbContext{
//         public UserDBModel:DbContext
//         {
//             public UserDBModel(DbContextOptions<UserDBModel> options):base(options)
//             {}
//             public DbSet<User> Users{ get;set; } = default!;
//         }
//     }

//     public static class SeadData
//     {
//         public static void Initialize(IServerProvider serverProvider)
//         {
//             using (var context = new UserDBModels(
//                 serviceProvider.GetRequiredService<
//                 DbContextOptions<UserDBModels>>()
//             )){
//                if(context == null||context.User == null)
//                {
//                 throw new ArgumentNullException("Null Razor Page Movie Context");
//                }

//                if(context.User.Any())
//                {
//                     return;
//                }
//                context.User.AddRange(
//                 new User
//                 {
//                     Id =  Guid.NewGuid().ToString(),
//                     UserName = "glich",
//                     Password = "qwerty17",
//                     Mail = "glich.snake@gmail.com",
//                     Phone = "+380959386691",
//                     Card = Guid.NewGuid().ToString(),
//                     DateCreated = DateTime.Now.Ticks.ToString()
//                 });
            
//             }
//         }
//     }
// }


//public bool Role {get;set;} 
// public Role role {get;set;}
// //public UserProperties UserProperties {get;set;}
// public User(string id, string username, string password, string confirmpassword, string  mail, string cardid, string cardcv, string carddate, string phone, Role role){
//     Id = id;
//     UserName = username;
//     Password = password;
//     Conffirmpasword = confirmpassword;
//     Mail = mail;
//     CardID = cardid;
//     CardCV = cardcv;
//     CardDate = carddate;
//     Phone = phone;
//     Role = role;
// }
// }
// class Role
// {
//     [Required]
//     public string Name {get;set;} = string.Empty;
//     public Role(string  name)=> Name = name;
// }
// public class Card
// {
//     [Required]
//     public string ID{get;set;} = string.Empty;
//     [Required]
//     public string CV{get;set;} = string.Empty;
//     [Required]
//     public DateOnly Date{get;set;}
// }
// public class UserProperties
// {
//     public int STR{get;set;}
//     public int AGY{get;set;}
//     public int INT{get;set;}
//public ELEMENT element{get;set;}
//}
// public class ELEMENT{
//     public bool ishas{get;set;}=false;
//     public string FIRE{get;set;}
//     public string WATER{get;set;}
//     public string 
// }



// protected override void OnModelCreating(ModelBuilder modelBuilder)
// {
//     modelBuilder.Entity<User>().HasData(
//         //new User {}
//         new User {Id = Guid.NewGuid().ToString(),UserName="light",Password="qwerty17",Phone="3808084678172",CardID= "1725135466782125", CardCV ="376", CardDate="20/06", Mail="qwerty17@gmail.com"}
//     );
// }
// [HttpPost]
// public async Task<List<User>>PostUser(User user)
// {
//     _user = user;
// }

//private User _user;




