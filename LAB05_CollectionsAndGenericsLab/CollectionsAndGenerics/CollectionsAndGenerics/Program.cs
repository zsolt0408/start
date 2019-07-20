using System;
using System.Diagnostics;

namespace CollectionsAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();

            MeasurePopulateUsers(userRepository);

            MeasureGetByIdNumber(userRepository);

            Console.ReadKey();
        }

        static void MeasurePopulateUsers(UserRepository userRepository)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            PopulateUsers(userRepository);

            stopwatch.Stop();
            Console.WriteLine("Populate User running time: {0}", stopwatch.Elapsed);
        }

        static void MeasureGetByIdNumber(UserRepository userRepository)
        {
            Stopwatch stopwatch = new Stopwatch();
            Random rnd = new Random();
            stopwatch.Start();

            int times = 10000;
            for (int i = 0; i < times; i++)
            {
                var id = rnd.Next(9000);
                userRepository.GetByIdNumber(id.ToString());
            }

            stopwatch.Stop();
            Console.WriteLine($"Get by id number x{times} running time: {stopwatch.Elapsed}");
        }

        static void PopulateUsers(UserRepository userRepository)
        {
            int count = 9000;
            userRepository.Insert(new User($"John0", $"Doe0", 23, "0"));
            for (int i = count - 1; i > 0; i--)
            {
                userRepository.Insert(new User($"John{i}", $"Doe{i}", 23, i.ToString()));
            }
            userRepository.Insert(new User($"John{count}", $"Doe{count}", 23, count.ToString()));
        }
    }
}
