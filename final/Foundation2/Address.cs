public class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public string Street { get => street; }
    public string City { get => city; }
    public string StateOrProvince { get => stateOrProvince; }
    public string Country { get => country; }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}