using modul4.Models;
using System.Collections.Generic;

namespace modul4.Logic
{
    public interface ILogic
    {
        void AddToTournament(Person person);
        void DisplayRacer(Person person);
        void RemoveFromTournament(Person person);
        void SetupCollections(IList<Person> racers, IList<Person> tournament);
    }
}