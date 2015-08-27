namespace WriteOnly.ApiProbe.Data
{
    public class CharacterData
    {

        public string Name { get; set; }

        public string ID { get; set; }

        public override string ToString()
        {
            return Name;
        }

        protected bool Equals(CharacterData other)
        {
            return string.Equals(ID, other.ID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CharacterData) obj);
        }

        public override int GetHashCode()
        {
            return (ID != null ? ID.GetHashCode() : 0);
        }
    }
}
