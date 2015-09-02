namespace WriteOnly.ApiProbe.Data
{
    public abstract class IdValuePair
    {

        public string Name { get; set; }

        public long ID { get; set; }

        public override string ToString()
        {
            return Name;
        }

        protected bool Equals(IdValuePair other)
        {
            return ID == ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((IdValuePair)obj);
        }

        public override int GetHashCode()
        {
            return (ID.GetHashCode());
        }
    }
}