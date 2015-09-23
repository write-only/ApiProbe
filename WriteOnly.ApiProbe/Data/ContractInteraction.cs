namespace WriteOnly.ApiProbe.Data
{
    public class ContractInteraction : Interaction
    {
        public string Description { get; set; }

        public long ID { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ContractInteraction) obj);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        private bool Equals(ContractInteraction other)
        {
            return ID == other.ID;
        }
    }
}