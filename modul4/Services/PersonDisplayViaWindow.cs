using modul4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4.Services
{
    internal class PersonDisplayViaWindow : IPersonDisplayService
    {
        public void Display(Person person)
        {
            new RacerDisplay(person).ShowDialog();
        }
    }
}
