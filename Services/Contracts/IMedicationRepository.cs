using drones_api.Dtos.Request;
using drones_api.Dtos.Response;
using drones_api.Models;
using drones_api.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IMedicationRepository
    {
        Task<PagedList<MedicationResponseDto>> GetMedicationPagedAsync(MedicationParameters droneStateParameters, bool trackChanges);
        MedicationResponseDto AddMedication(Medication medication);
        Task<bool> CheckMedicationExists(Guid medicationId);
        Task<MedicationResponseDto> GetMedicationAsync(Guid medicationId, bool trackChanges);
        Task<Medication> GetMedication(Guid medicationId, bool trackChanges);
        bool UpdateMedication(Medication medication);
        bool DeleteMedication(Medication medication);
    }
}
