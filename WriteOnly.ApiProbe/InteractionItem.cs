using System;
using System.Collections.ObjectModel;

namespace WriteOnly.ApiProbe
{
    public class InteractionItem
    {
        public InteractionItem()
        {
            this.Items = new ObservableCollection<InteractionItem>();
        }

        public ObservableCollection<InteractionItem> Items { get; set; }

        public bool HasInitiated { get; set; }

        public CharacterItem Peer { get; set; }

        public string Direction
        {
            get
            {
                if (HasInitiated)
                {
                    return "to";
                }
                else
                {
                    return "from";
                }
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}