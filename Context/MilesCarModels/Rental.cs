using System;
using System.Collections.Generic;

namespace MilesCarRentalApi.Context.MilesCarModels;

public partial class Rental
{
    public int IdRental { get; set; }

    public int IdClient { get; set; }

    public int IdVehicle { get; set; }

    public int IdPickupLocation { get; set; }

    public int IdReturnLocation { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Location? IdPickupLocationNavigation { get; set; } 

    public virtual Location? IdReturnLocationNavigation { get; set; } 

    public virtual Vehicle? IdVehicleNavigation { get; set; }
}
