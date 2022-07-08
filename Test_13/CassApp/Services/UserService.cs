using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Services
{
    internal class UserService
    {
        public delegate void UserIn(int position, Person user, ref List<Cassa> casses);
        public delegate void UserOut(string message);
        public static void UserEnter(int position, Person user, ref List<Cassa> casses)
        {
            int bestPos = SelectBestCassa(position, user, ref casses);
            casses[bestPos].Enqueue(user);
        }
        private static int SelectBestCassa(int position, Person person, ref List<Cassa> casses)
        {
            List<Cassa> listCasses = casses.Where(c => c.IsAllowed(person)).ToList();
            int minPerson = listCasses.Min(c => c.QueueCount);
            Cassa? bestCassa = listCasses.Where(c => c.QueueCount == minPerson)
                .MinBy(c => Math.Abs(c.Cordinate - person.Coordinate));
            if (bestCassa == null) return position;
            return casses.IndexOf(bestCassa);
        }
        public static void UserLeaves(string message)
        {
            FileService.Save(Settings.ResultFileName, message);
        }
    }
}
