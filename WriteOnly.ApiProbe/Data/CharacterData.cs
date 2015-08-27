using eZet.EveLib.EveXmlModule;

namespace WriteOnly.ApiProbe.Data
{
    public class CharacterData : IdValuePair
    {
        public CorporationData corporation { get; set; }

        public CharacterData(Character character)
        {
            Name = character.CharacterName;
            ID = character.CharacterId;
            corporation = new CorporationData {Name = character.CorporationName, ID = character.CorporationId};
            corporation.alliance = new AllianceData {Name = character.AllianceName, ID = character.AllianceId};
        }

        public CharacterData()
        {
        }
    }
}