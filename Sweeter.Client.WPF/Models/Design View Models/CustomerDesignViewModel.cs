namespace Sweeter.Client.WPF
{
	public class CustomerDesignViewModel: Contact
    {
        public static CustomerDesignViewModel Instance => Instance ?? new CustomerDesignViewModel();
    }
}
