using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Squadmakers.Api.Models
{
    public class MathematicsModel
    {
        private static readonly MathematicsModel _instance = new MathematicsModel();

        private MathematicsModel() { }

        public static MathematicsModel Instance
        {
            get
            {
                return _instance;
            }
        }

        public int GetCommonMultiple(List<int> array)
        {
            int[] numbers = array.ToArray();
            int maximum = 1;
            int tmp = 0;
            foreach (int b in numbers)
            {
                numbers[tmp] = Math.Abs(b);
                maximum = maximum * numbers[tmp];
                tmp++;
            }
            int result = 1;
            for (int i = 2; i <= maximum; i++)
            {
                bool a = true;
                foreach (int b in numbers)
                {
                    if (i % b != 0)
                    {
                        a = false;
                    }
                }
                if (a == true)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public int SumNumber(int number)
        {
            return number + 1;
        }
    }
        
}