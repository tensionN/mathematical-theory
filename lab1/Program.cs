using System;

namespace ConsoleApp1
{
    class Program
    {
        static Dictionary<string, int> _feelings = new Dictionary<string, int>()
        {
            { "very good", 10 },
            { "good", 8 },
            { "normal", 6 },
            { "bad", 3 },
            { "very bad", 1 },
        };
        
        static Dictionary<string, int> GetHumanFeelings()
        {
            var humanFeelings = new Dictionary<string, int>();
            Console.WriteLine("Enter your feeling when you are at home in the rain");
            Console.WriteLine("'Very good', \n'Good', \n'Normal', \n'Bad', \n'Very bad'");
            humanFeelings.TryAdd("Home_Rain", _feelings[Console.ReadLine().ToLower()]);
            
            Console.WriteLine("Enter your feeling when you are at home during the sun");
            Console.WriteLine("'Very good', \n'Good', \n'Normal', \n'Bad', \n'Very bad'");
            humanFeelings.TryAdd("Home_Sun", _feelings[Console.ReadLine().ToLower()]);
            
            Console.WriteLine("Enter your feeling when you are in the forest in the rain");
            Console.WriteLine("'Very good', \n'Good', \n'Normal', \n'Bad', \n'Very bad'");
            humanFeelings.TryAdd("Forest_Rain", _feelings[Console.ReadLine().ToLower()]);
            
            Console.WriteLine("Enter your feeling when you are in the forest during the sun");
            Console.WriteLine("'Very good', \n'Good', \n'Normal', \n'Bad', \n'Very bad'");
            humanFeelings.TryAdd("Forest_Sun", _feelings[Console.ReadLine().ToLower()]);

            return humanFeelings;
        }
        static Dictionary<string, double> GetW(double pRain, Dictionary<string, int> humanFeelings )
        {
            return new Dictionary<string, double>()
            {
                { "Home", pRain * humanFeelings["Home_Rain"] + (1 - pRain) * humanFeelings["Home_Sun"] },
                { "Forest", pRain * humanFeelings["Forest_Rain"] + (1 - pRain) * humanFeelings["Forest_Sun"] }
            };
        }

        static string Result(double wHome, double wForest)
        {
            if (wHome > wForest) return "Stay at home";
            else return "Go to forest";
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the probability of rain");
            double pRain = double.Parse(Console.ReadLine());
            
            var humanFeelings = GetHumanFeelings();
            
            var w = GetW(pRain, humanFeelings);

            Console.WriteLine(Result(w["Home"], w["Forest"]));
        }
    }
}