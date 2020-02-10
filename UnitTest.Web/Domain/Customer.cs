using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace UnitTest.Web.Domain
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }

    public class DataContext : DbContext
    {
        public DataContext():base("Server=localhost\\sqlexpress;Database=mydbTest;Trusted_Connection=True;")
        {
                
        }
        public DbSet<Customer> Customers { get; set; }
    }
    
}