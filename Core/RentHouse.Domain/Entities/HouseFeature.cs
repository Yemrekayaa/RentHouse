namespace RentHouse.Domain.Entities
{
    public class HouseFeature
    {
        public int HouseFeatureId { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
        public Feature Feature { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
    }
}
