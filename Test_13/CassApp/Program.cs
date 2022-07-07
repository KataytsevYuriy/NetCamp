using CassApp.Services;

namespace CassApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonGenerator personGenerator = new PersonGenerator();
            personGenerator.Save(personGenerator.Genereate(50));
            CassaService.AddCassaStopTiming(40);
            CassaService.AddCassaLockUnlockTiming(60);
            CassaService.AddCassaChangeCategoryTiming(15, "warior");
            FileService.Save(Settings.ResultFileName, "", false);//Clear result file
            TimeCordinator timeCordinator = new TimeCordinator();

            timeCordinator.Cordinate(new List<Cassa>
            {
                new Cassa (22),
                new Cassa (11),
                new Cassa (0)
            });
            Console.ReadLine();

        }
    }
}