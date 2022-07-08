using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Services
{
    internal class CassaService
    {
        public delegate void ChengeCassaDelegate(int time, ref List<Cassa> casses);
        private static List<int> stopList = new();
        private static List<int> lockList = new();
        private static Dictionary<int, List<int>> changeList = new();
        public static void Close(int time, ref List<Cassa> casses)
        {
            if (stopList.Count > 0 && stopList.Contains(time))
            {
                Random random = new Random();
                int pos = random.Next(casses.Count);
                DistributePersons(casses[pos].Close(), ref casses, casses[pos].Cordinate);
            }
        }
        public static void LockUnlock(int time, ref List<Cassa> casses)
        {
            if (lockList.Count > 0 && lockList.Contains(time))
            {
                Random random = new Random();
                int pos = random.Next(casses.Count);
                if (casses[pos].IsLock)
                {
                    casses[pos].UnLock();
                }
                else
                {
                    casses[pos].Close();
                }
            }
        }
        public static void ChangeCategorys(int time, ref List<Cassa> casses)
        {
            if (changeList.Count > 0 && changeList.ContainsKey(time))
            {
                List<int> newCategories = new();
                if (!changeList.TryGetValue(time, out newCategories)) return;
                Random random = new Random();
                int pos = random.Next(casses.Count);
                DistributePersons(casses[pos].ChangeCategory(newCategories), ref casses, casses[pos].Cordinate);
            }
        }
        public static void AddCassaStopTiming(int timming)
        {
            stopList.Add(timming);
        }
        public static void AddCassaLockUnlockTiming(int timming)
        {
            lockList.Add(timming);
        }
        public static void AddCassaChangeCategoryTiming(int timming, string category)
        {
            if (!Settings.Status.ContainsValue(category)) return;
            List<int> categories = new();
            if (changeList.ContainsKey(timming))
            {
                categories = changeList[timming];
            }
            int categoryInt = Settings.Status.First(x => x.Value == category).Key;
            if (categories.Contains(categoryInt))
            {
                categories.Remove(categoryInt);
            }
            else
            {
                categories.Add(categoryInt);
            }
            changeList[timming]=categories;
        }
        public static void DistributePersons(List<Person> people, ref List<Cassa> casses, int position)
        {
            foreach (Person person in people)
            {
                UserService.UserEnter(position, person, ref casses);
            }
        }
    }
}
