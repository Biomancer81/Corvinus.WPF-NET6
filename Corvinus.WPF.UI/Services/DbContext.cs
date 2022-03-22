using System.Collections.Generic;

namespace Corvinus.WPF.UI.Services
{
    public class DbContext : IDbContext
    {
        public DbContext() { }

        public List<string> GetDataSample()
        {
            return new List<string> { "One", "Two", "Three", "Four", "Five" };
        }
    }
}
