namespace RentHouse.Dto.HouseFeatureDtos
{
    public class ResultHouseFeatureDto
    {
        public int HouseFeatureId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
