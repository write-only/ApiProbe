using System.Collections.Generic;
using System.Linq;

namespace WriteOnly.ApiProbe.Data
{
    public class InteractionDataManager
    {
        /// <summary>
        /// Contains all characters.
        /// </summary>
        public List<CharacterData> Characters { get; set; }
        
        /// <summary>
        /// Contains Interactions of all characters.
        /// </summary>
        public List<InteractionData> Interactions { get; set; }
        
        
        public InteractionDataManager()
        {
            Characters = new List<CharacterData>();
            Interactions = new List<InteractionData>();
        }

        /// <summary>
        /// Returns all <see cref="InteractionData"/>s the given character is involved in.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>A List of <see cref="InteractionData"/> objects containing the character.</returns>
        public List<InteractionData> GetInteractions(CharacterData character)
        {
            List<InteractionData> interactions = new List<InteractionData>();
            
            interactions.AddRange(Interactions.Where(i => i.Involves(character)));

            return interactions;
        }

        /// <summary>
        /// Returns all <see cref="InteractionData"/>s between two characters.
        /// </summary>
        /// <param name="firstCharacter">The first character.</param>
        /// <param name="secondCharacter">The second character.</param>
        /// <returns>A List of <see cref="InteractionData"/> objects containing both characters.</returns>
        public List<InteractionData> GetInteractions(CharacterData firstCharacter, CharacterData secondCharacter)
        {
            List<InteractionData> interactions = new List<InteractionData>();

            interactions.AddRange(Interactions.Where(i => i.IsBetween(firstCharacter, secondCharacter)));

            return interactions;
        }

        /// <summary>
        /// Returns the interaction strenght between two characters.
        /// </summary>
        /// <param name="firstCharacter">The first character.</param>
        /// <param name="secondCharacter">The second character.</param>
        /// <returns>Sum of all interaction strenghts of the Interactions between the characters.</returns>
        public double GetInteractionStrenght(CharacterData firstCharacter, CharacterData secondCharacter)
        {
            // Sum up all interaction strength values
            return GetInteractions(firstCharacter, secondCharacter).Sum(x => x.InteractionStrength);
        } 
    }
}
