using System;

namespace example_5._6
{
    internal class Program
    {
        static (string FirstName, string LastName, int Age, bool HasPets, int PetsNumber, string[] PetsNames, int FavColorsNumber, string[] FavColors) UserData()
        {
            (string FirstName, string LastName, int Age, bool HasPets, int PetsNumber, string[] PetsNames, int FavColorsNumber, string[] FavColors) User;

            //ask first name
            Console.WriteLine("Enter your name: ");
            User.FirstName = Console.ReadLine();

            //ask last name
            Console.WriteLine("Enter your last name: ");
            User.LastName = Console.ReadLine();

            //ask age
            Console.WriteLine("How old are you?");
            bool isNumeric = int.TryParse(Console.ReadLine(), out User.Age);
            if (!isNumeric || User.Age < 0) //check if the entered value is numeric and greater than 0
            {
                User.Age = NumberCorrection();
            }

            //ask if a user has pets
            Console.WriteLine("Do you have a pet? (yes/no)");
            User.HasPets = Console.ReadLine().Equals("yes", StringComparison.CurrentCultureIgnoreCase); //accepting yes without case (YES, Yes, yes, etc.)

            //ask how many pets a user have
            User.PetsNumber = 0; //need to initialize PetsNumber, otherwise "return User" might throw 
            if (User.HasPets == true)
            {
                Console.WriteLine("How many pets do you have?");
                bool numericCheck = int.TryParse(Console.ReadLine(), out User.PetsNumber);
                if (!numericCheck || User.PetsNumber < 0) //check if the entered value is numeric and greater than 0
                {
                    User.PetsNumber = NumberCorrection();
                }
                User.PetsNames = new string[User.PetsNumber];
                for (int i = 0; i < User.PetsNumber; i++) //get pets names into array
                {
                    Console.WriteLine($"Enter the name of your pet number {i + 1}");
                    User.PetsNames[i] = Console.ReadLine();
                }

            }
            else
            {
                User.PetsNames = new string[0];
            }

            //ask a user about the number of fav colors
            Console.WriteLine("How many favorite colors do you have?");
            bool checkNumeric = int.TryParse(Console.ReadLine(), out User.FavColorsNumber);
            if (!checkNumeric || User.FavColorsNumber < 0) //check if the entered value is numeric and greater than 0
            {
                User.FavColorsNumber = NumberCorrection();
            }

            //create an array of all fav colors
            User.FavColors = new string[User.FavColorsNumber];
            for (int i = 0; i < User.FavColorsNumber; i++)
            {
                Console.WriteLine($"Enter your favorite color number {i + 1}:");
                User.FavColors[i] = Console.ReadLine();
            }

            return User;
        }


        static int NumberCorrection()
        {
            Console.WriteLine("You have not enetered a valid number. Please try again");
            bool isNumeric = int.TryParse(Console.ReadLine(), out int number);
            if (!isNumeric)
            {
                NumberCorrection();
            }

            return number;
        }


        static void Main(string[] args)
        {
            var (FirstName, LastName, Age, HasPets, PetsNumber, PetsNames, FavColorsNumber, FavColors) = UserData();

            Console.WriteLine("=============================");
            Console.WriteLine($"Hi, {FirstName} {LastName}, you're {Age} years old");

            //print pets names if the user has them
            if (HasPets == true)
            {
                Console.WriteLine($"You have {PetsNumber} pets:");
                foreach (string petName in PetsNames)
                {
                    Console.WriteLine(petName);
                }
            }
            else
            {
                Console.WriteLine("You don't have any pets");
            }

            //print out the colors info
            if (FavColorsNumber == 0)
            {
                Console.WriteLine("You don't have any favorite colors");
            }
            else
            {
                Console.WriteLine($"You have {FavColorsNumber} favorite colors. They are: ");
                foreach (string favColor in FavColors)
                {
                    Console.WriteLine(favColor);
                }
            }

            Console.ReadLine();
        }

    }
}



