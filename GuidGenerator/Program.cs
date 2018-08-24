using System.IO;
using System.Text;

namespace GuidGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Guid.NewGuid());
            //Console.WriteLine(new DateTimeOffset(DateTime.Now));
            //Console.WriteLine(float.Parse("aaaa"));

            foreach(var f in new DirectoryInfo("D:/Code/Temp_TS/ESB/EESB/EESB-API").GetFiles("*.cs", SearchOption.AllDirectories))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string s = File.ReadAllText(f.FullName, Encoding.GetEncoding(936));
                File.WriteAllText(f.FullName, s, Encoding.UTF8);
            }
        }
    }
}
