using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteOnly.ApiProbe.Data;

namespace WriteOnly.ApiProbe.ApiHandling
{
    public class WalletMapper : IMapper
    {
        public List<InteractionData> Interactions { get; set; }

        public WalletMapper()
        {
            Interactions = new List<InteractionData>();
        }

        public void DoWork()
        {
            
        }
    }
}
