using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

Stopwatch stopwatch = new Stopwatch();
Console.Write("Enter your password hash: ");
string password = Console.ReadLine();

stopwatch.Start();
var key = Hack(password);
stopwatch.Stop();
Console.WriteLine("Your password " + key);
Console.WriteLine("Time elapsed" + stopwatch.ElapsedMilliseconds);


string Hack(string hash)
{
    char[] symbol = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890".ToArray();

    {
        for (int e = 0; e < symbol.Length; e++)
        {
            for (int z = 0; z < symbol.Length; z++)
            {
                for (int j = 0; j < symbol.Length; j++)
                {
                    for (int i = 0; i < symbol.Length; i++)
                    {


                        char[] chars = { symbol[i], symbol[j], symbol[z], symbol[e] };
                        string txt = new string(chars);
                        Console.WriteLine(txt);
                        if (StringSha256Hash(txt) == hash)
                        { return txt; }



                    }
                }
            }
        }
    }
    return null;
}


static string StringSha256Hash(string text) =>
  string.IsNullOrEmpty(text)
    ? string.Empty
    : BitConverter
      .ToString(new SHA256Managed().ComputeHash(
        Encoding.UTF8.GetBytes(text))).Replace("-", string.Empty);
