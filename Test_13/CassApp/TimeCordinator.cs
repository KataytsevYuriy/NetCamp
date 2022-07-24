using CassApp.Data;
using CassApp.Services;
using Task12_3;

namespace CassApp
{
    internal class TimeCordinator
    {
        int timeCounter = Settings.PersonTimeToIn;
        public event UserService.UserIn UserEnterToCasses;
        public event UserService.UserOut UserLivesCassa;
        public event CassaService.ChengeCassaDelegate TryChangeCassa;

        public void Cordinate(List<Cassa> casses)
        {
            Random random = new Random();
            bool isProcess = true;
            int counter = 0;
            int time = 0;
            PersonGenerator pGen = new PersonGenerator();
            List<Person> persons = new();
            bool endOfFile = false;
            while (isProcess)
            {
                if (!endOfFile && counter==persons.Count)
                {
                    try
                    {
                        persons = pGen.LoadPart(Settings.PersonsFileName);
                        if (persons.Count == 0) endOfFile = true;
                        counter = 0;
                    }
                    catch (Exception ex) { PrintService.PrintAllert(ex.Message); }
                }
                time++;
                if (time % timeCounter == 0 && counter < persons.Count)
                {
                    PrintService.Print($"{persons[counter]}");
                    UserEnterToCasses(random.Next(0, casses.Count), persons[counter++], ref casses);
                }
                int number = 0;
                foreach (var item in casses)
                {
                    if (!item.IsEmpty && --item.Peek().TimeServise <= 0)
                    {
                        string message = $"Cassa_{++number}: {item.Dequeue()} has been observed. Time:{time}";
                        UserLivesCassa(message);
                    }
                    Thread.Sleep(100);
                }
                if (casses.Any(c => !c.IsOpen))
                {
                    List<Cassa> closedCasses = casses.Where(c => !c.IsOpen && c.IsEmpty).ToList();
                    if (closedCasses.Count > 0)
                        foreach (Cassa item in closedCasses) casses.Remove(item);
                }
                TryChangeCassa(time, ref casses);
            }
        }
    }
}
