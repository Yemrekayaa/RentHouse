namespace RentHouse.Domain.Entities
{
    public class Setting
    {
        public int SettingID { get; set; }
        public int BannerID { get; set; }
        public Banner Banner { get; set; }
    }
}
