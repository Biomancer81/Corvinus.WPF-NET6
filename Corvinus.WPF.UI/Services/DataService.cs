using System.Collections.Generic;

namespace Corvinus.WPF.UI.Services
{
    public class DataService : IDataService
    {
        public DataService() { }

        public List<string> GetDataSample()
        {
            return new List<string> { "One", "Two", "Three", "Four", "Five" };
        }
    }
}
