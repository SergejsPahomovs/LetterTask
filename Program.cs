// See https://aka.ms/new-console-template for more information
using LetterTask;

Console.WriteLine("Enter String");
string str = Console.ReadLine();
string newStr = string.Empty;
if (!string.IsNullOrWhiteSpace(str))
{
    if (str.Length > 1)
    {
        newStr = Approach.Standard(str);
    }
    else
    {
        newStr = str;
    }
}
Console.WriteLine($"Output string : {newStr}");
Console.ReadLine();

