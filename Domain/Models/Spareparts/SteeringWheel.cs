using Domain.Models.Brands;

namespace Domain.Models.Spareparts
{
    public class SteeringWheel : Brand
    {
        public Guid SteeringWheelId { get; set; }
        public bool SteeringWheelHeater { get; set; }

        public int SteeringWheelSize { get; set; }

    }
}
