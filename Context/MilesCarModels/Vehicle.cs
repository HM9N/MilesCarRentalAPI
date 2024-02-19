using System;
using System.Collections.Generic;

namespace MilesCarRentalApi.Context.MilesCarModels;

public partial class Vehicle
{
    public int IdVehicle { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Type { get; set; }

    public string? Availability { get; set; }

    public int? IdLocation { get; set; }

    public virtual Location? IdLocationNavigation { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
