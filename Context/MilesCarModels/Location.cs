using System;
using System.Collections.Generic;

namespace MilesCarRentalApi.Context.MilesCarModels;

public partial class Location
{
    public int IdLocation { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Rental> RentalIdPickupLocationNavigations { get; set; } = new List<Rental>();

    public virtual ICollection<Rental> RentalIdReturnLocationNavigations { get; set; } = new List<Rental>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
