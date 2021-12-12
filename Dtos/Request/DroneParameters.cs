using drones_api.Paging;

namespace drones_api.Dtos.Request
{
    public class DroneParameters : RequestParams
    {
        public DroneParameters()
        {
            OrderBy = "name";
        }
        public string Filter { get; set; }
        public string SearchTerm { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
