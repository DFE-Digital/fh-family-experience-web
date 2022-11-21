namespace fh_family_experience_web.ViewModels
{
    public class FamilyHubViewModel
    {
        public string Name { get; set; } = "";
        public double Distance { get; set; } = 0.0;
        public string Address1 { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string City { get; set; } = "";
        public string StateProvince { get; set; } = "";
        public string Postcode { get; set; } = "";
        public string Email { get; set; } = "";
        public string HubUrl { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string DisplayDistance { 
            get {
                return Distance.ToString("F2");
            } 
        }
    }
}
