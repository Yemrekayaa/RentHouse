namespace RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetById
{
    public class GetHouseFeatureByIdResponse
    {
        public int HouseFeatureId { get; set; }
        public int HouseId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
