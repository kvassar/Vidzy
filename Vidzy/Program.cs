using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vidzy
{
    internal class Program
    {
        public class Video
        {
            public int ID { get; set; }

            public string Title { get; set; }

            public IList<Genre> Genre { get; set; }
        }

        public class Genre
        {
            public byte ID { get; set; }

            public string Name { get; set; }

            public IList<Video> Videos { get; set; }
        }

        public class VidzyContext : DbContext
        {
            public DbSet<Video> Videos { get; set; }
            public DbSet<Genre> Genre { get; set; }

            public VidzyContext()
                : base("name=DefaultConnection")
            {

            }
        }
        static void Main(string[] args)
        {
        }
    }
}
