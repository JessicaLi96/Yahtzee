using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp5
{
    class Program
    {
        static Random rnd;

        static int rollDice()
        {
            int result;
            result = rnd.Next(1, 7); //this function rolls one random 6 sided die
            return result;
        }

        static void printHand(int[] hand)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Die " + (i + 1).ToString() + ": " + hand[i]); //this function prints the hand 
            }
        }
        static int[] firstRoll() //this function rolls and stores the info of your first hand
        {
            int[] dice = new int[5]; //this is a array of 5 integers which will hold the values of your hand
            int die1 = rollDice();
            int die2 = rollDice(); //this rolls random dies and stores them in a variable
            int die3 = rollDice();
            int die4 = rollDice();
            int die5 = rollDice();


            dice[0] = die1;
            dice[1] = die2; //this stores the die variables into an array
            dice[2] = die3;
            dice[3] = die4;
            dice[4] = die5;
            return dice;


        }


        static int[] reroll(int[] dice)
        {  //this function allows you to reroll your die a max of 2 times
            int rollturn = 0;
            Boolean rerollturn = true;
            while (rollturn < 2 && rerollturn == true)//as long as you've rerolled less than twice and the player wants to reroll, do the below forever
            {
                Console.WriteLine("Would you like to reroll? (yes or no)");
                string answer1 = Console.ReadLine(); //player enters a yes or no
                answer1 = answer1.ToLower(); //this turns their answer all into lower case

                if (answer1.Equals("yes")) //if they say yes do the below
                {
                    int[] newRoll = dice; //create a new array (hand) of dies named newRoll

                    while (true)
                    {
                        Console.WriteLine("Would you like to reroll die 1? (type yes or no)");//asks if you want to reroll your first die
                        string answer = (Console.ReadLine()).ToLower();
                        if (answer.Equals("yes"))
                        {
                            newRoll[0] = rollDice(); //if yes it rerolls the first die and stores it in the 0th position in the array newRoll
                            break;
                        }
                        else if (answer.Equals("no")) //if the answer is no, you break out of the while loop
                        {
                            break;
                        }
                        else { Console.WriteLine("Please enter a valid answer"); }//this catches answers that aren't  "yes" or "no"s
                    }
                    while (true)
                    {
                        Console.WriteLine("Would you like to reroll die 2? (type yes or no)");//asks if you want to reroll your second die
                        string aanswer = (Console.ReadLine()).ToLower();
                        if (aanswer.Equals("yes"))
                        {
                            newRoll[1] = rollDice();
                            break;              //these functions are all the same as the above one

                        }
                        else if (aanswer.Equals("no"))
                        { break; }
                        else { Console.WriteLine("Please enter a valid answer"); }
                    }
                    while (true)
                    {
                        Console.WriteLine("Would you like to reroll die 3? (type yes or no)");
                        string banswer = (Console.ReadLine()).ToLower();
                        if (banswer.Equals("yes"))
                        {
                            newRoll[2] = rollDice();        //these functions are all the same as the above one
                            break;

                        }
                        else if (banswer.Equals("no"))
                        { break; }
                        else { Console.WriteLine("Please enter a valid answer"); }
                    }
                    while (true)
                    {
                        Console.WriteLine("Would you like to reroll die 4? (type yes or no)");
                        string canswer = (Console.ReadLine()).ToLower();
                        if (canswer.Equals("yes"))
                        {
                            newRoll[3] = rollDice();
                            break;
                            //these functions are all the same as the above one
                        }
                        else if (canswer.Equals("no"))
                        { break; }
                        else { Console.WriteLine("Please enter a valid answer"); }
                    }
                    while (true)
                    {
                        Console.WriteLine("Would you like to reroll die 5? (type yes or no)");
                        string danswer = (Console.ReadLine()).ToLower();
                        if (danswer.Equals("yes"))
                        {
                            newRoll[4] = rollDice();
                            break;
                            //these functions are all the same as the above one
                        }
                        else if (danswer.Equals("no"))
                        { break; }
                        else { Console.WriteLine("Please enter a valid answer"); }
                    }
                    rollturn++;//this increases the rollturn number by one
                    Console.WriteLine("Your new hand is:");
                    printHand(dice);
                }


                else if (answer1.Equals("no"))//if you dont want to reroll it breaks out of the while loop
                {
                    break;

                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Answer ('yes' or 'no')"); //this catches if you dont input a valid answer

                }
            }

            return dice;
        }

        static int checkNums(int[] newRoll, int num)
        { //this checks and scores your hand for the categories 1-6 (uppers)

            int count = 0; //this will count how many of "x" you will have 
            int score;//this will store your score
            for (int i = 0; i < 5; i++)
            {
                if (newRoll[i] == num)//counts the number of "x" number you have in your hand 
                {
                    count++;
                }
                else
                {
                    count = count + 0;
                }
            }
            score = count * num;//your score is the number you choose times the amount
            return score;
        }

        static int checkKinds(int[] newRoll, int num) //this checks and scores your hand for the kinds
        {
            int count = 0;
            int score = 0;
            Array.Sort(newRoll);//this sorts your dies into ascending order
            for (int i = 0; i < 4; i++)
            {

                if (newRoll[i] == newRoll[i + 1])
                {
                    count++;
                    //this does a similar function to the one above
                }
                else
                {
                    count = 0;
                }
                if (count == num - 1)
                {
                    score = newRoll[i] * (num);
                }

            }
            return score;
        }

        static int checkFullHouse(int[] newRoll)
        { //this checks and scores  your hand for a full house
            int score = 0;
            Boolean three = false;
            Boolean two = false;
            Array.Sort(newRoll);
            if ((newRoll[0] == newRoll[2]) || (newRoll[2] == newRoll[4]))
            {
                three = true;
            }               //if you have two of a kind and three of a kind then the boolean two and three is true
            if ((newRoll[0] == newRoll[1]) || (newRoll[3] == newRoll[4]))
            {
                two = true;
            }

            if (two == true && three == true)
            {
                score = 25;//this is the score you would get if two and three is true
            }
            else
            {
                score = 0;
            }
            return score;
        }

        static int checkStraight(int[] newRoll, int num)
        { //this checks and scores your hand for straights
            int score = 0;
            int count = 0;
            Array.Sort(newRoll);
            for (int i = 0; i < 4; i++)
            {
                if ((newRoll[i] + 1) == newRoll[i + 1])
                {
                    count++;

                }

            }
            if (count == 4 && num == 5)
            {
                score = 40;
            }
            else if (count == 3 && num == 4)
            {
                score = 30;

            }
            else { score = 0; }

            return score;


        }
        static int checkYahtzee(int[] newRoll)
        { //this checks and scores your hand for a yahtzee
            int score;
            int a = newRoll[0];
            if (a == newRoll[1] && a == newRoll[2] && a == newRoll[3] && a == newRoll[4])
            {
                score = 50;
            }
            else { score = 0; }
            return score;

        }
        static int checkChance(int[] newRoll)
        { //this scores your hand for a chance
            int score = newRoll[0] + newRoll[1] + newRoll[2] + newRoll[3] + newRoll[4];
            return score;
        }

        static int checkHand(int[] finalroll)
        { //this takes all the "check" functions and puts them into a function that the user will interact with

            Boolean check = true;
            int result = 0;

            while (check == true)
            {

                Console.WriteLine("Which category do you choose?");
                Console.WriteLine(" 1. Uppers \n 2. Kinds \n 3. Full House \n 4. Straights \n 5. Yahtzee \n 6. Chance");
                string choice = Console.ReadLine();
                int intchoice;
                if (int.TryParse(choice, out intchoice))
                {//choice is a number do the below
                 ////takes in the answer and turns it into a number
                    if (intchoice == 1)//if your choice is uppers (1) do the below
                    {//check nums
                        while (true)
                        {
                            Console.WriteLine("Which number do you choose? (enter 1,2,3,4,5, or 6)");
                            string number = Console.ReadLine();
                            int intnumber;
                            if (int.TryParse(number, out intnumber))
                            {
                                if (intnumber > 0 && intnumber < 7)
                                {
                                    result = checkNums(finalroll, intnumber);//this calculates your score for uppers

                                    check = false;
                                    break;
                                }


                                else { Console.WriteLine("Please enter a valid number (1-6) that you haven't chosen yet"); }
                            }
                            else { Console.WriteLine("Please enter a valid number"); }
                        }

                    }
                    else if (intchoice == 2)//if your choice is kinds do the below
                    {
                        while (true)
                        {
                            Console.WriteLine("Which Kind do you choose? (enter 3 or 4)");
                            string kind = Console.ReadLine();
                            int intkind;
                            if (int.TryParse(kind, out intkind))
                            {
                                check = false;
                                if (intkind == 3 || intkind == 4)
                                {
                                    result = checkKinds(finalroll, intkind); //this calculates your score for kinds
                                    break;
                                }
                                else { Console.WriteLine("Please enter a valid number (3 or 4)"); }
                            }
                            else { Console.WriteLine("Please enter a number"); }

                        }
                    }
                    else if (intchoice == 3)
                    { //if your choice is full house do the below
                        check = false;
                        result = checkFullHouse(finalroll);//this calculates your score for full house
                    }
                    else if (intchoice == 4)//if your choice is straights do the below
                    {
                        while (true)
                        {
                            Console.WriteLine("Which Straight do you choose? (enter 4 or 5)");
                            string straight = Console.ReadLine();
                            int intstraight;
                            if (int.TryParse(straight, out intstraight))
                            {
                                if (intstraight == 4 || intstraight == 5)
                                {
                                    result = checkStraight(finalroll, intstraight);//this calculates your score for straights
                                    check = false;

                                    break;
                                }
                                else { Console.WriteLine("Please enter a valid number (4 or 5)"); }
                            }
                            else { Console.WriteLine("Please enter a number");}
                        }

                    }
                    else if (intchoice == 5)
                    {
                        check = false;
                        result = checkYahtzee(finalroll);//this calculates your score for yahtzee
                    }
                    else if (intchoice == 6)
                    {
                        check = false;
                        result = checkChance(finalroll);//this calculates your score for chances
                    }
                    else { Console.WriteLine("Please enter a valid number (1-6)"); }
                }
                else { Console.WriteLine("Please enter a valid number"); }//the choice is a string
            }
            Console.WriteLine("Your score is: " + result);
            return result;

        }


        static void Main(string[] args) //this is the main function where we take all the past functions and make them useable for the user
        {
            Boolean play = true;
            int totalscore = 0;
            Console.WriteLine("Welcome! This is a game of one-player yahtzee");

            while (play == true)//as long as you are playing the bottom will run
            {
                for (int i = 0; i < 13; i++)
                {//this lets you play one game in which you have 13 turns
                    rnd = new Random();
                    int[] dice = new int[5];//creates a new hand of dies 
                    dice = firstRoll();
                    Console.WriteLine("Your Hand for turn " + (i + 1) + " is:");
                    printHand(dice);//displays your hand
                    reroll(dice);
                    totalscore = checkHand(dice) + totalscore;//this adds up your scores and keeps track of them
                    Console.WriteLine("Your total score is: " + totalscore);

                }
                Console.WriteLine("Game Over \n Your final score is: " + totalscore);//at the end of 13 rounds it gives you the final score
                
                while (true) {
                    Console.WriteLine("Do you want to play again?");// the code for if you want to play again

                    string answer = Console.ReadLine();
                    answer = answer.ToLower();
                    if (answer.Equals("yes"))
                    {//if you want to continue playing the loop runs again
                        play = true;
                        break;
                    
                    }
                    else if (answer.Equals("no"))
                    {//if you dont want to play, play = false and the loop stops
                        play = false;
                        break;
                    }
                    else { Console.WriteLine("Please enter a valid answer (yes or no)"); }
                 }
            }
            Console.WriteLine("Thanks for playing!\nFor more information on the full game, visit Hasbro.com! \nFull game is available for $7.99 plus shipping");
            //this shows after you are done playing the game

            Console.ReadLine();


        }

    }
}
