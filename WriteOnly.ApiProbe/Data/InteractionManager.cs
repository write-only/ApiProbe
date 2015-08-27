using System.Collections.Generic;
using System.Linq;

namespace WriteOnly.ApiProbe.Data
{
    public class InteractionManager
    {
        /// <summary>
        /// Contains all characters.
        /// </summary>
        public HashSet<CharacterData> Characters { get; set; }
        
        /// <summary>
        /// Contains Interactions of all characters.
        /// </summary>
        public HashSet<Interaction> Interactions { get; set; }
        
        
        public InteractionManager()
        {
            Characters = new HashSet<CharacterData>();
            Interactions = new HashSet<Interaction>();
        }

        /// <summary>
        /// Returns all <see cref="Interaction"/>s the given character is involved in.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>A List of <see cref="Interaction"/> objects containing the character.</returns>
        public List<Interaction> GetInteractions(CharacterData character)
        {
            List<Interaction> interactions = new List<Interaction>();
            
            interactions.AddRange(Interactions.Where(i => i.Involves(character)));

            return interactions;
        }

        /// <summary>
        /// Returns all <see cref="Interaction"/>s between two characters.
        /// </summary>
        /// <param name="firstCharacter">The first character.</param>
        /// <param name="secondCharacter">The second character.</param>
        /// <returns>A List of <see cref="Interaction"/> objects containing both characters.</returns>
        public List<Interaction> GetInteractions(CharacterData firstCharacter, CharacterData secondCharacter)
        {
            List<Interaction> interactions = new List<Interaction>();

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
