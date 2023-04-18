using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace modul4.Models
{
    public class Person : ObservableObject
    {
        private string name;
        public string Name 
        { 
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private int personalRecord;
        public int PersonalRecord
        {
            get { return personalRecord; }
            set { SetProperty(ref personalRecord, value); }
        }
        private int thisYearBest;
        public int ThisYearBest
        {
            get { return thisYearBest; }
            set { SetProperty(ref thisYearBest, value); }
        }
        private bool hasLicense;
        public bool HasLicense
        {
            get { return hasLicense; }
            set { SetProperty(ref hasLicense, value); }
        }
        private string club;
        public string Club
        {
            get { return club; }
            set { SetProperty(ref club, value); }
        }
        private int raceNumber;
        public int RaceNumber
        {
            get { return raceNumber; }
            set { SetProperty(ref raceNumber, value); }
        }
        private int marketValue;
        public int MarketValue
        {
            get
            {
                return personalRecord * thisYearBest;
            }
        }

        public Person GetCopy()
        {
            return new Person
            {
                Name = this.name,
                PersonalRecord = this.personalRecord,
                ThisYearBest = this.thisYearBest,
                HasLicense = this.hasLicense,
                Club = this.club,
                RaceNumber = this.raceNumber,
                marketValue = this.marketValue,
            };
        }
    }
}
