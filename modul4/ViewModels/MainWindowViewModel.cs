using modul4.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using modul4.Logic;
using System.Collections.Generic;
using System.IO;
using System;

namespace modul4.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        readonly ILogic logic;
        public ObservableCollection<Person> Racers { get; set; }
        public ObservableCollection<Person> Tournament { get; set; }

        private Person selectedFromRacers;

        public Person SelectedFromRacers
        {
            get { return selectedFromRacers; }
            set
            {
                SetProperty(ref selectedFromRacers, value);
                (AddToTournamentCommand as RelayCommand).NotifyCanExecuteChanged();
                (DisplayRacerCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Person selectedFromTournament;

        public Person SelectedFromTournament
        {
            get { return selectedFromTournament; }
            set
            {
                SetProperty(ref selectedFromTournament, value);
                (RemoveFromTournamentCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        
        private Person saveName;

        public Person SaveName
        {
            get { return saveName; }
            set
            {
                SetProperty(ref saveName, value);
                (SaveTrounamentCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Person saveDate;

        public Person SaveDate
        {
            get { return saveDate; }
            set
            {
                SetProperty(ref saveDate, value);
                (SaveTrounamentCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToTournamentCommand { get; set; }
        public ICommand DisplayRacerCommand { get; set; }
        public ICommand RemoveFromTournamentCommand { get; set; }
        public ICommand LoadRacersCommand { get; set; }
        public ICommand SaveTrounamentCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<ILogic>())
        {
        }

        public void LoadRacers(string path)
        {
            foreach (var item in File.ReadLines(path))
            {
                Racers.Add(new Person
                {
                    Name = item.Split(':')[0],
                    PersonalRecord = int.Parse(item.Split(':')[1]),
                    ThisYearBest = int.Parse(item.Split(':')[2]),
                    HasLicense = bool.Parse(item.Split(':')[3]),
                    Club = item.Split(':')[4],
                    RaceNumber = int.Parse(item.Split(':')[5]),

            });
            }
        }

        public MainWindowViewModel(ILogic logic)
        {
            this.logic = logic;
            Racers = new ObservableCollection<Person>();
            Tournament = new ObservableCollection<Person>();

            //Racers.Add(new Person()
            //{
            //    Name = "Kiss Béla",
            //    PersonalRecord = 100,
            //    ThisYearBest = 85,
            //    HasLicense = true,
            //    Club = "FTC",
            //    RaceNumber = 1

            //});

            //Racers.Add(new Person()
            //{
            //    Name = "Nagy Béla",
            //    PersonalRecord = 100,
            //    ThisYearBest = 85,
            //    HasLicense = true,
            //    Club = "FTC",
            //    RaceNumber = 1

            //});

            //Racers.Add(new Person()
            //{
            //    Name = "Közepes Béla",
            //    PersonalRecord = 100,
            //    ThisYearBest = 85,
            //    HasLicense = false,
            //    Club = "FTC",
            //    RaceNumber = 1

            //});
            //Tournament.Add(new Person()
            //{
            //    Name = "Kiss Béla",
            //    PersonalRecord = 100,
            //    ThisYearBest = 85,
            //    HasLicense = true,
            //    Club = "FTC",
            //    RaceNumber = 1

            //});

            logic.SetupCollections(Racers, Tournament);

            AddToTournamentCommand = new RelayCommand(
                () => logic.AddToTournament(SelectedFromRacers),
                () => SelectedFromRacers != null && SelectedFromRacers.HasLicense == true
                );
            RemoveFromTournamentCommand = new RelayCommand(
                () => logic.RemoveFromTournament(SelectedFromTournament),
                () => SelectedFromTournament != null
                );
            DisplayRacerCommand = new RelayCommand(
                () => logic.DisplayRacer(SelectedFromRacers),
                () => SelectedFromRacers != null
                );

            LoadRacersCommand = new RelayCommand(
                () => LoadRacers("racers.txt")
                );

            SaveTrounamentCommand = new RelayCommand(
                () => MessageBox.Show(SaveDate + "_" + SaveName)
                );
        }
    }
}
