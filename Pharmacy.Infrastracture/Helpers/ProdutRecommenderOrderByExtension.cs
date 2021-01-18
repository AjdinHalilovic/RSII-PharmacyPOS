using Pharmacy.Core.Entities.Base;
using Pharmacy.Core.Entities.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Pharmacy.Infrastracture.Helpers
{
    public static class ProdutRecommenderOrderByExtension
    {
        public static IEnumerable<ProductDto> RecomendedOrderProducts(this IEnumerable<ProductDto> products,
                    IEnumerable<BillItem> billItems, int relatedProductId)
        {
            //productId, relationValue
            List<KeyValuePair<int, double>> productRelations = new List<KeyValuePair<int, double>>();

            var relatedBillItems = billItems.Where(x => x.ProductId == relatedProductId);
            var otheerBillItems = billItems.Where(x => x.ProductId != relatedProductId);


            foreach (var productBillItems in otheerBillItems.GroupBy(x => x.ProductId))
            {

                double numerator = 0;
                foreach (var billProducts in otheerBillItems.GroupBy(x => x.BillId))
                {
                    numerator += (double)((billProducts.FirstOrDefault(x => x.ProductId == productBillItems.Key)?.Total ?? 0) *
                        relatedBillItems.FirstOrDefault(x => x.BillId == billProducts.Key).Total);
                }
                double denominatorFirst = Math.Sqrt(productBillItems.Sum(x => Math.Pow((double)x.Total, 2)));
                double denominatorSecond = Math.Sqrt(relatedBillItems.Sum(x => Math.Pow((double)x.Total, 2)));

                double relation = numerator / (denominatorFirst * denominatorSecond);

                productRelations.Add(new KeyValuePair<int, double>(productBillItems.Key, relation));
            }
            productRelations.OrderByDescending(x => x.Value);
            var productRelationIds = productRelations.Select(y => y.Key).ToList();
            productRelationIds.Insert(0, relatedProductId);

            products.ToList().ForEach(x => x.OrderNumber = productRelationIds.IndexOf(x.Id));

            return products.OrderBy(x => x.OrderNumber).ToList();
        }
    }
}
