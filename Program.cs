using System;
using System.Collections.Generic;

namespace Lab9_Refactoring_time_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>
            {
                "Abe Hamdan", "John Apple", "Megan Banana", "Jessica Hog"
            };
            List<string> homeTowns = new List<string>
            {
                "Dearborn MI", "Dallas TX", "Detroit MI", "Orlando FL"
            };
            List<string> favFood = new List<string>
            {
                "French Fries", "Apples", "Bananas", "Tacos"
            };
            List<string> favColor = new List<string>
            {
                "Purple", "Red", "Yellow", "Brown"
            };
            PrintFourLists(names, homeTowns, favFood, favColor);
            Console.WriteLine("");
            //while loop true will keep running until n is entered.
            while (true)
            {
                string userInput = GetUserInput("Would you like to know more about a student? or add another student to the list? learn/add or n to exit.");
                if (userInput == "learn")
                {
                    Console.WriteLine(String.Join(" ", names));
                    while (true)
                    {
                        try
                        {
                            //I used names.Count so that when the user adds another name they will not get an out of index range error.
                            int selectedPerson = int.Parse(GetUserInput($"Who would you like to learn more about? 1-{names.Count}. 0 to leave"));
                            if (selectedPerson == 0)
                            {
                                break;
                            }
                            while (true)
                            {
                                string userInfo = GetUserInput($"What would you like to know about {names[selectedPerson - 1]} their hometown, favorite food, or favorite color? n to leave");
                                if (userInfo == "hometown")
                                {
                                    Console.WriteLine($"{names[selectedPerson - 1]}'s hometown is {homeTowns[selectedPerson - 1]}");
                                }
                                else if (userInfo == "favorite food")
                                {
                                    Console.WriteLine($"{names[selectedPerson - 1]}'s favorite food is {favFood[selectedPerson - 1]}");
                                }
                                else if (userInfo == "favorite color")
                                {
                                    Console.WriteLine($"{names[selectedPerson - 1]}'s favorite color is {favColor[selectedPerson - 1]}");
                                }
                                else if (userInfo == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("invalid entry! please try again");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if ((ex is IndexOutOfRangeException) || (ex is FormatException))
                            {
                                Console.WriteLine("That is not valid number");
                            }
                        }
                    }
                }
                else if (userInput == "add")
                {
                    AddUserInputToList(names, "Add a new Student");
                    AddUserInputToList(homeTowns, $"What is {names[names.Count - 1]} Hometown?  ");
                    AddUserInputToList(favFood, "What is their favorite food?");
                    AddUserInputToList(favColor, "What is their favorite color?");
                    PrintFourLists(names, homeTowns, favFood, favColor);
                }
                else if (userInput == "n")
                {
                    break;
                }
            }
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static void AddUserInputToList(List<string> listOfStrings, string message)
        {
            string input = GetUserInput(message);
            listOfStrings.Add(input);
        }
        public static void PrintFourLists(List<string> list1, List<string> list2, List<string> list3, List<string> list4)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine($"{list1[i]} lives in {list2[i]} loves to eat {list3[i]} and their favorite color is {list4[i]} ");
            }
        }
    }
}
