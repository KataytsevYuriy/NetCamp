using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    internal class _4
    {
        public void Start()
        {
            List<(string Code, DateTime Birthday, string Street)> suppliert = new()
            {
                ("1", new DateTime(2002, 1, 1), "TRER"),
                ("2", new DateTime(2002, 1, 1), "fsaf"),
                ("3", new DateTime(2004, 1, 1), "TRER"),
                ("4", new DateTime(2004, 1, 1), "adsad"),
                ("5", new DateTime(2002, 1, 1), "TRfdfdER"),
                ("6", new DateTime(2002, 1, 1), "TRER"),
                ("7", new DateTime(2004, 1, 1), "TfdfRER"),
                ("8", new DateTime(2002, 1, 1), "TREgdsR"),
                ("9", new DateTime(2004, 1, 1), "TREwR"),
            };
            List<(string Code, string Storage, double Discount)> supplierDiscountList = new()
            {
                ("1", "T", 12),
                ("7", "T", 1),
                ("2", "J", 12),
                ("4", "J", 12),
                ("5", "Y", 12),
                ("9", "J", 12),
                ("5", "T", 13),
                ("8", "Y", 12),
                ("7", "J", 12),
                ("6", "T", 13),
                ("5", "J", 12),
                ("4", "O", 12),
            };
            List<(string Storage, double maxDiscount, string Code, DateTime Birthday, string Street)> maxDiscountOwner = new();
            foreach (var storage in supplierDiscountList.GroupBy(s => s.Storage).OrderBy(k=>k.Key).ToList())
            {
                string maxDiscountUserId = storage.OrderByDescending(s => s.Discount).ThenBy(d => d.Code).FirstOrDefault().Code;
                maxDiscountOwner.Add((
                    storage.Key,
                    storage.OrderByDescending(s=>s.Discount).ThenBy(c=>c.Code).FirstOrDefault().Discount,
                    maxDiscountUserId,
                    suppliert.FirstOrDefault(d=>d.Code== maxDiscountUserId).Birthday,
                    suppliert.FirstOrDefault(d=>d.Code== maxDiscountUserId).Street
                    ));
            }
            Console.WriteLine(4);
            foreach (var item in maxDiscountOwner) 
                Console.WriteLine($"name: {item.Storage},max discount: {item.maxDiscount}, userId: {item.Code}, user birthday: {item.Birthday.ToShortDateString()}, user address: {item.Street}");
        }
    }
}
