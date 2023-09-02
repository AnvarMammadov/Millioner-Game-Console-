using System;
using System.Collections.Generic;

namespace C_HomeWork2_Millioners_Game_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var questions = MyDatas();

            Random random = new Random();

            int[] randomQuestions = RandomQuestion(random);
            int[] randomAnswers = RandomAnswers(random);
            int[] QuestionsValue = { 1000, 2000, 5000, 10000, 50000, 100000, 250000, 500000, 750000, 1000000 };
            string[] yourHelps = { "\\... (i) .../ ..(info : Call Friend )", "\\... (2x?) .../ ..(info : Probability of making a mistake )",
                "\\... <-> .../ ..(info : Choose one of the two options)" };
            bool[] usedHelps = new bool[yourHelps.Length];
            int usedHelpCount = 0;
            int money = 0;
            bool questionsFlag = true;
            int mistakeCount = 2;
            for (int i = 0; i < randomQuestions.Length; i++)
            {

                Console.Clear();
                if (questionsFlag)
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\t\t\t\t\t\t\tHelp :  1) \\... (i) .../  2) \\... (2x?) .../ 3) \\... <-> .../\n\n"); Console.ResetColor();
                        Console.Write($"Sual [ {i + 1} ] : {questions[randomQuestions[i]][0]}");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\t\t\tMoney : {money} $"); Console.ResetColor();
                        Console.WriteLine($"A) {questions[randomQuestions[i]][randomAnswers[0]]}");
                        Console.WriteLine($"B) {questions[randomQuestions[i]][randomAnswers[1]]}");
                        Console.WriteLine($"C) {questions[randomQuestions[i]][randomAnswers[2]]}");
                        Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("H) I need --> HELP"); Console.ResetColor();
                        Console.WriteLine($"Correct Answer ==> {questions[randomQuestions[i]][4]}");
                        Console.WriteLine("\n\n");

                        Console.Write("Choose Your Variant : ");
                        string selectionAnswer = Console.ReadLine();

                        if (selectionAnswer.ToLower() == "a" || selectionAnswer.ToLower() == "b" || selectionAnswer.ToLower() == "c"
                            || selectionAnswer.ToLower() == "h")
                        {

                            if (selectionAnswer.ToLower() == "a")
                            {
                                if (questions[randomQuestions[i]][randomAnswers[0]] == questions[randomQuestions[i]][4])
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Your answers is correct : {questions[randomQuestions[i]][4]}");
                                    PlayCorrectAnswerSound();
                                    money = QuestionsValue[i];
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Your answers is wrong : {questions[randomQuestions[i]][randomAnswers[0]]}");
                                    PlayWrongAnswerSound();
                                    Console.Clear();
                                    Console.WriteLine($"\t\t\tYou lost ...\n\t\t\tMoney : {money}");
                                    Console.ResetColor();
                                    questionsFlag = false;
                                }
                            }

                            else if (selectionAnswer.ToLower() == "b")
                            {
                                if (questions[randomQuestions[i]][randomAnswers[1]] == questions[randomQuestions[i]][4])
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Your answers is correct : {questions[randomQuestions[i]][4]}");
                                    PlayCorrectAnswerSound();
                                    money = QuestionsValue[i];
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Your answers is wrong : {questions[randomQuestions[i]][randomAnswers[1]]}");
                                    PlayWrongAnswerSound();
                                    Console.Clear();
                                    Console.WriteLine($"\t\t\tYou lost ...\n\t\t\tMoney : {money}");
                                    Console.ResetColor();
                                    questionsFlag = false;
                                }
                            }

                            else if (selectionAnswer.ToLower() == "c")
                            {
                                if (questions[randomQuestions[i]][randomAnswers[2]] == questions[randomQuestions[i]][4])
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"Your answers is correct : {questions[randomQuestions[i]][4]}");
                                    PlayCorrectAnswerSound();
                                    money = QuestionsValue[i];
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Your answers is wrong : {questions[randomQuestions[i]][randomAnswers[2]]}");
                                    PlayWrongAnswerSound();
                                    questionsFlag = false;
                                }
                            }
                            else if (selectionAnswer.ToLower() == "h")
                            {
                                Console.WriteLine("Your Help Menu");
                                for (int h = 0; h < yourHelps.Length; h++)
                                {
                                    Console.WriteLine($"{h + 1}] {yourHelps[h]}");
                                }
                                Console.Write("Choose Help : ");
                                string selectionHelp = Console.ReadLine();

                                if (usedHelpCount < yourHelps.Length)
                                {

                                    if (selectionHelp == "1")
                                    {
                                        if (!usedHelps[0])
                                        {
                                            usedHelps[0] = true;
                                            usedHelpCount++;

                                            Console.WriteLine("You called a friend for help.");
                                            Console.WriteLine($"Your friend's answer: {questions[randomQuestions[i]][4]}");
                                            Console.WriteLine("Press Enter to continue...");
                                            money = QuestionsValue[i];
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have already used this help. Please choose another help.");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                            continue;
                                        }
                                    }

                                    else if (selectionHelp == "2")
                                    {
                                        if (!usedHelps[1])
                                        {
                                            if (mistakeCount > 0)
                                            {
                                                usedHelps[1] = true;
                                                usedHelpCount++;

                                                Console.WriteLine("You gained a second chance to answer this question.");
                                                Console.WriteLine("Press Enter to continue...");
                                                Console.ReadLine();
                                                mistakeCount--;
                                            }
                                            else
                                            {
                                                Console.WriteLine("You have already used all your chances to make a mistake.");
                                                Console.WriteLine("Press Enter to continue...");
                                                Console.ReadLine();
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have already used this help. Please choose another help.");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                            continue;
                                        }
                                    }


                                    else if (selectionHelp == "3")
                                    {
                                        if (!usedHelps[2])
                                        {
                                            usedHelps[2] = true;
                                            usedHelpCount++;

                                            Console.WriteLine("\n\nYou have chosen the 50:50 help.");



                                            int wA = random.Next(1, 3);
                                            int rr = random.Next(0, 2);
                                            string wrongA = "";
                                            if (rr == 0)
                                            {
                                                if (questions[randomQuestions[i]][randomAnswers[wA]] == questions[randomQuestions[i]][4])
                                                {
                                                    foreach (var item in questions[randomQuestions[i]])
                                                    {
                                                        if (questions[randomQuestions[i]][randomAnswers[wA]] != questions[randomQuestions[i]][4])
                                                        {
                                                            wrongA = item; break;
                                                        }
                                                    }
                                                    Console.WriteLine($"A) {wrongA}");
                                                    Console.WriteLine($"B) {questions[randomQuestions[i]][4]}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"A) {questions[randomQuestions[i]][randomAnswers[wA]]}");
                                                    Console.WriteLine($"B) {questions[randomQuestions[i]][4]}");
                                                }

                                            }
                                            else
                                            {
                                                if (questions[randomQuestions[i]][randomAnswers[wA]] == questions[randomQuestions[i]][4])
                                                {
                                                    foreach (var item in questions[randomQuestions[i]])
                                                    {
                                                        if (questions[randomQuestions[i]][randomAnswers[wA]] != questions[randomQuestions[i]][4])
                                                        {
                                                            wrongA = item; break;
                                                        }
                                                    }
                                                    Console.WriteLine($"A) {questions[randomQuestions[i]][4]}");
                                                    Console.WriteLine($"B) {wrongA}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"A) {questions[randomQuestions[i]][4]}");
                                                    Console.WriteLine($"B) {questions[randomQuestions[i]][randomAnswers[wA]]}");
                                                }
                                            }


                                            Console.Write("Choose Your Variant (A/B): ");
                                            string selection = Console.ReadLine();

                                            if (selection.ToLower() == "a" || selection.ToLower() == "b")
                                            {

                                                if (rr == 0 && selection.ToLower() == "b" || rr == 1 && selection.ToLower() == "a")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine($"Your answer is correct: {questions[randomQuestions[i]][4]}");
                                                    PlayCorrectAnswerSound();
                                                    money = QuestionsValue[i];
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"Your answer is wrong...");
                                                    PlayWrongAnswerSound();
                                                    Console.Clear();
                                                    Console.WriteLine($"\t\t\tYou lost ...\n\t\t\tMoney : {money}");
                                                    Console.ResetColor();
                                                    questionsFlag = false;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid selection."); --i; usedHelps[2] = false;
                                            }

                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have already used this help. Please choose another help.");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                            Console.Clear();
                                            continue;
                                        }
                                    }


                                }
                                else
                                {
                                    Console.WriteLine("You have used all of your help options.");

                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("This variant not found...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.ResetColor(); continue;
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("This variant not found...");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.ResetColor(); continue;
                        }
                        break;

                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t\t\tYou did not win a MILLION $ ...\n\t\t\tMoney you won : {money} $");
                    Console.ResetColor(); break;
                };
            }

            if (questionsFlag)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\tYou won one MILLION $ ...\n\t\t\tMoney you won : {money} $");
                Console.ResetColor();
            }

            Console.WriteLine("\n");
            Console.ReadLine();
        }

        static string[] RemoveHelp(string[] yourHelps, int index)
        {
            string[] destination = new string[yourHelps.Length - 1];
            if (index > 0) { Array.Copy(yourHelps, 0, destination, 0, index); }
            if (index < yourHelps.Length - 1) { Array.Copy(yourHelps, index + 1, destination, index, yourHelps.Length - index - 1); }
            return destination;
        }

        static string[][] MyDatas()
        {
            string[] q1 = { "What is the largest ocean in the world?", "Indian Ocean", "Atlantic Ocean", "Pacific Ocean", "Pacific Ocean" };
            string[] q2 = { "Which planet is the 4th in the Solar System?", "Venus", "Mars", "Jupiter", "Mars" };
            string[] q3 = { "Which planet is also known as the \"Red Planet\"?", "Mars", "Venus", "Neptune", "Mars" };
            string[] q4 = { "Which planet has the largest diameter in the Solar System?", "Venus", "Jupiter", "Uranus", "Jupiter" };
            string[] q5 = { "Which planet is the closest to the Sun?", "Mercury", "Venus", "Mars", "Mercury" };
            string[] q6 = { "Which element is represented by the symbol \"Fe\" in the periodic table?", "Phosphorus", "Iron", "Fluorine", "Iron" };
            string[] q7 = { "Which planet is also called the \"Morning Star\" or the \"Evening Star\"?", "Mars", "Venus", "Neptune", "Venus" };
            string[] q8 = { "What is the largest organ in the human body?", "Lung", "Brain", "Skin", "Skin" };
            string[] q9 = { "Which planet is the fastest spinning in the Solar System?", "Mars", "Jupiter", "Venus", "Venus" };
            string[] q10 = { "Which famous artist painted the artwork \"Mona Lisa\"?", "Leonardo da Vinci", "Pablo Picasso", "Vincent van Gogh", "Leonardo da Vinci" };

            string[][] questions = { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10 };

            return questions;
        }

        static int[] RandomQuestion(Random random)
        {
            int[] arr = new int[10];
            int questionsRow = 0;
            bool flag = true;
            int index = 0;
            int[] allNumber = new int[1] { -1 };
            while (true)
            {

                questionsRow = random.Next(0, 10);
                for (int i = 0; i < allNumber.Length; i++)
                {
                    if (allNumber[i] == questionsRow) { flag = false; break; }
                    flag = true;
                }
                Array.Resize(ref allNumber, allNumber.Length + 1);
                allNumber[allNumber.Length - 1] = questionsRow;
                if (flag)
                {
                    arr[index++] = questionsRow;
                }
                if (index == 10) break;
            }
            return arr;
        }

        static int[] RandomAnswers(Random random)
        {
            int[] arr = new int[3];
            int answersRow = 0;
            bool flag = true;
            int index = 0;
            int[] allNumber = new int[1] { -1 };
            while (true)
            {

                answersRow = random.Next(1, 4);
                for (int i = 0; i < allNumber.Length; i++)
                {
                    if (allNumber[i] == answersRow) { flag = false; break; }
                    flag = true;
                }
                Array.Resize(ref allNumber, allNumber.Length + 1);
                allNumber[allNumber.Length - 1] = answersRow;
                if (flag)
                {
                    arr[index++] = answersRow;
                }
                if (index == 3) break;
            }
            return arr;
        }

        static void PlayCorrectAnswerSound()
        {
            Console.Beep(523, 500);
            System.Threading.Thread.Sleep(100);
            Console.Beep(659, 500);
        }

        static void PlayWrongAnswerSound()
        {
            Console.Beep(330, 500);
            System.Threading.Thread.Sleep(100);
            Console.Beep(277, 500);
        }
    }
}


