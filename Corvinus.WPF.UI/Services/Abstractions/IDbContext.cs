using System.Collections.Generic;

namespace Corvinus.WPF.UI.Services
{
    public interface IDbContext
    {
        public List<string> GetDataSample();
    }
}
