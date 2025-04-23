// Breakfast app with async and await
namespace BreakFast
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            var coffee = PourCoffee();
            Console.WriteLine(coffee);

            var eggTask = FryEgg();
            var baconTask = FryBacon();
            var toastTask = MakeToastWithButterAndJam(2);
            var breakfastTasks = new List<Task> { eggTask, baconTask, toastTask };
            
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }

            var juice = PourJuice();
            Console.WriteLine(juice);
            Console.WriteLine("Breakfast is ready!");

        }
        public static string PourCoffee()
        {
            Console.WriteLine("Puring Coffee");
            return "Coffee Poured";
        }
        public static string PourJuice()
        {
            Console.WriteLine("Puring Juice");
            return "Juice Poured";
        }
        public static void ApplyButter(string bread)
        {
            Console.WriteLine($"Applying Butter to {bread}");
        }
        public static void ApplyJam(string bread)
        {
            Console.WriteLine($"Applying Jam to {bread}");
        }
        public static async Task<string> FryEgg()
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000);

            Console.WriteLine($"cracking eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000);

            Console.WriteLine("Put eggs on plate");

            return "Egg Frying Success";
        }
        public static async Task<string> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return "Toasted";

        }
        public static async Task<string> MakeToastWithButterAndJam(int number)
        {
            var toast = await ToastBread(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return "Toasted and Buttered/Jamed";
        }

        public static async Task<string> FryBacon()
        {
            Console.WriteLine($"putting bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return "Bacon frying done";
        }
    }

}