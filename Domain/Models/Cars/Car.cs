using Domain.Models.Brands;
using Domain.Models.Spareparts;

namespace Domain.Models.Cars
{
    public class Car : Brand
    {
        public required SteeringWheel SteeringWheel { get; set; }
    }
}
