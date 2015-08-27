using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteOnly.ApiProbe.Data
{
    public abstract class InteractionData
    {
        public DateTime Time { get; set; }

        public CharacterData PrimaryCharacter { get; set; }

        public CharacterData SecondaryCharacter { get; set; }

        public double InteractionStrength { get; set; }

        public bool IsBetween(CharacterData firstCharacter, CharacterData secondCharacter)
        {
            return Equals(PrimaryCharacter, firstCharacter) && Equals(SecondaryCharacter, secondCharacter) ||
                   Equals(PrimaryCharacter, secondCharacter) && Equals(SecondaryCharacter, firstCharacter);
        }

        public bool Involves(CharacterData character)
        {
            return Equals(character, PrimaryCharacter) || Equals(character, SecondaryCharacter);
        }
    }
}
