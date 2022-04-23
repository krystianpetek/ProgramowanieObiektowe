using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfTheWeek
{
    internal class DayOfTheWeek : IEnumerable
    {
        private string[] dayOfTheWeek = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < dayOfTheWeek.Length; i++)
            {
                yield return dayOfTheWeek[i];
            }
        }
    }
}
