using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

        }

//declaring all nessesery varijablas
        string passOnData;
        double calories_m=0;
        double calories_w=0;
        double age;
        int selected;
        double height;
        double weight;


//creating event for making changes on the page
        public void OnEntryTextChanged(object sender, EventArgs e)
        {
            
            double result = 0D;
            next_page.IsVisible = false;   //you can enter new page only if you enter all data
            NavTitle.FontSize = 24;

            //picking gender and setting picture for man/woman
            selected = Gender.SelectedIndex;
            if (selected == 0)
            {
                BMI_result.Text = "Your BMI is";
                Bmi_Picture.Source = ImageSource.FromFile("man.png");
                CaloriesPD.Text = "Enter\n parameters!!!";
                Message.Text = "You are Perfect";
            }
            if (selected == 1)
            {
                BMI_result.Text = "Your BMI is";
                Bmi_Picture.Source = ImageSource.FromFile("woman.png");
                CaloriesPD.Text = "Enter\n parameters!!!";
                Message.Text = "You are Perfect";
            }
            else
            {
                CaloriesPD.Text = "Enter\n parameters!!!";
            }

            //entry doesn't have to be null, calculating calories and BMI
            if (double.TryParse(EntryHeight.Text, out height) && double.TryParse(EntryWeight.Text, out weight) && double.TryParse(Age.Text, out age))
            {
                {
                    if ((button_cm).IsChecked && (button_kg).IsChecked && height != 0)
                    {
                        result = weight / (height * height / 10000);
                        calories_m = (88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age));
                        calories_w = (447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age));

                    }
                    else if ((button_in).IsChecked && (button_lbs).IsChecked && height != 0)
                    {
                        height *= 2.54;
                        weight /= 2.2046;
                        result = (weight / (height * height / 10000));
                        calories_m = (88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age));
                        calories_w = (447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age));
                    }

                    else if ((button_in).IsChecked && (button_kg).IsChecked && height != 0)
                    {
                        height *= 2.54;
                        result = weight / (height * height / 10000);
                        calories_m = (88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age));
                        calories_w = (447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age));
                    }
                    else if ((button_cm).IsChecked && (button_lbs).IsChecked && height != 0)
                    {
                        weight /= 2.2046;
                        result = weight / (height * height / 10000);
                        calories_m = (88.362 + (13.397 * weight) + (4.799 * height) - (5.677 * age));
                        calories_w = (447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age));
                    }
                    else
                    {
                        BMI_result.Text = $"BMI";
                    }
                    BMI_result.Text = $"Your BMI is {result:0.00}";
                    if (result != 0)
                    {
                        next_page.IsVisible = true;
                        NavTitle.FontSize = 18;
                    }

                    //showing picture relevant for calculated data
                    if (selected == 0)
                    {

                        CaloriesPD.Text = $"Calories per day {calories_m:0.00}!!";
                        passOnData = Convert.ToString(calories_m);

                        if (result > 0 && result < 18.5)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("man1");
                            Message.Text = "Underweight!";
                        }
                        else if (result >= 18.5 && result < 25)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("man2");
                            Message.Text = "Normal!";
                        }
                        else if (result >= 25 && result < 30)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("man3");
                            Message.Text = "Overweight!";
                        }
                        else if (result >= 30 && result < 35)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("man4");
                            Message.Text = "Obese!";
                        }
                        else if (result >= 35)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("man5");
                            Message.Text = "Extremly Obese!";
                        }
                    }

                    if (selected == 1)
                    {
                        CaloriesPD.Text = $"Calories per day {calories_w:0.00}!!";
                        passOnData = Convert.ToString(calories_w);
                        if (result > 0 && result < 18)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("woman1.png");
                            Message.Text = "Underweight!";
                        }
                        else if (result >= 18 && result < 24)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("woman2.png");
                            Message.Text = "Normal!";
                        }
                        else if (result >= 24 && result < 29)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("woman3.png");
                            Message.Text = "Overweight!";
                        }
                        else if (result >= 29 && result < 34)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("woman4.png");
                            Message.Text = "Obese!";
                        }
                        else if (result >= 34)
                        {
                            Bmi_Picture.Source = ImageSource.FromFile("woman5.png");
                            Message.Text = "Extremly Obese!";
                        }


                    }
                }
            }
            
        }       
        //going on the next page

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2(passOnData));
        }

        
    }
}