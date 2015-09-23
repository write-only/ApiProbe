using System;

namespace WriteOnly.ApiProbe.Data
{
    public abstract class Interaction
    {
        public double InteractionStrength { get; set; }

        public CharacterData PrimaryCharacter { get; set; }

        public CharacterData SecondaryCharacter { get; set; }

        public DateTime Time { get; set; }

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();

        public bool Involves(CharacterData character)
        {
            return Equals(character, PrimaryCharacter) || Equals(character, SecondaryCharacter);
        }

        public bool IsBetween(CharacterData firstCharacter, CharacterData secondCharacter)
        {
            return Equals(PrimaryCharacter, firstCharacter) && Equals(SecondaryCharacter, secondCharacter) ||
                   Equals(PrimaryCharacter, secondCharacter) && Equals(SecondaryCharacter, firstCharacter);
        }
    }
}