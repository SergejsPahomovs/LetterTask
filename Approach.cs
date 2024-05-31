using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterTask
{
    internal static class Approach
    {
        public static string Standard(string str)
        {
            int startIndex = 0;
            int currentIndex = 1;
            char startSymbol = str[startIndex];
            string newStr = string.Empty;
            bool continueToWork = true;
            bool diffCases =false ,lowerCase =false , upperCase =false;
            char currentSymbol = str[currentIndex];

            while (continueToWork) 
            {
                if (currentIndex < str.Length)
                {
                    currentSymbol = str[currentIndex];
                    if (Char.ToLower(startSymbol).Equals(Char.ToLower(currentSymbol)))
                    {
                        if (startSymbol.Equals(currentSymbol))
                        {
                            if (Char.IsLower(currentSymbol))
                            {
                                lowerCase = true;
                            }
                            else
                            {
                                upperCase = true;
                            }
                        }
                        else
                        {
                            diffCases = true;
                        }
                    }
                }

                if (!Char.ToLower(startSymbol).Equals(Char.ToLower(currentSymbol))||currentIndex == str.Length)
                {
                    string tmpStr = string.Empty;
                    int charCount = currentIndex - startIndex;
                    if (charCount == 1 || charCount == 0)
                    {
                        tmpStr = startSymbol.ToString();
                    }
                    else if (charCount == 2)
                    {
                        if (diffCases)
                        {
                            tmpStr = $"[{str.Substring(startIndex, charCount)}]";
                        }
                        else if (lowerCase)
                        {
                            tmpStr = Char.ToUpper(startSymbol).ToString();
                        }
                        else
                        {
                            tmpStr = $"[{str[0].ToString()}]";
                        }
                    }
                    else
                    {
                        if (diffCases)
                        {
                            if (Char.IsLower(startSymbol))
                            {
                                tmpStr = $"[{charCount}{startSymbol}{Char.ToUpper(startSymbol)}]";
                            }
                            else
                            {
                                tmpStr = $"[{charCount}{startSymbol}{Char.ToLower(startSymbol)}]";
                            }
                        }
                        else if (lowerCase)
                        {
                            tmpStr = $"{charCount}{Char.ToUpper(startSymbol)}";
                        }
                        else
                        {
                            tmpStr = $"[{charCount}{Char.ToUpper(startSymbol)}]";
                        }
                    }
                    newStr += tmpStr;
                    startIndex = currentIndex;
                    if (currentIndex < str.Length)
                    {
                        startSymbol = str[currentIndex];
                    }
                    diffCases = false;
                    lowerCase = false;                    
                }

                currentIndex++;
                if (currentIndex == str.Length+1) { continueToWork = false; }
            }
            return newStr;
        }
    }

    private static string GetResult(string str, int startIndex, int endIndex)
    {
        string newStr = string.Empty;
        int count = endIndex - startIndex;
        bool lower = false;
        bool upper = false;

        for (int i = startIndex; i < endIndex;)
        {
            if (!char.IsLower(str[i]))
            {
                lower = true;
            }
            else
            {
                upper = true;
            }

            if (lower && upper)
            {
                break;
            }
        }

        if (count == 0 || count == 1)
        {
            newStr = str.Substring(startIndex, 1);
        }
        else if (count == 2) 
        {
            if (lower && upper)
            {
                newStr = $"[{str.Substring(startIndex, count)}]";
            }
            else if (lower)
            {
                newStr = str.Substring(startIndex,1).ToUpper();
            }
            else
            {
                newStr = $"[{str.Substring(startIndex, 1)}]";
            }
        }

        return newStr;
    }

    public async Task<string> AsyncApproach(string str)
    {
        int beginIndex = 0;
        string newStr = string.Empty;
        List<Task<string>> tasks = new List<Task<string>>();


        for (int i = 1; i<=str.Length; i++)
        {
            if (!str.Substring(beginIndex, 1).Equals(str.Substring(i, 1), StringComparison.OrdinalIgnoreCase))
            {
                //tasks.Add(Task<string>.Run(GetResult(str,beginIndex,i)));
            }
        }

        Task.WaitAll(tasks.ToArray());

        foreach (var (task, index) in tasks.Select((task, index) => (task, index)))
        {
            newStr += task.Result;
        }

        return newStr;
    }
}
