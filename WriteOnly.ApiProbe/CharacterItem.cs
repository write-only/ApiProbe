using System.Collections.ObjectModel;

namespace WriteOnly.ApiProbe
{
    public class CharacterItem
    {
        public CharacterItem()
        {
            this.Items = new ObservableCollection<InteractionItem>();
        }

        public CharacterItem(string name)
        {
            this.Items = new ObservableCollection<InteractionItem>();
            Name = name;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public ObservableCollection<InteractionItem> Items { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}