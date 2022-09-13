using System;
using System.Text;
using System.Text.RegularExpressions;


class CountFrequancies{

    static void Main(){
        String path = "C:\\Users\\Baataoui Youssef\\Desktop\\test.txt";
        String content = File.ReadAllText(path, Encoding.UTF8);
        String newContent1 = Between(content, "START", "END");

        var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        countWordsInFile(newContent1, words);

        Console.WriteLine("*****Created by Youssef*****");
        foreach (var item in words.OrderByDescending(x=>x.Value).Take(20)) {
            Console.WriteLine("{0} : {1}", item.Key, item.Value);
        }
    }

    //This a funtion that returns just the text we want 
    public static string Between(string STR , string FirstString, string LastString)
    {       
        string FinalString;     
        int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
        int Pos2 = STR.IndexOf(LastString);
        FinalString = STR.Substring(Pos1, Pos2 - Pos1);
        return FinalString;
    }

    // This a function that count word's frequency in a string and return a dictionary that hold words with thier frequancy. 
    private static Dictionary<string, int> countWordsInFile(string str, Dictionary<string, int> words)
    {
        var content = str;

        var wordPattern = new Regex(@"\w+");

        foreach (Match match in wordPattern.Matches(content))
        {
            if (!words.ContainsKey(match.Value))
                words.Add(match.Value, 1);
            else
                words[match.Value]++;
        }

        return words;
    }
   
}




