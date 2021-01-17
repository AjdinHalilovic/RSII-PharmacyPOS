using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Core.Entities.Base;
using Pharmacy.Infrastructure.Contexts.Base;
using Pharmacy.Infrastructure.Repositories.Base.IRepository;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Entities.Base.DTO;
using System.Collections.Generic;
using Pharmacy.Core.Models;
using Pharmacy.Core.Models.Billing;

namespace Pharmacy.Infrastructure.Repositories.Base.Repository
{
    public class BillsRepository : Repository<Bill, int>, IBillsRepository
    {
        public BillsRepository(PharmacyContext context) : base(context)
        {
        }

        public async Task<Bill> GetLastBill(int pharmacyBranchId)
        {
            return await Context.Bills.OrderByDescending(x => x.Number).FirstOrDefaultAsync(x => x.PharmacyBranchId == pharmacyBranchId);
        }

        public async Task<IEnumerable<BillDto>> GetAllDtosByParametersAsync(BillSearchObject search)
        {
            if (!search.ProductId.HasValue)
            {

                var query = Context.Bills.Include(x=>x.PharmacyBranch).Include(x => x.User).ThenInclude(x => x.Person).AsQueryable();

                if (search.PharmacyBranchId.HasValue)
                {
                    query = query.Where(x => x.PharmacyBranchId == search.PharmacyBranchId);
                }

                if (search.PharmacyId.HasValue)
                {
                    query = query.Where(x => x.PharmacyBranch.PharmacyId == search.PharmacyId);
                }

                if (search.UserId.HasValue)
                {
                    query = query.Where(x => x.AddUserId == search.UserId);
                }

                if (!string.IsNullOrWhiteSpace(search.SearchTerm))
                {
                    query = query.Where(x => x.Number.ToString().ToLower().Equals(search.SearchTerm.ToLower()));
                }

                if (search.DateFrom.HasValue)
                {
                    query = query.Where(x => x.CreatedDateTime >= search.DateFrom);
                }

                if (search.DateTo.HasValue)
                {
                    query = query.Where(x => x.CreatedDateTime <= search.DateTo);
                }


                query = query.Where(x => !x.DeletedDateTime.HasValue);

                var list = await query.Select(x => new BillDto()
                {
                    Id = x.Id,
                    CreatedDateTime = x.CreatedDateTime,
                    Number = x.Number.ToString(),
                    Total = x.Total.ToString(),
                    Amount = x.Total,
                    UserFullName = $"{x.User.Person.FirstName} {x.User.Person.LastName}"
                }).ToListAsync();

                return list;
            }
            else
            {
                var query = Context.BillItems.Include(x => x.Bill).ThenInclude(x=>x.User).AsQueryable();
                //var query = Context.Bills.Include(x => x.User).ThenInclude(x => x.Person).AsQueryable();

                if (search.PharmacyBranchId.HasValue)
                {
                    query = query.Where(x => x.Bill.PharmacyBranchId == search.PharmacyBranchId);
                }

                query = query.Where(x => x.ProductId == search.ProductId);

                if (!string.IsNullOrWhiteSpace(search.SearchTerm))
                {
                    query = query.Where(x => x.Bill.Number.ToString().ToLower().Equals(search.SearchTerm.ToLower()));
                }

                if (search.DateFrom.HasValue)
                {
                    query = query.Where(x => x.Bill.CreatedDateTime >= search.DateFrom);
                }

                if (search.DateTo.HasValue)
                {
                    query = query.Where(x => x.Bill.CreatedDateTime <= search.DateTo);
                }


                query = query.Where(x => !x.Bill.DeletedDateTime.HasValue);

                var list = await query.Select(x => new BillDto()
                {
                    Id = x.Bill.Id,
                    CreatedDateTime = x.Bill.CreatedDateTime,
                    Number = x.Bill.Number.ToString(),
                    Total = x.Total.ToString(),
                    Amount = x.Total,
                    UserFullName = $"{x.Bill.User.Person.FirstName} {x.Bill.User.Person.LastName}"
                }).ToListAsync();

                return list;
            }
        }


    }
}
