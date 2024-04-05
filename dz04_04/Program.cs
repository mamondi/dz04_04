using System;

//повністю чатгпт
namespace dz04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = "{}[]";
            string input2 = "(())";
            string input3 = "[{}]";
            string input4 = "[}";
            string input5 = "[[{]}]";

            Console.WriteLine($"Is '{input1}' valid: {input1.IsValidBrackets()}");
            Console.WriteLine($"Is '{input2}' valid: {input2.IsValidBrackets()}");
            Console.WriteLine($"Is '{input3}' valid: {input3.IsValidBrackets()}");
            Console.WriteLine($"Is '{input4}' valid: {input4.IsValidBrackets()}");
            Console.WriteLine($"Is '{input5}' valid: {input5.IsValidBrackets()}");
        }
    }
}
