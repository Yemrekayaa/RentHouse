namespace RentHouse.Application.Common.HouseFeature
{
    public class CreateHouseFeatureDto
    {
        public int HouseId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
    }
}
