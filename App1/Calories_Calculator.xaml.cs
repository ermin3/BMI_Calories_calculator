using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;


namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        //creating relevant database, commands and tables
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Food_db.db3");
        
        int count;
        ICommand increaseCommand;
        ICommand decreaseCommand;
        
        public IList<Food> Foods { get; private set; }
        public Page2(string passOnData)

        {         
            InitializeComponent();
//parameter from BMI_Calculator
            CaloriesPD.Text = passOnData;
//adding food to food table
            Foods = new List<Food>();
            Foods.Add(new Food
            {
                ImageUrl = "https://lh3.googleusercontent.com/proxy/0-nCPRb8HkETyCKY-aRRxBw2RLVVWUC6sG2a2mAKMIIW-lKz0rjmSKedjOW7aRI1g2xAqF_ivgFpWThrpJ4ppXykyJSY6lodLru59EMq",
                Name = "Chicken",
                Calories = 123,
                Proteins = 21,
                Carbs = 12,
                Fat = 4
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://petason.hr/cms/wp-content/uploads/2019/09/1-2000x1200.jpg",
                Name = "Veal",
                Calories = 105,
                Proteins = 21,
                Carbs = 0,
                Fat = 3
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://www.tportal.hr/media/thumbnail/w1000/870279.jpeg",
                Name = "Salmon",
                Calories = 217,
                Proteins = 20,
                Carbs = 0,
                Fat = 14
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://hr.n1info.com/wp-content/uploads/2021/02/shutterstock_1023853642.jpg",
                Name = "Trout",
                Calories = 112,
                Proteins = 18,
                Carbs = 0,
                Fat = 2
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://www.vecernji.hr/media/img/a6/22/0f386a3fdffa1ef75105.jpeg",
                Name = "Milk 0,9%",
                Calories = 40,
                Proteins = 3,
                Carbs = 5,
                Fat = 1
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://www.fitness.com.hr/images/articles/b9e2bc9f-19d0-4b92-89db-c7a123d17f51.jpg",
                Name = "Low-fat cheese",
                Calories = 78,
                Proteins = 12,
                Carbs = 3,
                Fat = 2
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://storage.bljesak.info/article/15900/1280x880/bjelanjak-zdjela.jpg",
                Name = "Eggs",
                Calories = 54,
                Proteins = 17,
                Carbs = 1,
                Fat = 0
            });

            Foods.Add(new Food
            {
                ImageUrl = "http://microseum.net/assets/images/oprez-sto-napada-hranu/sir-i-jaja/jaja-razbijena.png",
                Name = "Eggs",
                Calories = 377,
                Proteins = 16,
                Carbs = 0,
                Fat = 32
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://i.ytimg.com/vi/O5ynUVb9Dv0/maxresdefault.jpg",
                Name = "White bread",
                Calories = 237,
                Proteins = 7,
                Carbs = 47,
                Fat = 2
            });

            Foods.Add(new Food
            {
                ImageUrl = "http://www.zenasamja.me/images/full/2412.jpg",
                Name = "Black bread",
                Calories = 250,
                Proteins = 6,
                Carbs = 51,
                Fat = 1
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://cdn.agroklub.com/upload/images/text/thumb/grah10-880x495.jpg",
                Name = "Beans",
                Calories = 110,
                Proteins = 7,
                Carbs = 21,
                Fat = 1
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://ordinacija.vecernji.hr/repository/images/_variations/0/d/0d19f45d339ea6e040d02fa0a99fe8a7-hero.jpg?v=1",
                Name = "Corn",
                Calories = 110,
                Proteins = 4,
                Carbs = 22,
                Fat = 2
            });

            Foods.Add(new Food
            {
                ImageUrl = "http://wiki.poljoinfo.com/wp-content/uploads/2014/12/krtola-Krompir.jpg",
                Name = "Potatoes",
                Calories = 85,
                Proteins = 2,
                Carbs = 19,
                Fat = 0
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://www.adiva.hr/wp-content/uploads/2019/01/ananas.jpg",
                Name = "Pineapple",
                Calories = 56,
                Proteins = 0,
                Carbs = 13,
                Fat = 0
            });

            Foods.Add(new Food
            {
                ImageUrl = "https://www.adiva.hr/wp-content/uploads/2019/02/Jabuke-760x525.jpg",
                Name = "Apple",
                Calories = 52,
                Proteins = 0,
                Carbs = 12,
                Fat = 0
            });
            BindingContext = this;

//Creating picker for activity
            Activity.Items.Add("Sedentary");
            Activity.Items.Add("Light");
            Activity.Items.Add("Moderate");
            Activity.Items.Add("Active");
            Activity.Items.Add("Very Active");
        }
//Formatting command for water counter
        public int Count
        {
            get => count;
            set
            {
               
                 if (value<0)
                {
                    value=0;
                    count = value;
                }
                else if (count>=0){ 
                    count = value;
                    OnPropertyChanged();
                } 
            }
        }
        public ICommand IncreaseCommand => increaseCommand = new Command(() => Count++);
        public ICommand DecreaseCommand => decreaseCommand = new Command(() => Count--);

       
        //creating all variables 
        double totallyEatenProtein;
        double totallyEatenFat;
        double totallyEatenCarb;
        double totalyEatenCalories;
        double FoodCalories=0;
        double FoodProteins;
        double FoodFats;
        double FoodCarbs;
        string FoodName;
        string FoodUrl;
        double proteinNeeds;
        double fatNeeds;
        double carbsNeeds;
        double caloriesBudget;
        int activitiIndex=-1;
        int goalIndex=-1;
     

//event for changing activity and goal-relevant for calories budget
        private void Activiti_SelectedIndexChanged(object sender, EventArgs e)
        {
            activitiIndex = Activity.SelectedIndex;
            goalIndex = Goal.SelectedIndex;

            caloriesBudget = Convert.ToDouble(CaloriesPD.Text);
            CaloriesL.Text = $"{caloriesBudget}cal";
           

            if (activitiIndex == 0)
                {
                    caloriesBudget *= 1.2;
                }
                else if (activitiIndex == 1)
                {
                    caloriesBudget *= 1.375;
                }
                else if (activitiIndex == 2)
                {
                    caloriesBudget *= 1.55;
                }
                else if (activitiIndex == 3)
                {
                    caloriesBudget *= 1.725;
                }
                else if (activitiIndex == 4)
                {
                    caloriesBudget *= 1.9;
                }


                if (goalIndex == 0)
                {
                    caloriesBudget -= 500;
                    proteinNeeds = 0.265 * caloriesBudget;
                    fatNeeds = 0.25 * caloriesBudget;
                    carbsNeeds = caloriesBudget - proteinNeeds - fatNeeds;
                }
                if (goalIndex == 1)
                {

                    proteinNeeds = 0.29 * caloriesBudget;
                    fatNeeds = 0.3 * caloriesBudget;
                    carbsNeeds = caloriesBudget - proteinNeeds - fatNeeds;
                }

                else if (goalIndex == 2)
                {
                    caloriesBudget += 500;
                    proteinNeeds = 0.4 * caloriesBudget;
                    fatNeeds = 0.4 * caloriesBudget;
                    carbsNeeds = caloriesBudget - proteinNeeds - fatNeeds;
                }
                CaloriesL.Text = $"{caloriesBudget:0.00}";
                Left.Text = $"{caloriesBudget:0.00}";     

        }


//event for selecting food from the "Food table"
        private void Selected_Item(object sender, SelectedItemChangedEventArgs args)
        {
            Food selectedItem = args.SelectedItem as Food;
            FoodUrl = selectedItem.ImageUrl;
            FoodName = selectedItem.Name;
            FoodCalories = selectedItem.Calories;
            FoodFats = selectedItem.Fat;
            FoodProteins = selectedItem.Proteins;
            FoodCarbs = selectedItem.Carbs;
        }

        //adding all selected data into db

        private async void Add_Clicked(object sender, EventArgs e)
        {
            
            
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<TableAllFood>();
            var maxPK = db.Table<TableAllFood>().OrderByDescending(c => c.id).FirstOrDefault();

            TableAllFood allfood = new TableAllFood
            {
                id = (maxPK == null ? 0 : maxPK.id + 1),
                ImageUrl = FoodUrl,
                Name = FoodName,
                Calories = FoodCalories,
                Proteins = FoodProteins,
                Fats = FoodFats,
                Carbs = FoodCarbs,

            };
            db.Insert(allfood);

            totalyEatenCalories = 0;
            totallyEatenCarb = 0;
            totallyEatenFat = 0;
            totallyEatenProtein = 0;
            var eatenFoodList = db.Table<TableAllFood>().ToList();
            foreach (var item in eatenFoodList)
            {

                totalyEatenCalories += item.Calories;
                totallyEatenProtein += item.Proteins;
                totallyEatenFat += item.Fats;
                totallyEatenCarb += item.Carbs;

            }
            //click again to reset on relevant values


            //creating progress bars
            if (activitiIndex != -1 && goalIndex != -1)
            {      
                    Left.Text = $"{caloriesBudget-totalyEatenCalories:0.00}cal";
                    double progress = ((totalyEatenCalories) / caloriesBudget);
                    CalorieProgress.Progress = progress;
                    CaloriePercent.Text = $"{progress * 100:0.00}%";
                                    
                    
                    ProteinsL.Text = $"{totallyEatenProtein:0}gr";
                    double proteinProgress;
                    proteinProgress = (totallyEatenProtein * 4 / proteinNeeds);
                    ProteinProgress.Progress = proteinProgress;
                    ProteinPercent.Text = $"{proteinProgress * 100:0}%";

                                      
                    CarbsL.Text = $"{totallyEatenCarb:0}gr";
                    double carbsProgress;
                    carbsProgress = (totallyEatenCarb * 4 / carbsNeeds);
                    CarbProgress.Progress = carbsProgress;
                    CarbsPercent.Text = $"{carbsProgress * 100:0}%";
                                                   
                    
                    FatsL.Text = $"{totallyEatenFat:0}gr";
                    double fatProgress;
                    fatProgress = (totallyEatenFat * 9 / fatNeeds);
                    FatProgress.Progress = fatProgress;
                    FatsPercent.Text = $"{fatProgress * 100:0}%";
                } 
            

                else if (activitiIndex == -1 || goalIndex == -1)
                {
                    await DisplayAlert("Meesage!!!", "You have to select \"Activity\" and \"Goal\"", "OK");

                }

                if (FoodCalories == 0)
                {
                    await DisplayAlert("Message!!!", "You have to select \"Food\"", "OK");
                }

               
          
        }

        //navigate to new page
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new About_US());
        }

        async void AllFood_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new AllFood());
        }
        }
    }
 

