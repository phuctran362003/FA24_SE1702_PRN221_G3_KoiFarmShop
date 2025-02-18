﻿using KoiFarmShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Infrastructure.Interface.IRepositories
{
    public interface IPetServiceCategoryRepository : IGenericRepository<PetServiceCategory>
    {

        public Task<PetServiceCategory> CreateAsync(PetServiceCategory category);
        public Task<int> DeleteAsync(Guid id);

    }
}
