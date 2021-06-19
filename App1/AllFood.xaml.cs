using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;



namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllFood : ContentPage
    {
        //creating database path and list view
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Food_db.db3");
       
        int ID;
       


        public AllFood()
        {
            //making database conection
            var db = new SQLiteConnection(_dbPath);

            InitializeComponent();
            this.Title = "Eaten Food";

            //passing data from database to the listview
            _listView = new ListView();
            collectedEatenFood.ItemsSource = db.Table<TableAllFood>().ToList();

            collectedEatenFood.Header = "eaten food";


        }


        //deleting unnecessary food
        private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TableAllFood selectedItem = e.SelectedItem as TableAllFood;
            ID = selectedItem.id;
        }

        private void Erase_Buton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<TableAllFood>().Delete(x => x.id == ID);
            collectedEatenFood.ItemsSource = db.Table<TableAllFood>().ToList();

        }
        }
    }
