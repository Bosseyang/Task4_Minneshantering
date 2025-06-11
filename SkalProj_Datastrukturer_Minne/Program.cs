#region
//1. Q:     Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess 
//          grundläggande funktion 
//   A:     Stacken är självunderhållen och lagrar information som staplade lådor,
//          vi måste "lyfta" de övre lådorna för att komma åt de undre.
//          Heapen, där ligger all information utspritt och vi har till gång till allt
//          bara vi vet vad vi vill ha, där hanteras information vi ej behöver av Garbage Collectorn

//2. Q:     Vad är Value Types respektive Reference Types och vad skiljer dem åt? 
//   A:     Value Types är inbyggda variabel typer i System.ValueType så som tex. bool, int,
//          float etc. Dessa lagras där de deklareras, deklareras de i en class lagras de på heapen tex.
//          Reference Types så som class, interface, object osv. lagras alltid på Heapen

//3. Q:     Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den 
//          andra returnerar 4, varför? 
//   A:     I första exemplet ReturnValue(): Vi använder oss av värdetypen int här, då uppdaterar
//          vi ej x där vi uppdaterar y till 4 då vi endast kopierar över värdet av x till y (y=x)
//          I det andra exemplet ReturnValue2(): Här använder vi en referenstyp MyInt, det betyder
//          att när vi har y=x så pekar både y och x på samma objekt i minnet, uppdaterar vi
//          y.MyValue = 4 så ändrar vi även på x.MyValue då det pekar på samma objekt.
#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
            List<string> list = new List<string>();
            Console.WriteLine("Please enter: \n+<value> to add\n-<value> " +
                    "to remove\n0 to exit to main menu");
            while (true)
            {

                string input = Console.ReadLine() ?? string.Empty;

                //Exits the loop if the user input is 0.
                if (input == "0") break;

                //Use first character in string
                char inputCommand = input[0];
                string value = input.Substring(1);

                switch (inputCommand)
                {
                    case '+':
                        list.Add(value);
                        break;
                    case '-':
                        list.Remove(value);
                        break;
                    default:
                        Console.WriteLine("Please only enter + to add or - to remove");
                        continue;

                }
                Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");

            }

        }

        #region
        //      ---- QnA ----
        //2.Q.  När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
        //  A.  Listans kapacitet ökar för varje gång den nuvarande kapaciteten överskrids
        //       
        //3.Q.  Med hur mycket ökar kapaciteten? 
        //  A.  Exponentiellt med faktor 2 (2^n) och börjar med 4 i kapacitet, alltså blir kapaciteten 4, 8, 16, 32 osv.
        //4.Q.  Varför ökar inte listans kapacitet i samma takt som element läggs till? 
        //  A.  Då omallokering kostar prestanda så allokeras de vanligtvist exponentiellt varje gång kapaciteten är nådd
        //5.Q.  Minskar kapaciteten när element tas bort ur listan? 
        //  A.  Nej, de minskar ej då de redan är allokerade
        //6.Q.  När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
        //  A.  Arrays är fördelaktiga då man från början vet antal element man behöver jobba med
        //      Då kan man "Förallokera" antalet platser i arrayen.
        #endregion

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> queue = new Queue<string>();
            Console.WriteLine("Please enter: \n+<name> to Enqueue\n- " +
        "to dequeue\n0 to exit.");

            while (true)
            {
                string input = Console.ReadLine() ?? string.Empty;
                //Exits the loop if the user input is 0.
                if (input == "0") break;

                //Use first character in string
                char inputCommand = input[0];
                string name = input.Substring(1);

                switch (inputCommand)
                {
                    case '+': //Enqueue
                        queue.Enqueue(name);
                        break;
                    case '-': //Dequeue
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("Queue is empty, please enqueue with input:" +
                                "+<Name>, or exit to main menu with 0");
                            break;
                        }

                        queue.Dequeue();
                        break;
                    default:
                        Console.WriteLine("Please input +<Name> to Enqueue or - to Dequeue");
                        continue;

                }
                Console.WriteLine($"Queue: " + string.Join(", ", queue));
            }
        }
//1. Simulera följande kö på papper: 
//a.    ICA öppnar och kön till kassan är tom
//b.    Kalle ställer sig i kön
//c.    Greta ställer sig i kön
//d.    Kalle blir expedierad och lämnar kön
//e.    Stina ställer sig i kön
//f.    Greta blir expedierad och lämnar kön
//g.    Olle ställer sig i kön
//h.    ...


//a.
//b.    +Kalle  -> [Kalle]
//c.    +Greta  -> [Kalle, Greta]
//d.    -	    -> [Greta]
//e.    +Stina  -> [Greta, Stina]
//f.    -	    -> [Stina]
//g.    +Olle   -> [Stina, Olle]
//h.    ...


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            while (true)
            {
                Console.WriteLine("Press enter to continue, 0 to exit to main menu");
                string input = Console.ReadLine() ?? string.Empty;
                //Exits the loop if the user input is 0.
                if (input == "0") break;
                ReverseText();
            }

        }
        static void ReverseText()
        {
            Console.WriteLine("Please enter a string to reverse: ");
            Stack<char> stack = new Stack<char>();
            string input = Console.ReadLine() ?? string.Empty;
            StringBuilder builder = new StringBuilder();
            string reversedString;
            
            foreach (char c in input) 
            {
                stack.Push(c);
            }

            while(0<stack.Count)
            {
                //Building and saving the stack back to a string, but reversed using pop.
                builder.Append(stack.Pop());
                //Console.Write(stack.Pop());
            }
            reversedString = builder.ToString();
            Console.WriteLine($"\nThe reversed string: {reversedString}");

        }
//1.        Simulera ännu en gång ICA-kön på papper.Denna gång med en stack.Varför är det
//          inte så smart att använda en stack i det här fallet? 
//1.Svar:   Det är inte så rättvist att de som ställer sig i kön sist, får hjälp först.
//a.ICA öppnar och kön till kassan är tom

//a.
//b. +Kalle -> [Kalle]
//c. +Greta -> [Kalle, Greta]
//d. -	  -> [Kalle]
//e. +Stina -> [Kalle, Stina]
//f. -	  -> [Kalle]
//g. +Olle  -> [Kalle, Olle]
//h. ...



        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

