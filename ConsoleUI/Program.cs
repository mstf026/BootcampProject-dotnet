using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> x = new List<string>();   
            x.Add("1");   
            x.Add("2");
            x.Add("C");
            x.Add("13");
            x.Add("D");
            x.Add("+");
            int count = 0;
            List<int> listindex = new List<int>();   



            for(int i = 0; i< x.Count; i++)
            {
                if(x[i].ToLower().StartsWith("c"))
                {
                    listindex.Remove(listindex[listindex.Count - 1]);
                }
                else if (x[i].ToLower().StartsWith("d"))
                {
                    listindex.Add(listindex[listindex.Count - 1] * 2);
                }
                else if (x[i].StartsWith("+"))
                {
                    listindex.Add(Convert.ToInt32(listindex[listindex.Count - 1]) + Convert.ToInt32(listindex[listindex.Count - 2]));
                }
                else if (Char.IsNumber(x[i].ToCharArray()[0]))
                {
                    listindex.Add(Convert.ToInt32(x[i]));
                }
            }
            foreach (var i in listindex)
            {
                count = count + i;
            }

            Console.WriteLine(count);

            

        }
    }
}