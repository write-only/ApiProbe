using eZet.EveLib.EveXmlModule;

namespace WriteOnly.ApiProbe.Data
{
    public class CharacterData : IdValuePair
    {
        public CorporationData Corporation { get; set; }

        public CharacterData(Character character)
        {
            Name = character.CharacterName;
            ID = character.CharacterId;
            Corporation = new CorporationData {Name = character.CorporationName, ID = character.CorporationId};
            Corporation.alliance = new AllianceData {Name = character.AllianceName, ID = character.AllianceId};
        }

        public CharacterData()
        {
        }
    }
}