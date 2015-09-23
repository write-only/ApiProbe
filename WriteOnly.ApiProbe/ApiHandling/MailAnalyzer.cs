using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;
using WriteOnly.ApiProbe.Data;
using eZet.EveLib.EveXmlModule.Models.Character;

namespace WriteOnly.ApiProbe.ApiHandling
{
    class MailAnalyzer : IAnalyzer
    {
        public List<Character> Characters
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HashSet<Interaction> Interactions
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public MailAnalyzer(Character character)
        {
            Characters = new List<Character> { character };
            Interactions = new HashSet<Interaction>();
        }

        public MailAnalyzer(IEnumerable<Character> characters)
        {
            Characters = new List<Character>();
            Characters.AddRange(characters);
            Interactions = new HashSet<Interaction>();
        }

        public void DoWork()
        {
            foreach (Character c in Characters)
            {
                Interactions.UnionWith(GetInteractions(c));
            }
        }

        private List<Interaction> GetInteractions(Character character)
        {
            List<Interaction> interactions = new List<Interaction>();

            List<MailMessages.Message> personalMails = new List<MailMessages.Message>();

            interactions.AddRange(character.GetMailMessages().Result.Messages.Select(m => new MailInteraction
            {
                PrimaryCharacter = new CharacterData { Name = m.SenderName, ID = m.SenderId },
                SecondaryCharacter = new CharacterData { }
            }));

            return interactions;
        }

        private List<CharacterData> ToCharacters (string toID)
        {
            List<CharacterData> characters = new List<CharacterData>();

            return characters;
        }
    }
}
