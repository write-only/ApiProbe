using System.Collections.Generic;
using eZet.EveLib.EveXmlModule;
using WriteOnly.ApiProbe.Data;

namespace WriteOnly.ApiProbe.ApiHandling
{
    public interface IAnalyzer
    {
        List<Character> Characters { get; set; }

        HashSet<Interaction> Interactions { get; set; }

        void DoWork();
    }
}
