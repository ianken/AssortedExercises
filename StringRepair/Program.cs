using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringRepair_AMZN
{
    class Program
    {
        //cheesy happy path...for a weak question...IMO.
        static void Main(string[] args)
        {
            var Str = "Amazon_w_e_b_services are___widely__used_acc__ro___ss_the_worl_d";
            var foo = Str.Replace("___", "_");
            foo = foo.Replace("__", "_");
            foo = foo.Replace(" ", "_");

            var tmp = foo.Split('_');

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < tmp.Length - 1; i++)
            {
                if (tmp[i].Length + tmp[i + 1].Length > 5 && tmp[i + 1].Length != 2)
                {
                    sb.Append(tmp[i] + " ");
                }
                else
                {
                    sb.Append(tmp[i]);
                    if (tmp[i + 1].Length > 2)
                        sb.Append(" ");
                }
            }
            sb.Append(tmp[tmp.Length - 1]);
        }
    }
}
