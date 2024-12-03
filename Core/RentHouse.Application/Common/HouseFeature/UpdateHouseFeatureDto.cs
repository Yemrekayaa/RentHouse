namespace RentHouse.Application.Common.HouseFeature
{
    public class UpdateHouseFeatureDto
    {
        public int HouseFeatureId { get; set; }
        public int HouseId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
    }
}
