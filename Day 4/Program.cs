using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

class XmasCounter
{
    public static List<string> readFile(string path)
    {
        string line;
        List<string> lines = new List<string>() { };
        try
        {
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        return lines;
    }

    public static int getMASCount(List<string> lines)
    {
        int count = 0;
        int a = 0;
        foreach (string line in lines)
        {
            int i = 0;
            foreach (char c in line)
            {
                if (c.Equals('A'))
                {
                    if (a > 0 && a < lines.Count() - 1 && i > 0 && i < (line.Length - 1)
                    && lines[a - 1][i - 1].Equals('M')
                    && lines[a + 1][i + 1].Equals('S')
                    && lines[a + 1][i - 1].Equals('M')
                    && lines[a - 1][i + 1].Equals('S'))
                    {
                        count++;
                        Console.WriteLine("Found on line " + (a + 1));
                    }
                    if (a > 0 && a < lines.Count() - 1 && i > 0 && i < (line.Length - 1)
                    && lines[a - 1][i - 1].Equals('M')
                    && lines[a + 1][i + 1].Equals('S')
                    && lines[a - 1][i + 1].Equals('M')
                    && lines[a + 1][i - 1].Equals('S'))
                    {
                        count++;
                        Console.WriteLine("Found on line " + (a + 1));
                    }
                    if (a > 0 && a < lines.Count() - 1 && i > 0 && i < (line.Length - 1)
                    && lines[a - 1][i - 1].Equals('S')
                    && lines[a + 1][i + 1].Equals('M')
                    && lines[a - 1][i + 1].Equals('M')
                    && lines[a + 1][i - 1].Equals('S'))
                    {
                        count++;
                        Console.WriteLine("Found on line " + (a + 1));
                    }
                    if (a > 0 && a < lines.Count() - 1 && i > 0 && i < (line.Length - 1)
                    && lines[a - 1][i - 1].Equals('S')
                    && lines[a + 1][i + 1].Equals('M')
                    && lines[a - 1][i + 1].Equals('S')
                    && lines[a + 1][i - 1].Equals('M'))
                    {
                        count++;
                        Console.WriteLine("Found on line " + (a + 1));
                    }
                }
                i++;
            }
            a++;
        }

        return count;
    }

    public static int getXMASCount(List<string> lines)
    {
        int count = 0;
        int a = 0;
        foreach (string line in lines)
        {
            int i = 0;
            foreach (char c in line)
            {
                if (c.Equals('X'))
                {
                    if (i > 2 && line[i - 3].Equals('S') && line[i - 2].Equals('A') && line[i - 1].Equals('M'))
                    {
                        count++; // BACKWARDS
                        Console.WriteLine("Found BACKWARDS on line " + (a + 1));
                    }
                    if (i < (line.Length - 3) && line[i + 1].Equals('M') && line[i + 2].Equals('A') && line[i + 3].Equals('S'))
                    {
                        count++; // FORWARDS
                        Console.WriteLine("Found FORWARDS on line " + (a + 1));
                    }
                    if (a > 2 && lines[a - 1][i].Equals('M') && lines[a - 2][i].Equals('A') && lines[a - 3][i].Equals('S'))
                    {
                        count++; // UP
                        Console.WriteLine("Found UP on line " + (a + 1));
                    }
                    if (a < lines.Count() - 3 && lines[a + 1][i].Equals('M') && lines[a + 2][i].Equals('A') && lines[a + 3][i].Equals('S'))
                    {
                        count++; // DOWN
                        Console.WriteLine("Found DOWN on line " + (a + 1));
                    }
                    if (a > 2 && i > 2 && lines[a - 1][i - 1].Equals('M') && lines[a - 2][i - 2].Equals('A') && lines[a - 3][i - 3].Equals('S'))
                    {
                        count++; // DIAG UP LEFT
                        Console.WriteLine("Found UP DIAG LEFT on line " + (a + 1));
                    }
                    if (a > 2 && i < (line.Length - 3) && lines[a - 1][i + 1].Equals('M') && lines[a - 2][i + 2].Equals('A') && lines[a - 3][i + 3].Equals('S'))
                    {
                        count++; // DIAG UP RIGHT
                        Console.WriteLine("Found UP DIAG RIGHT on line " + (a + 1));
                    }
                    if (a < lines.Count() - 3 && i > 2 && lines[a + 1][i - 1].Equals('M') && lines[a + 2][i - 2].Equals('A') && lines[a + 3][i - 3].Equals('S'))
                    {
                        count++; // DIAG DOWN LEFT
                        Console.WriteLine("Found DOWN DIAG LEFT on line " + (a + 1));

                    }
                    if (a < lines.Count() - 3 && i < (line.Length - 3) && lines[a + 1][i + 1].Equals('M') && lines[a + 2][i + 2].Equals('A') && lines[a + 3][i + 3].Equals('S'))
                    {
                        count++; // DIAG DOWN RIGHT
                        Console.WriteLine("Found DOWN DIAG RIGHT on line " + (a + 1));
                    }
                }
                i++;
            }
            a++;
        }

        return count;
    }

    public static void Main()
    {
        Console.WriteLine("Hello World");
        List<string> lines = readFile("data.txt");
        int count = getMASCount(lines);
        Console.WriteLine("Count of X-MAS: " + count);
    }
}