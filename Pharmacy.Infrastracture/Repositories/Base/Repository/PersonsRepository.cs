﻿using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using Pharmacy.Core.Entities.Base.DTO;
using Pharmacy.Core.Models.Users;
using Pharmacy.Infrastracture;
using Pharmacy.Infrastracture.Helpers;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class PersonsRepository : Repository<Person, int>, IPersonsRepository
    {
        public PersonsRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PersonDto>> GetAllDtosAsync(PersonSearchObject search)
        {
            return await DbConnection.QueryFunctionAsync<PersonDto>(DbObjects.BaseDbObjects.Functions.Persons.persons_getdtosbyparameters, new { pFullName = search.FullName });
        }

    }
}
