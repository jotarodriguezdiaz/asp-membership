using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Memberships.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Memberships.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Registered{ get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Part> Parts{ get; set; }
        public DbSet<ItemType> ItemTypes{ get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductType> ProductTypes{ get; set; }
        public DbSet<ProductLinkText> ProductLinkTexts{ get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<SubscriptionProduct> SubscriptionProducts { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
    }
}