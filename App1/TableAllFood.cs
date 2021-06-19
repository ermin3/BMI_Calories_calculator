using SQLite;

namespace App1
{
    //database for eaten food
    public class TableAllFood
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
         public double Fats { get; set; } 
        public double Carbs { get; set; }

 
      
        public override string ToString()
        {
            return Name;
        }
    }
}
