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

        for (int i = 0; i < symbol.Length; i++)
        {
            for (int j = 0; j < symbol.Length; j++)
            {
                for (int k = 0; k < symbol.Length; k++)
                {
                    for (int l = 0; l < symbol.Length; l++)
                    {
                        char[] chars = { symbol[i], symbol[j], symbol[k], symbol[l] };
                        string txt = new string(chars);
                        Console.WriteLine(txt);
                        if (StringSha256Hash(txt) == hash)
                        {
                            return txt;
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
