using System;

namespace example_5._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserProfile();
        }

        static void UserProfile ()
        {
            (string FirstName, string LastName, int Age, string[] PetsNames, int favColorsNumber, string[] FavColors) User;

            Console.WriteLine("Enter your name: ");
            User.FirstName = Console.ReadLine();

            Console.WriteLine("Enter your last name: ");
            User.LastName = Console.ReadLine();

            Console.WriteLine("How old are you?");
            bool isNumeric = int.TryParse(Console.ReadLine(), out User.Age); 
            if (!isNumeric || User.Age < 0) //check if the entered value is numeric and greater than 0
            {
                User.Age = NumberCorrection();
            }

            Console.WriteLine("Do you have a pet? (yes/no)");
            bool HasPet = Console.ReadLine().Equals("yes", StringComparison.CurrentCultureIgnoreCase); //accepting yes without case (YES, Yes, yes, etc.)

            //declare the arrays, not sure how else to do it??
            User.PetsNames = new string[2];
            User.FavColors = new string[2];

            //ask how many pets a user have
            if (HasPet == true)
            {
                Console.WriteLine("How many pets do you have?");
                bool numericCheck = int.TryParse(Console.ReadLine(), out int petsNum);
                if (!numericCheck || petsNum < 0) //check if the entered value is numeric and greater than 0
                {
                    petsNum = NumberCorrection();
                }
                User.PetsNames = PetsProfile(petsNum);
            }

            //ask a user about the number of fav colors
            Console.WriteLine("How many favorite colors do you have?"); 
            bool checkNumeric = int.TryParse(Console.ReadLine(), out int favColorsNumber);
            if (!checkNumeric || favColorsNumber < 0) //check if the entered value is numeric and greater than 0
            {
                favColorsNumber = NumberCorrection();
            }
            

            //create an array of all fav colors
            User.FavColors = new string[favColorsNumber];
            for (int i = 0; i < favColorsNumber; i++)
            {
                Console.WriteLine($"Enter your favorite color number {i + 1}:");
                User.FavColors[i] = Console.ReadLine();
            }


            //print out the info about the user
            Console.WriteLine("=============================");
            Console.WriteLine($"Hi, {User.FirstName} {User.LastName}, you're {User.Age} years old");
            
            //print pets names if the user has them
            if(HasPet == true)
            {
                Console.WriteLine("You have the following pets:");
                foreach (string petName in User.PetsNames)
                {
                    Console.WriteLine(petName);
                }
            }
            else
            {
                Console.WriteLine("You don't have any pets");
            }

            //print out the colors info
            Console.WriteLine($"You have {favColorsNumber} favorite colors. They are: ");
            foreach(string favColor in User.FavColors)
            {
                Console.WriteLine(favColor);
            }

            Console.ReadLine();
        }

        //a method to list all pets names
        static string[] PetsProfile(int numberOfPets)
        {
            string[] petsNames = new string[numberOfPets];

            for (int i = 0; i < numberOfPets; i++)
            {
                Console.WriteLine($"Enter the name of your pet number {i + 1}");
                petsNames[i] = Console.ReadLine();
            }

            return petsNames;
        }

        //a method that asks a user to re-enter the value until it's numeric
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
    }
}
