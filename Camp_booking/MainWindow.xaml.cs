using DataAccess;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Camp_booking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Booker selectedBooker;
        private Reservation selectedReservation;
        List<int> pitches= new List<int>();
        private bool conflict;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            pitches.Add(1);
            pitches.Add(2);
            pitches.Add(3);
            pitches.Add(4);
            pitches.Add(5);
            pitches.Add(6);
            pitches.Add(7);
            pitches.Add(8);
            WeatherService ins = new();
            CustomWeather in2 = new();
            in2 = ins.GetWeather();
            weatherBox.Text = in2.ToString();
            Repository repo = new();
            List<Booker> bookers = repo.GetAllBookers();
            listbox.ItemsSource = bookers;
            samples.ItemsSource = pitches;
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBooker = listbox.SelectedItem as Booker;
            if(selectedBooker != null)
            {
            Repository repo = new();
            List<Reservation> reserves = repo.GetAllReservations(selectedBooker.ReserveId_FK);
            listbox2.ItemsSource = reserves;
            }
        }
        private string selectedString;
        private void listbox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            selectedReservation = listbox2.SelectedItem as Reservation;
            if(selectedReservation != null)
            {
                string strt = selectedReservation.ReserveStart.ToString();
                string nd = selectedReservation.ReserveEnd.ToString();
                selectedString = $"{strt} and ends at {nd}";
                UUpdate();
            }
        }
        private DateTime start;
        private DateTime end;
        private int selectedSample;
        private void Make_Reservation(object sender, RoutedEventArgs e)
        {
            if(mail.Text != null)
            {
                if (name.Text != null)
                {
                    selectedReservation = listbox2.SelectedItem as Reservation;
                    if (samples.SelectedItem != null)
                    {
                        conflict = false;
                        Repository repo = new();
                        selectedSample = (int)samples.SelectedItem;
                        List<Reservation> exsistingReserves = repo.GetAllReservations(selectedSample);
                        foreach (Reservation i in exsistingReserves)
                        {
                            if (!(start > i.ReserveStart && end > i.ReserveEnd || start < i.ReserveStart && end < i.ReserveEnd))
                            {
                                conflict = true;
                                UUpdate();
                                break;
                            }
                        }
                        if(conflict=false)
                        {
                            Reservation reserve = new(start, end, selectedSample);
                            Booker booker = new(name.Text, mail.Text, selectedSample);
                            repo.SaveNewBooker(booker);
                            repo.SaveNewReservation(reserve);
                        }
                    }
                }
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (selectStart.IsChecked == true)
            {
                start = calender.DisplayDate;
            }
            if (selectEnd.IsChecked == true)
            {
                end = calender.DisplayDate;
            }
            UUpdate();
        }
        private void UUpdate()
        {
            string strt = start.ToString();
            string nd = end.ToString();
            viewBox.Text = $"you have indicated a start at {strt} and ends at {nd} " +
                $"conflicts = {conflict} " +
                $"your selected reservation starts at {selectedString} " +
                $"{selectedSample}";
        }
    }
}
