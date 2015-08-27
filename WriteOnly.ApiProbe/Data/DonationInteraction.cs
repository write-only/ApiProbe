namespace WriteOnly.ApiProbe.Data
{
    public class DonationInteraction : InteractionData
    {
        public decimal Amount { get; set; }

        public string Reason { get; set; }
    }
}