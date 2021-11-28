using drones_api.Data;
using drones_api.Dtos.Request;
using drones_api.Dtos.Response;
using drones_api.Models;
using drones_api.Paging;
using drones_api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class MedicationRepository : RepositoryBase<Medication>, IMedicationRepository
    {
        public MedicationRepository(DronesApiContext context) : base(context) { }

        public async Task<PagedList<MedicationResponseDto>> GetMedicationPagedAsync(MedicationParameters droneStateParameters, bool trackChanges)
        {
            var query = FindAll(trackChanges)
                .Include(m => m.DroneItems)
                .AsQueryable();

            if (!string.IsNullOrEmpty(droneStateParameters.OrderBy))
            {
                query = droneStateParameters.OrderBy.ToLower() switch
                {
                    "medicationid" => droneStateParameters.DescendingOrder ? query.OrderByDescending(m => m.MedicationId) : query.OrderBy(m => m.MedicationId),
                    "name" => droneStateParameters.DescendingOrder ? query.OrderByDescending(m => m.Name) : query.OrderBy(m => m.Name),
                    "createdat" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.CreatedAt) : query.OrderBy(d => d.CreatedAt),
                    "updatedat" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.UpdatedAt) : query.OrderBy(d => d.UpdatedAt),
                    "code" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.Code) : query.OrderBy(d => d.Code),
                    _ => query
                };
            }

            if (!string.IsNullOrEmpty(droneStateParameters.SearchTerm))
            {
                var lowerCaseTerm = droneStateParameters.SearchTerm.Trim().ToLower();

                query = query.Where(d => d.Code.ToLower().Contains(lowerCaseTerm) || d.Name.ToLower().Contains(lowerCaseTerm));
            }

            var medications = await query.Select( m => new MedicationResponseDto() {
                MedicationId = m.MedicationId,
                Code = m.Code,
                Image = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(m.Image)),
                Name = m.Name,
                Weight = m.Weight,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt,
                DroneItems = m.DroneItems
            }).ToListAsync();

            return PagedList<MedicationResponseDto>
                .ToPagedList(medications, droneStateParameters.PageNumber, droneStateParameters.PageSize);
        }
        public MedicationResponseDto AddMedication(Medication medication)
        {
            var m = Add(medication);
            return new MedicationResponseDto()
            {
                MedicationId = m.MedicationId,
                Code = m.Code,
                Image = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(m.Image)),
                Name = m.Name,
                Weight = m.Weight,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt,
                DroneItems = m.DroneItems
            };
        }

        public async Task<bool> CheckMedicationExists(Guid medicationId)
        {
            var exists = await CheckExists(m => m.MedicationId == medicationId);
            return exists;
        }

        public async Task<MedicationResponseDto> GetMedicationAsync(Guid medicationId, bool trackChanges)
        {
            var medication = await FindByCondition(d => d.MedicationId == medicationId, trackChanges: trackChanges)
                .Select(m => new MedicationResponseDto()
                {
                    MedicationId = m.MedicationId,
                    Code = m.Code,
                    Image = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(m.Image)),
                    Name = m.Name,
                    Weight = m.Weight,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    DroneItems = m.DroneItems
                })
                .FirstOrDefaultAsync();
            return medication;
            
        }

        public async Task<Medication> GetMedication(Guid medicationId, bool trackChanges)
        {
            var medication = await FindByCondition(d => d.MedicationId == medicationId, trackChanges: trackChanges)
                .FirstOrDefaultAsync();
            return medication;

        }

        public bool UpdateMedication(Medication medication)
        {
            Update(medication);
            return SaveChanges();
        }
        public bool DeleteMedication(Medication medication)
        {
            Delete(medication);
            return SaveChanges();
        }

    }
}
