namespace Models.RequestModels
{
    public class FleetPoolSearchRequest:GetPagedListRequest
    {
        public string FleetPoolCode { get; set; }
        public string FleetPoolName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Operation { get; set; }

    }
}
