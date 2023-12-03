namespace Sweeter
{
	public class Address : ValueObject
	{
		#region Public Properties

		public string Street { get; private set; }
		public string Number { get; private set; }
		public string Addition { get; private set; }
		public string City { get; private set; }
		public string State { get; private set; }
		public string Country { get; private set; }
		public string ZipCode { get; private set; }

		#endregion

		public Address() { }

		public Address(string street, string number, string addition, string city, string state, string country, string zipcode)
		{
			Street = street;
			City = city;
			State = state;
			Country = country;
			ZipCode = zipcode;
			Number = number;
			Addition = addition;
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Street;
			yield return Number;
			yield return Addition;
			yield return City;
			yield return State;
			yield return Country;
			yield return ZipCode;
		}

	}
}
