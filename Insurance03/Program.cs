namespace Insurance03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                fix the display of euro symbols on the console
                see the following
                https://www.codeproject.com/Questions/455766/Euro-symbol-does-not-show-up-in-Console-WriteLine
            */
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            int engineSize = readInt("Please enter your engine size : "); // 2000 'A', 1999 => 'B'
            char engineClass = getEngineClass(engineSize);

            int age = readInt("Please enter your age : ");
            double fullRate = 2000;
            double annualPremium = getAnnualPremium(fullRate, engineClass, age);

        }

        static int readInt(string prompt)
        {
            Console.Write(prompt);
            string str = Console.ReadLine();
            int number = 0;
            try
            {
                number = Convert.ToInt32(str);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return number;

        }


        /*
            If a driver is under 25 
                they pay fullrate unless it's a smaller engine (D or E)
            otherwise
                they get a discount based on the engine size
        */
        static double getAnnualPremium(double fullRate, char engineClass, int age)
        {
            double annualPremium = fullRate;

            if (age < 25)   // under 25
            {
                Console.WriteLine($"Driver is under 25. Driver's age : {age}");
                /*
                    Now, use the engineClass to detremine how much they have to pay 
                    class A-C : full rate
                    class D or E: 80%
                */
                if (engineClass == 'D' || engineClass == 'E')
                {
                    // annualPremium = annualPremium * 0.8;
                    annualPremium *= 0.8;
                }

            }
            else
            // 25 or over
            {
                /*
                    Customers aged 25 or over pay 
                    80% of the full rate for a Class A motor vehicle, 
                    70% of the full rate for a Class B motor vehicle, 
                    60% of the full rate for a Class C motor vehicle, 
                    50% of the full rate for a Class D motor vehicle and 
                    40% of the full rate for a Class E motor vehicle. 
                */
                Console.WriteLine($"Driver is 25 or over. Driver's age : {age}");
                if (engineClass == 'A')
                {
                    annualPremium *= 0.8;   // 80%
                }
                else if (engineClass == 'B')
                {
                    annualPremium *= 0.7;   // 70%
                }
                else if (engineClass == 'C')
                {
                    annualPremium *= 0.6;   // 60%
                }
                else if (engineClass == 'D')
                {
                    annualPremium *= 0.5;   // 50%
                }
                else if (engineClass == 'E')
                {
                    annualPremium *= 0.4;   // 40%
                }
                else
                {
                    Console.WriteLine($"Invalid engine class : {engineClass}");
                }
            }
            double discount;
            discount = fullRate - annualPremium;
            Console.WriteLine($"Annual Premium : € {annualPremium}");
            Console.WriteLine($"Discount       : € {discount}");

            return annualPremium;
        }

        static void test()
        {
            char engineClass = 'A';
            double annualPremium = 0;

            if (engineClass == 'A') annualPremium *= 0.8;   // 80%
            else if (engineClass == 'B') annualPremium *= 0.7;   // 70%
            else if (engineClass == 'C') annualPremium *= 0.6;   // 60%
            else if (engineClass == 'D') annualPremium *= 0.5;   // 50%
            else if (engineClass == 'E') annualPremium *= 0.4;   // 40%
            else Console.WriteLine("Invalid engine class " + engineClass);

        }


        /*
         * determine the engine class using the engine size
         */
        static char getEngineClass(int engineSize)
        {
            char engineClass;   // assign the value below based on engine size
            if (engineSize > 2000)
            {
                engineClass = 'A';
            }
            // engineSize <= 2000
            else if (engineSize > 1500 && engineSize <= 2000)
            {
                engineClass = 'B';
            }
            // engineSize <= 1500
            else if (engineSize > 1000 && engineSize <= 1500)
            {
                engineClass = 'C';
            }
            // engineSize <= 1000
            else if (engineSize > 800 && engineSize <= 1000)
            {
                engineClass = 'D';
            }
            // engineSize <= 800
            else
            {
                engineClass = 'E';
            }
            Console.WriteLine($"The engine size is  : {engineSize}");
            Console.WriteLine($"The engine class is : {engineClass}");

            return engineClass;
        }
    }
}