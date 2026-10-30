using System;
using System.Collections.Generic; 

//Angel Panti Semifinals Activity 1
class Program
{
    static void Main()
    {
        Console.Write("Enter your brackets: "); //maglagay ng input si user
        string input = Console.ReadLine() ?? ""; //readline self explanatory, kukunin yung input ni user, yung ?? "" para pag walang nilagay si user na input mag n-null lang sya

        Stack<char> bracketStack = new Stack<char>(); //eto yung stact para sa brackets
        bool isValid = true; //para macheck yung input kung valid

        foreach (char c in input) // yung c ay temporary lang na storage para sa loop
        {
            if (c == '(' || c == '[' || c == '{') 
            {
                bracketStack.Push(c); //kapag ([{ maiistore sya sa bracketStack na ginawa natin kanina
            }
            else if (c == ')' || c == ']' || c == '}') {
                if (bracketStack.Count == 0)
                {
                    isValid = false; //mabilis na check kung )}] ang nilagay ni use magiging false isValid tapos yung break mag skip na sya pababa pagkatapos ng loop
                    break;
                }

                char topofstack = bracketStack.Pop(); /* Kapag naman )]} ang nilagay ni user, mag p-pop mula sa bracketStack
                halimbawa may laman ang bracketStack na (, {, [ tapos and c na kasunod na nilagay ni user ay ] mula sa (){}[). Pag di sya nagtugma, magiging false yung
                isValid */

                if (c == ')' && topofstack != '(') {isValid = false; break;}
                if (c == '}' && topofstack != '{') {isValid = false; break;}
                if (c == ']' && topofstack != '[') {isValid = false; break;}

                /*kahit isa lang angdi magtugma sa mga brackets, magiging false na agad ang isValid kaya di na valid ang brackets ni user
                at mag break na agad para mapunta na sa labas ng loop*/
            }
        }

        if (bracketStack.Count > 0)
        {
            isValid = false; //pag walang laman ang ang stack magiging false na agad ang brackets
        }

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine($"Your brackets '{input}' are invalid! Empty!"); //output kapag walang laman ang brackets
        }
        else if (isValid && input.Length < 3)
        {
            Console.WriteLine($"Your brackets '{input}' are valid!"); //output kapag valid ang brackets
        }
        else if (isValid && input.Length > 2)
        {
            Console.WriteLine($"Your brackets '{input}' are valid! Perfectly Nested!"); //output kapag valid ang brackets at more than one ang magkatugma at kapag may saysay ang brackets
        }
        else if (!isValid && input.Length < 3)
        {
            Console.WriteLine($"Your brackets '{input}' are invalid! Mismatch!"); //output kapag invalid ang brackets
        }
        else if (!isValid && input.Length > 2)
        {
            Console.WriteLine($"Your brackets '{input}' are invalid! Incorrect Closing Order!"); //output kapag invalid ang brackets at more than one ang nahanap at di makabuluhan ang brackets
        }
    
    }
}
