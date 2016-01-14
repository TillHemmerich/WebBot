using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBot
{
    public class accounts
    {
        private static String userName1 = "";
        private static String passWord1 = "";
        private static int worlD;

        public String username1
        {
            get { return userName1; }
            set { userName1 = value; }
        }

        public String password1
        {
            get { return passWord1; }
            set { passWord1 = value; }
        }

        public int world
        {
            get { return worlD; }
            set { worlD = value; }
        }
    }
}
