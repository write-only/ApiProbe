using System.Collections.Generic;
using System.Linq;

namespace WriteOnly.ApiProbe.Data
{
    class InteractionDataManager
    {
        /// <summary>
        /// Contains all Characters.
        /// </summary>
        public List<Character> Characters { get; set; }
        
        /// <summary>
        /// Contains Interactions of all Characters.
        /// </summary>
        public List<Interaction> Interactions { get; set; }

        private static readonly InteractionDataManager _instance = new InteractionDataManager();

        public static InteractionDataManager Instance
        {
            get
            {
                return _instance;
            }
        }
        
        private InteractionDataManager()
        {
            Characters = new List<Character>();
            Interactions = new List<Interaction>();
        }

        /// <summary>
        /// Returns all <see cref="Interaction"/>s the given character is involved in.
        /// </summary>
        /// <param name="character">The Character.</param>
        /// <returns>A List of <see cref="Interaction"/> objects containing the character.</returns>
        public List<Interaction> GetInteractions(Character character)
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
        public List<Interaction> GetInteractions(Character firstCharacter, Character secondCharacter)
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
        public double GetInteractionStrenght(Character firstCharacter, Character secondCharacter)
        {
            // Sum up all interaction strength values
            return GetInteractions(firstCharacter, secondCharacter).Sum(x => x.InteractionStrength);
        } 
    }
}
