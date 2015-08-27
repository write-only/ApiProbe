using System.Collections.ObjectModel;
using WriteOnly.ApiProbe.Data;

namespace WriteOnly.ApiProbe.UI
{
    public class CharacterItem
    {

        public string Name { get; set; }

        public string ID { get; set; }

        public ObservableCollection<InteractionItem> Items { get; set; }

        public CharacterItem()
        {
            this.Items = new ObservableCollection<InteractionItem>();
        }

        public CharacterItem(string name, string id)
        {
            ID = id;
            Name = name;
            Items = new ObservableCollection<InteractionItem>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}