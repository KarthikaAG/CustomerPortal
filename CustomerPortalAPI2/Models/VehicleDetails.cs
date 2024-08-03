namespace CustomerPortalAPI2.Models
{
    public class VehicleDetails
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public int RTOId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int VariantId { get; set; }
        public int BodyTypeId { get; set; }
        public int TransmissionTypeId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string Color { get; set; }
        public string ChasisNumber { get; set; }
        public string EngineNumber { get; set; }
        public int CubicCapacity { get; set; }
        public int SeatingCapacity { get; set; }
        public int YearOfManufacture { get; set; }
        public decimal IDV { get; set; }
        public decimal ExShowroomPrice { get; set; }
    }
}