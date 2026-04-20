using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace fast_flights.Presentation.Views;

public partial class FlightsPage : ContentPage
{
    public ObservableCollection<FlightViewModel> Flights { get; } = new();

    public FlightsPage()
    {
        InitializeComponent();
        BindingContext = this;
        GenerateMockData();
    }

    private void GenerateMockData()
    {
        Flights.Clear();
        var random = new Random();

        string[] airlines = ["SkyAir", "GlobalFly", "OceanWings", "StarJet", "SunsetAir"];
        string[] departureCities = ["Jakarta", "Bali", "Bangkok", "Singapore", "Kuala Lumpur"];
        string[] arrivalCities = ["Tokyo", "Seoul", "Beijing", "Shanghai", "Osaka"];

        for (int i = 0; i < 10; i++)
        {
            var flight = new FlightViewModel
            {
                Airline = airlines[random.Next(airlines.Length)],
                DepartureCity = departureCities[random.Next(departureCities.Length)],
                ArrivalCity = arrivalCities[random.Next(arrivalCities.Length)],
                DepartureTime = DateTime.Now.Date.AddHours(6).AddMinutes(random.Next(0, 1440)), // Random time today
                ArrivalTime = DateTime.Now.Date.AddHours(6).AddMinutes(random.Next(0, 1440)).AddHours(random.Next(2, 12)), // 2-12 hours later
                Duration = TimeSpan.FromHours(random.Next(2, 12)),
                Price = random.Next(200, 1500),
                Stops = random.Next(0, 3),
                FlightNumber = $"{airlines[random.Next(airlines.Length)][..2].ToUpper()}{random.Next(100, 999)}"
            };

            Flights.Add(flight);
        }
    }
}

public partial class FlightViewModel : ObservableObject
{
    [ObservableProperty]
    private string airline;

    [ObservableProperty]
    private string departureCity;

    [ObservableProperty]
    private string arrivalCity;

    [ObservableProperty]
    private DateTime departureTime;

    [ObservableProperty]
    private DateTime arrivalTime;

    [ObservableProperty]
    private TimeSpan duration;

    [ObservableProperty]
    private int price;

    [ObservableProperty]
    private int stops;

    [ObservableProperty]
    private string flightNumber;
}