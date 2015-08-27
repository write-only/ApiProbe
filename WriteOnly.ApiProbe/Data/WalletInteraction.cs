namespace WriteOnly.ApiProbe.Data
{
    public abstract class WalletInteraction : Interaction
    {
        private decimal _amount;

        public long ID { get; set; }

        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value < 0 ? -value : value;
            }
        }

        protected bool Equals(WalletInteraction other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WalletInteraction) obj);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}