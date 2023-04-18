using Microsoft.Toolkit.Mvvm.Messaging;
using modul4.Models;
using modul4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4.Logic
{
    internal class TournamentLogic : ILogic
    {
        IList<Person> racers;
        IList<Person> tournament;
        readonly IMessenger messenger;
        readonly IPersonDisplayService displayService;

        public TournamentLogic(IMessenger messenger, IPersonDisplayService displayService)
        {
            this.messenger = messenger;
            this.displayService = displayService;
        }

        public void SetupCollections(IList<Person> racers, IList<Person> tournament)
        {
            this.racers = racers;
            this.tournament = tournament;
        }

        //public double MartkeValue
        //{
        //    get
        //    {
        //        return 
        //    }
        //}

        public void AddToTournament(Person person)
        {
            tournament.Add(person);
            messenger.Send("Person added", "PersonInfo");
        }

        public void RemoveFromTournament(Person person)
        {
            tournament.Remove(person);
            messenger.Send("Person removed", "PersonInfo");
        }

        public void DisplayRacer(Person person)
        {
            displayService.Display(person);
        }



    }
}
