internal class Program
{
    private static void Main(string[] args)
    {
        // блок основных переменных
        string? enteredValue = "";

        // блок вспомогательных переменных
        int technicaIntlValue_1 = 0;
        int matrix_1Sum = 0;
        int matrixLength = 0;
        int matrixHeight = 0;

        string techicalStringValue_1 = "-";

        bool cycleExitСonditions_1 = false;
        bool tryParse_enterdValue = false;

        string[] matrixParameters = { "length", "height" };
        string[] searchingIcons = { ".  ", ".. ", "...", };//для анимации

        techicalStringValue_1 = string.Join("-", Enumerable.Repeat(techicalStringValue_1, 35));//для пунктирной строчки 

        void demarcationLine()
        {
            // Разделяющая линия
            Console.WriteLine(techicalStringValue_1);
        }

        void AppExitAnimation()
        {
            for (int j = 3; j > -1; j--)
            {
                foreach (string icon in searchingIcons)
                {
                    Console.Write($"\rВыходим из приложения{icon}");
                    Thread.Sleep(350);
                }
                Console.Write($"\r{new string(' ', Console.BufferWidth)}");
            }
        }

        void notEnterANumder()
        {

            demarcationLine();
            Console.WriteLine("You didn't enter a number. " +
            "Please try again.");
        }

        void enteredValueToLower()
        {
            //Метод для определение введеных данных игнорирую регистр. И для устранения проблемы возможного нулевого референса.
            if (enteredValue != null)
            {
                enteredValue = enteredValue.ToLower();
            }
        }

        void tryParseEnteredValue()
        {
            int a = 0;
            if (int.TryParse(enteredValue, out a) == false || enteredValue == "")
            {
                enteredValueToLower();
                tryParse_enterdValue = false;
            }
            else
            {
                technicaIntlValue_1 = Convert.ToInt32(enteredValue);
                tryParse_enterdValue = true;
            }
        }

        for (int a = 0; a < 2; a++) //ввод параметров матриц
        {

            Console.WriteLine($"Please enter the {matrixParameters[a]} of the matrix" +
                              " or enter \"Back\" to exit the application");

            do
            {

                cycleExitСonditions_1 = false;

                enteredValue = Console.ReadLine();

                tryParseEnteredValue();

                switch (tryParse_enterdValue)
                {
                    case (true):

                        if (a == 0)
                        {
                            matrixLength = int.Parse(enteredValue);
                        }

                        else
                        {
                            matrixHeight = int.Parse(enteredValue);
                        }

                        cycleExitСonditions_1 = true;

                        break;

                    case (false):

                        if (enteredValue == "back")
                        {
                            demarcationLine();
                            AppExitAnimation();
                            cycleExitСonditions_1 = true;
                        }

                        else
                        {
                            notEnterANumder();
                        }

                        break;

                }
            } while (cycleExitСonditions_1 == false);
        }
        //создание матриц с задаными параметрами
        int[,] matrix_a = new int[matrixHeight, matrixLength];
        int[,] matrix_b = new int[matrixHeight, matrixLength];
        int[,] matrix_c = new int[matrixHeight, matrixLength];

        Random dice = new Random();

        demarcationLine();

        for (int a = 0; a < 3; a++)
        {

            if (a == 1)
            {
                Console.WriteLine("+");
            }

            if (a == 2)
            {
                Console.WriteLine("=");
            }

            for (int b = 0; b < matrixHeight; b++)
            {

                Console.Write(" ");

                for (int c = 0; c < matrixLength; c++)
                {
                    if (a == 0)
                    {
                        matrix_a[b, c] = dice.Next(1, 9);
                        Console.Write($"{matrix_a[b, c]} ");
                        matrix_1Sum += matrix_a[b, c];
                    }

                    else if (a == 1)
                    {
                        matrix_b[b, c] = dice.Next(1, 9);
                        Console.Write($"{matrix_b[b, c]} ");
                    }

                    else
                    {
                        matrix_c[b, c] = matrix_a[b, c] + matrix_b[b, c];
                        Console.Write($"{matrix_c[b, c]} ");
                    }
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine($"\nSum of all elements in the first matrix is {matrix_1Sum}");

        demarcationLine();
    }
}
