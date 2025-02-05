using System.Text.RegularExpressions;
public class First
{
    static void Main(string [] args)
    {
        string input = Console.ReadLine();
        Regex regex = new Regex ("^[a-zA-Z]+$");
        if(input==input.ToLower() && regex.IsMatch(input))
        {
        Dictionary<char,int> dict = new Dictionary<char,int>();
        string process=Process(input);
        Console.WriteLine(process);
        dict = Count(process);
        foreach(var ch in dict)
        {
        Console.WriteLine($"{ch.Key}: {ch.Value}");
        }
        }
        else
        {
            List<char> invalidCharacters = new List<char>();

            foreach (char character in input)
            {
                if (!char.IsLower(character) || !((character >= 'a' && character <= 'z') || (character >= 'A' && character <= 'Z')))
                {
                    invalidCharacters.Add(character);
                }
            }

            if (invalidCharacters.Count > 0)
            {
                Console.WriteLine("Неправильные символы: " + string.Join(", ", invalidCharacters));
            }
        }

    }
    static Dictionary<char,int> Count (string str)
    {
        Dictionary<char,int> dict = new Dictionary<char,int>();
        foreach (char ch in str)
        {
            if (dict.ContainsKey(ch))
            {
                dict[ch]++;
            }
            else
            {
                dict.Add(ch, 1);
            }
        }
        return dict;
    }
    static string Process(string str)
    {
        int length= str.Length;
        if(length%2==0)
        {
            int center=length/2;
            string first = Reverse(str.Substring(0,center));
            string last =Reverse(str.Substring(center));
            return first+last;
        }
        else
        {
            string reverse=Reverse(str);
            return reverse+str;
        }
    }
    static string Reverse(string str)
    {
        char[] array= str.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}

