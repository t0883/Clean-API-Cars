using Domain.Models.Brands;

namespace Domain.Models.Spareparts
{
    public class SteeringWheel
    {
        public Guid SteeringWheelId { get; set; }
        public bool SteeringWheelHeater { get; set; }

        public Brand Brand { get; set; }

        public int SteeringWheelSize { get; set; }

    }
}
