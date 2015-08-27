namespace WriteOnly.ApiProbe.Data
{
    public class DonationInteraction : Interaction
    {
        public decimal Amount { get; set; }

        public string Reason { get; set; }
    }
}