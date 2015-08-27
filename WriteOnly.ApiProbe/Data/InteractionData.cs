﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eZet.EveLib.EveXmlModule;

namespace WriteOnly.ApiProbe.Data
{
    public abstract class InteractionData
    {
        public DateTime Time { get; set; }

        public Character PrimaryCharacter { get; set; }

        public Character SecondaryCharacter { get; set; }

        public double InteractionStrength { get; set; }

        public bool IsBetween(Character firstCharacter, Character secondCharacter)
        {
            return Equals(PrimaryCharacter, firstCharacter) && Equals(SecondaryCharacter, secondCharacter) ||
                   Equals(PrimaryCharacter, secondCharacter) && Equals(SecondaryCharacter, firstCharacter);
        }

        public bool Involves(Character character)
        {
            return Equals(character, PrimaryCharacter) || Equals(character, SecondaryCharacter);
        }
    }
}
