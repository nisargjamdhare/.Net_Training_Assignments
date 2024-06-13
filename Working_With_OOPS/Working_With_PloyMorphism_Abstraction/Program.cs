
namespace Working_With_PloyMorphism_Abstraction
{

   // Animal Class
   class Animal
    {
       private string name="";
        private string color="";

        public void setname(string name)
        {
            this.name = name;
        }

       public string getname(string name)
        {
            return this.name;
        }

        public void setColor(string color)
        {
            this.color = color;
        }

        public string getColor()
        {
            return this.color;
        }

        public string getname()
        {
            return this.name;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
           Animal Dog =new Animal();
           Dog.setname("Ketan");
            Console.WriteLine("Name of an Animal is :- "+Dog.getname());
            Dog.setColor("Brown");
            Dog.getColor();
            Console.WriteLine("Color of the Animal :- "+Dog.getColor());



            Console.ReadLine();
        }
    }
}
