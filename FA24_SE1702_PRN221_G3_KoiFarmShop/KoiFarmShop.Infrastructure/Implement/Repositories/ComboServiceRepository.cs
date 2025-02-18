﻿using KoiFarmShop.Domain.Entities;
using KoiFarmShop.Infrastructure.DB;
using KoiFarmShop.Infrastructure.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Infrastructure.Implement.Repositories
{
    public class ComboServiceRepository : GenericRepository<ComboService>, IComboServiceRepository
    {
        public ComboServiceRepository(KVSCContext context) : base(context) { }
        public async Task<ComboService> CreateAsync(ComboService comboService)
        {
            _context.ComboServices.Add(comboService);
            await _context.SaveChangesAsync();
            return comboService;
        }
        public async Task<IEnumerable<ComboService>> GetAllComboAsync()
        {
            return await _context.ComboServices
                .Include(cs => cs.ComboServiceItems)
                .ThenInclude(csi => csi.PetService)
            .Where(cs => !cs.IsDeleted)
                .ToListAsync();
        }
        public async Task<ComboService> GetComboByIdAsync(Guid id)
        {
            return await _context.ComboServices
                .Include(cs => cs.ComboServiceItems)
                .ThenInclude(csi => csi.PetService)
                .FirstOrDefaultAsync(cs => cs.Id == id && !cs.IsDeleted);
        }

        // UPDATE
        public async Task<int> UpdateAsync(ComboService comboService)
        {
            _context.ComboServices.Update(comboService);
            return await _context.SaveChangesAsync();
        }

        // DELETE (soft delete)
        public async Task<int> DeleteAsync(Guid id)
        {
            var comboService = await _context.ComboServices.FindAsync(id);
            if (comboService != null)
            {
                comboService.IsDeleted = true;
                _context.ComboServices.Update(comboService);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
