namespace WriteOnly.ApiProbe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CharacterItem bear = new CharacterItem("Care Bear");
            CharacterItem spy = new CharacterItem("Spy McAwox");
            CharacterItem gorth = new CharacterItem() { Name = "Gorth Tolkien"};
            gorth.Items.Add(new DonationItem() {Amount = (decimal) 133400.23, HasInitiated = true, Peer = bear});
            gorth.Items.Add(new ContractItem() {Amount = 1, HasInitiated = false, Peer = bear});
            gorth.Items.Add(new MailItem() {Subject = "Shooting Blues", HasInitiated = false, Peer = spy, Body = "Let's go shoot blues everyday!"});
            TreeView.Items.Add(gorth);

        }
    }
}
