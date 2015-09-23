using System;
using System.Collections.Generic;
using System.Linq;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Character;
using WriteOnly.ApiProbe.Data;

namespace WriteOnly.ApiProbe.ApiHandling
{
    internal class MailAnalyzer : IAnalyzer
    {
        public List<Character> Characters { get; set; }

        public HashSet<Interaction> Interactions { get; set; }

        public MailAnalyzer(Character character)
        {
            Characters = new List<Character> {character};
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

            foreach (MailMessages.Message message in character.GetMailMessages().Result.Messages)
            {
                if (message.SenderId.Equals(character.CharacterId))
                {
                    interactions.AddRange(ToCharacters(message.ToCharacterIds).Select(c => new MailInteraction
                    {
                        PrimaryCharacter = new CharacterData(character),
                        SecondaryCharacter = c,
                        Subject = message.Title,
                        Body = GetBody(message),
                        Time = message.SentDate
                    }));
                }
                else
                {
                    interactions.Add(new MailInteraction
                    {
                        PrimaryCharacter = new CharacterData {ID = message.SenderId, Name = message.SenderName},
                        SecondaryCharacter = new CharacterData(character),
                        Subject = message.Title,
                        Body = GetBody(message),
                        Time = message.SentDate
                    });
                }
            }
            return interactions;
        }

        private string GetBody(MailMessages.Message message)
        {
            throw new NotImplementedException();
        }

        private List<CharacterData> ToCharacters(string toID)
        {
            List<CharacterData> characters = new List<CharacterData>();

            return characters;
        }
    }
}
