public class First
{
    static void Main(string [] args)
    {
        string input = Console.ReadLine();
        string process=Process(input);
        Console.WriteLine(process);

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
