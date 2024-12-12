using System.Text;

StringBuilder sb = new StringBuilder("123");
StringBuilder sb2 = sb;
sb2[1] = 'q';
Console.WriteLine(sb.ToString());