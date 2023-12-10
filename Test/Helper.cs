using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Test
{
    public class Helper
    {
        public static Frame s_frame;
        public static Users s_user;
        private static TrainContext s_rainContext;
        public static TrainContext GetContext()
        {
            if (s_rainContext == null)
                s_rainContext = new TrainContext();
            return s_rainContext;
        }
    }
}
