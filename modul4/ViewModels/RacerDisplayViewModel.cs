using modul4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4.ViewModels
{
    public class RacerDisplayViewModel
    {
        public Person Actual { get; set; }

        public void Setup(Person person)
        {
            this.Actual = person;
        }

        public RacerDisplayViewModel()
        {

        }
    }
}
