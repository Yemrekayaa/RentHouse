namespace RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetByHouseId
{
    public class GetHouseFeatureByHouseIdResponse
    {
        public int HouseFeatureId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
