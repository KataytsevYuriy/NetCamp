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
        public delegate void UserOut(Person user, Cassa cassa);
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
        public static void UserLeaves(Person user, Cassa cassa)
        {
            string message = $"Cassa_{cassa.Cordinate}: {user.Name} has been observed.";
            FileService.Save(Settings.ResultFileName, message);
        }
    }
}
