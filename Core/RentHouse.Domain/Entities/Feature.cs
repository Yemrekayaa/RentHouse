namespace RentHouse.Domain.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public List<HouseFeature> HouseFeatures { get; set; }
    }
}
