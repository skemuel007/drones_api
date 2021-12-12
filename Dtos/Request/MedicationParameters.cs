using drones_api.Paging;

namespace drones_api.Dtos.Request
{
    public class MedicationParameters : RequestParams
    {
        public string SearchTerm { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
