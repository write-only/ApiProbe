namespace WriteOnly.ApiProbe.Data
{
    public class MailInteraction : Interaction
    {
        public string Body { get; set; }

        public string Subject { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MailInteraction) obj);
        }

        public override int GetHashCode()
        {
            return Subject.GetHashCode() + Body.GetHashCode() + PrimaryCharacter.GetHashCode() + Time.GetHashCode();
        }

        private bool Equals(MailInteraction other)
        {
            return GetHashCode().Equals(other.GetHashCode());
        }
    }
}