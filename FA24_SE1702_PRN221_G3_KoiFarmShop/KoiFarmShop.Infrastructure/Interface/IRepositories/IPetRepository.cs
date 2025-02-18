﻿using KoiFarmShop.Domain.Entities;

namespace KoiFarmShop.Infrastructure.Interface.IRepositories
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        public Task<Pet> GetPetByIdAsync(Guid id);
        public Task<IEnumerable<Pet>> GetAllPetAsync();
        public Task<Pet> CreatePetAsync(Pet pet);
        public Task<int> UpdatePetAsync(Pet pet);
        public Task<int> DeletePetAsync(Guid id);
        Task<List<Pet>> GetAllPetWithSearchAsync(string searchName, string searchColor, string searchNote);

        public Task<IEnumerable<Pet>> GetPetsByOwnerIdAsync(Guid ownerId);
    }
}
