using System.Collections.Generic;
using System.Linq;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models.Character;
using WriteOnly.ApiProbe.Data;

namespace WriteOnly.ApiProbe.ApiHandling
{
    public class WalletAnalyzer : IAnalyzer
    {
        public List<Character> Characters { get; set; }

        public HashSet<Interaction> Interactions { get; set; }

        public WalletAnalyzer(Character character)
        {
            Characters = new List<Character> {character};
            Interactions = new HashSet<Interaction>();
        }

        public WalletAnalyzer(IEnumerable<Character> characters)
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

            WalletJournal tempJournal = character.GetWalletJournal(2560, 0L).Result;
            int entries = tempJournal.Journal.Count;
            while (entries > 0)
            {
                
                long id = tempJournal.Journal.Min(x => x.RefId);

                // WalletJournal TypeIDs:
                // 10: Player Donation
                // 37: Corp Account Withdrawal
                // 1:  Direct Trade
                interactions.AddRange(GetEntriesById(tempJournal, 10).Select(j => new DonationInteraction
                {
                    Amount = j.Amount,
                    Time = j.Date,
                    Reason = j.Reason,
                    PrimaryCharacter = new CharacterData {Name = j.OwnerName, ID = j.OwnerId},
                    SecondaryCharacter = new CharacterData {Name = j.ParticipantName, ID = j.ParticipantId},
                    ID = j.RefId
                }));

                interactions.AddRange(GetEntriesById(tempJournal, 37).Select(j => new CorpDonationInteraction
                {
                    Amount = j.Amount,
                    Time = j.Date,
                    Reason = j.Reason,
                    PrimaryCharacter = new CharacterData {Name = j.OwnerName, ID = j.OwnerId},
                    SecondaryCharacter = new CharacterData {Name = j.ArgumentName, ID = j.ArgumentId},
                    Corporation = new CorporationData {Name = j.ParticipantName, ID = j.ParticipantId},
                    ID = j.RefId
                }));

                interactions.AddRange(GetEntriesById(tempJournal, 1).Select(j => new TradeInteraction
                {
                    Amount = j.Amount,
                    Time = j.Date,
                    PrimaryCharacter = new CharacterData {Name = j.OwnerName, ID = j.OwnerId},
                    SecondaryCharacter = new CharacterData {Name = j.ParticipantName, ID = j.ParticipantId},
                    Location = new StationData {Name = j.ArgumentName, ID = j.ArgumentId},
                    ID = j.RefId
                }));

                tempJournal = character.GetWalletJournal(2560, id).Result;
                entries = tempJournal.Journal.Count;
            }
            return interactions;
        }

        private List<WalletJournal.JournalEntry> GetEntriesById(WalletJournal journal, int id)
        {
            List<WalletJournal.JournalEntry> entries = new List<WalletJournal.JournalEntry>();
            entries.AddRange(journal.Journal.Where(c => c.RefTypeId == id));
            return entries;
        }
    }
}
