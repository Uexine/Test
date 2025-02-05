using System.Text;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Regex regex = new Regex(@"^[a-zA-Z]+$");
        if (input == input.ToLower() && regex.IsMatch(input))
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            string processedString = Process(input);
            Console.WriteLine(processedString);
            dict = Count(processedString);
            foreach (var ch in dict)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value}");
            }
            string maxSubstring = FindSubstring(processedString);
            Console.WriteLine($"Максимальная подстрока между гласными: {maxSubstring}");
            char [] characters = input.ToCharArray();
            QuickSort(characters,0,characters.Length-1);
            StringBuilder sortedString = new StringBuilder();

            foreach( char ch in characters)
            {
                sortedString.Append(ch);

            }
            Console.WriteLine($"{sortedString.ToString()}");
        }
        else
        {
            List<char> invalidCharacters = new List<char>();

            foreach (char character in input)
            {
                if (!char.IsLetter(character) || !((character >= 'a' && character <= 'z') || (character >= 'A' && character <= 'Z')))
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
    static Dictionary<char, int> Count(string str)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
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
        int length = str.Length;
        if (length % 2 == 0)
        {
            int center = length / 2;
            string first = Reverse(str.Substring(0, center));
            string last = Reverse(str.Substring(center));
            return first + last;
        }
        else
        {
            string reverse = Reverse(str);
            return reverse + str;
        }
    }
    static string Reverse(string str)
    {
        char[] array = str.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
    static string FindSubstring(string str)
    {
        string vowels = "aeiouy";
        int maxLength = 0;
        string maxSubstring = "";

        for (int i = 0; i < str.Length; i++)
        {
            if (vowels.Contains(str[i]))
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (vowels.Contains(str[j]))
                    {
                        string substring = str.Substring(i, j - i + 1);
                        if (substring.Length > maxLength)
                        {
                            maxLength = substring.Length;
                            maxSubstring = substring;
                        }
                    }
                }
            }
        }

        return maxSubstring;
    }
    static void QuickSort(char[] array,int start,int end)
    {
        if(start>=end)
        {
            return;
        }
        int pivotIndex = Partition(array,start,end);
        QuickSort(array,start,pivotIndex-1);
        QuickSort(array,pivotIndex+1,end);
    }
    static int Partition(char[] array,int start,int end)
    {
        char pivot = array[end];
        int i = start -1;
        for(int j=start;j<end;j++)
        {
            if(array[j]<=pivot)
            {
                i++;
                Swap(ref array[i],ref array[j]);
            }
        }
        Swap(ref array[i+1], ref array[end]);
        return i+1;
    }
    static void Swap (ref char a,ref char b)
    {
        char temp=a;
        a=b;
        b=temp;
    }
}

