using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetByHouse;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetWithFeaturesById
{
    public class GetHouseWithFeaturesByIdResponse
    {
        public int HouseID { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public List<GetHouseImagesByHouseResponse> HouseImages { get; set; }
        public List<GetHouseWithFeaturesByIdFeatureListResponse> HouseFeatures { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class GetHouseWithFeaturesByIdFeatureListResponse
    {
        public int HouseFeatureId { get; set; }
        public int HouseId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
