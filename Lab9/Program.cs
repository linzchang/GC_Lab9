using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection;
            bool validSelection;
            string userAnswer;

            List<string> studentNames = new List<string>{"Michael Hern","Taylor Everts","Josh Zimmerman","Lin-z Chang","Madelyn Hilty","Nana Banahene","Rochelle Toles aka Roach","Shah Shahid",
             "Tim Broughton","Abby Wessels","Blake Shaw aka Jedi Shaw","Bob Valentic","Jordan Owiesny","Jay Stiles","Jon Shaw",};
            List<string> studentHometown = new List<string>{"Canton, MI","Caro, MI","Taylor, MI","Toledo, OH","Oxford, MI","Guana","Mars","Newark, NJ",
             "Detroit, MI","Traverse City, MI","Los Angeles, CA","St. Clair Shores, MI","Warren, MI","Macomb, MI","Huntington Woods, MI",};
            List<string> studentFavoriteFood = new List<string>{ "Chicken Wings","Chicken Cordon Bleu", "Turkey","Ice Cream","Croissant","Empanadas","Space Cheese",
             "Chicken Wings","Chicken Parm","Soup","Cannolis","Pizza","Burgers","Pickles","Ribs",};
            List<string> studentGreatestFear = new List<string> {"Spiders","Eggs","Clowns","Tight spaces","Elevators", "Cats", "Cocoons", "Large bodies of water",
                "Cows", "Open fields", "Aliens", "Your mom", "Ghosts", "Zombies", "The color pink", };

            //welcome text
            Console.WriteLine("Welcome to the Dev.Build 2.0 student database!");

            while (true)
            {
                //Ask user if they'd like to find out about a student OR add a new student
                Console.WriteLine("Would you like to add a new student or get information on an existing student?");
                Console.WriteLine("Select 1 to Add Student or 2 to Get Information on a current student.");
                validSelection = int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    //Add Student:
                    case 1:
                        //ask user for student's information
                        //take in user input
                        //add new values to each applicable List
                        string newName, newHometown, newFood, newFear;

                        newName = AddStudent("What is the student's name?", studentNames);
                        newHometown = AddStudent("What is their hometown?", studentHometown);
                        newFood = AddStudent("What is their favorite food?", studentFavoriteFood);
                        newFear = AddStudent("What is their greatest fear?", studentGreatestFear);

                        Console.WriteLine("Thanks! Your new student is: " + newName + ". They're from " + newHometown + ".");
                        Console.WriteLine("They love to eat " + newFood + " and they are afraid of " + newFear + ".");
                        break;
                    //Get Info:
                    case 2:
                        //Ask user which student they want information on, and validate input
                        int UserInput = GetUserNumber(studentNames);
                        int Index = UserInput - 1;

                        //grab the student's name from list using index
                        string Name = GetStudentInfo(Index, studentNames);
                        Console.WriteLine("Student " + UserInput + " is " + Name + ".");

                        //grab specific information for that student from correct list
                        while (true)
                        {
                            Console.WriteLine("What would you like to know about " + Name + "? (enter 1 for 'Hometown' 2 for 'Favorite food' or 3 for 'Greatest Fear')");
                            string userChoice = Console.ReadLine().ToLower();

                            if (userChoice == "1")
                            {
                                string hometown = GetStudentInfo(Index, studentHometown);
                                Console.WriteLine(Name + "'s hometown is " + hometown);
                            }
                            else if (userChoice == "2")
                            {
                                string food = GetStudentInfo(Index, studentFavoriteFood);
                                Console.WriteLine(Name + "'s favorite food is " + food);
                            }
                            else if (userChoice == "3")
                            {
                                string fear = GetStudentInfo(Index, studentGreatestFear);
                                Console.WriteLine(Name + "'s greatest fear is " + fear);
                            }
                            else
                            {
                                Console.WriteLine("That data does not exist. Please try again.");
                                continue;
                            }


                            //ask if user would like to know more about specific student
                            Console.WriteLine("Would you like to know more about " + Name + "? Type N to quit.");
                            string userChoice2 = Console.ReadLine().ToUpper();
                            if (userChoice2 == "N")
                            {
                                break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("That is not a valid selection, try again.");
                        continue;
                }

                Console.WriteLine("Would you like to add or look up another student? Type N to quit.");
                userAnswer = Console.ReadLine().ToUpper();
                if (userAnswer == "N")
                {
                    break;
                }

            }
        }
        public static string AddStudent(string message, List<string> selection)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            while (input == "")
            {
                Console.WriteLine("That is not valid, please try again.");
                input = Console.ReadLine();
                continue;
            }

            selection.Add(input);
            string newItem = GetStudentInfo((selection.Count) - 1, selection);
            return newItem;
        }

        public static int GetUserNumber(List<string> selection)
        {
            int userNumber = 0;
            bool parsed;

            //validate input
            while (true)
            {
                Console.WriteLine("Which student would you like to learn more about? (enter a number 1 -" + selection.Count + ".");
                string input = Console.ReadLine();
                parsed = int.TryParse(input, out userNumber);

                if (ValidateInput(parsed, userNumber, selection) == false)
                {
                    Console.WriteLine("That is not valid, please try again.");
                    continue;
                }
                else
                {
                    break;
                }
            }

            //edit userinput to match 0 based indexes
            return userNumber;
        }

        public static bool ValidateInput(bool parsed, int userNumber, List<string> selection)
        {
            bool Valid = true;

            //if user did not enter a number re-prompt them
            if (parsed == false)
            {
                Console.WriteLine("That is not valid input.");
                return !Valid;
            }
            //if user entered a number out of range re-prompt them
            else if (userNumber < 1 || userNumber > selection.Count)
            {
                Console.WriteLine("That student does not exist.  Please try again.");
                return !Valid;
            }
            //otherwise continue
            else
            {
                return Valid;
            }
        }

        public static string GetStudentInfo(int number, List<string> selection)
        {
            string output = selection[number];
            return output;
        }

    }
}
