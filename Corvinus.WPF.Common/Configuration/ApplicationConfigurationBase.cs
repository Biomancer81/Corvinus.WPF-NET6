using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corvinus.WPF.Common.Configuration
{
    public abstract class ApplicationConfigurationBase
    {
        public Guid ApplicationId { get; set; }

        public ApplicationConfigurationBase() 
        {
        }
    }
}
