using Domain.Models.Brands;
using Domain.Models.Spareparts;

namespace Domain.Models.Cars
{
    public class Car : Brand
    {
        public required Sparepart Sparepart { get; set; }
    }
}
