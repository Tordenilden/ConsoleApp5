
using ConsoleApp5;
using System.Data.SqlClient;
using System.Reflection;


namespace Reflection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Type
            int i = 47; // it's a value type, Declaration - very important for 400.000.000 people
            System.Type type = i.GetType();
            Console.WriteLine(type);
            #endregion Type

            #region Assembly
            /// WHAT? - ist compiled code - example lib (DLL) (Maybe it could be Repo??)
            Console.WriteLine(typeof(Hero).AssemblyQualifiedName);
            Hero heroObj = new Hero();
            ClassA classAObj = new ClassA();
            // we want to be able to foreach those two objects and know the differens..

            const string objectToInstantiate = "ConsoleApp5.Hero, ConsoleApp5";
            var objectType = Type.GetType(objectToInstantiate); // Hero
            Console.WriteLine(objectType);
            var instantiatedObject = Activator.CreateInstance(objectType); // an object of Hero
            // repetition af pensum (sikkert fra H2, eller noget andet :))
            // var instantiatedObject1 = Activator.CreateInstance() // overloading
            // Polymorphism - its the ability to look different / have a different
            //                behavior, even though its the same (obj or method)
            /// class Classes  - Damage()
            /// class Mage : Classes
            /// class Cleric : Classes
            /// List<Classes> list = new List<Classes>()
            /// list.Add(new Mage(){propertyName="Archibald"})
            /// list.Add(new Cleric(){propertyName="Cleric the great"})
            /// foreach(var classes001 in list){
            /// classes001.Damage() - first time it Invoke Damage on Mage
            /// classes001.Damage() - second time it Invoke Damage on Cleric
            /// -
            /// Hov jeg glemte en Tyv (Thief)
            /// class Thief : Classes
            /// list.Add(new Thief(){propertyName="Tasselhoof"})
            /// foreach(var classes001 in list){   // this is never written again
            /// classes001.Damage() - Now it Invoke Damage() three times, first on
            ///                       Mage, then Cleric. then Thief

            #endregion Assembly

            #region Properties
            // 3) Looking at properties
            //    Print out all properties and find their values, set their values
            PropertyInfo[] propertyInfos; //
            propertyInfos = typeof(Hero).GetProperties();

            foreach (PropertyInfo prop in propertyInfos) // is field a good word?
            {
                Console.WriteLine(prop.Name);
            }

            Console.WriteLine("");
            // Set value for properties (its like random data or seeding a database)
            foreach (PropertyInfo prop in propertyInfos)
            {
                // Id = 2 - first run
                // Name = 2 - second run
                // Agility = 2 - third run
                // prop.SetValue(instantiatedObject, 2); // convert problems
                if (prop.Name == "Id")
                    prop.SetValue(instantiatedObject, 2);
                else
                    prop.SetValue(instantiatedObject, "this is just text: " +prop.Name);
                Console.WriteLine(prop.GetValue(instantiatedObject)); // WHat is this? is it meta data?
                // hvad hvis vi skriver et array ud.. får jeg data eller array??
            }







            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
                ;

            //getById(){ IServiceProvider , reference i API}
            Hero hero = new Hero() { Id = 5, Name = "Tarzan", Agility = "the best man ever", Intelligens = "20" };
            foreach (PropertyInfo prop in propertyInfos)
            {
                if(prop.Name == "Id")
                {
                    prop.SetValue(instantiatedObject, hero.GetType().GetProperty(prop.Name).GetValue(hero,null));
                }
                Console.WriteLine(prop.GetValue(instantiatedObject));
            }
            #endregion Properties

            //MyMethod(12);// some say this is an argument / and all people to the north of France says its a Parameter
                         // (this is just some I write)
        }

        //public void MyMethod(Hero hero) // maybe I can pass something that is "bigger" than Hero here, so its even better
        //{
        //    foreach (PropertyInfo prop in propertyInfos)
        //    {
        //        if (prop.Name == "Id")
        //        {
        //            prop.SetValue(instantiatedObject, hero.GetType().GetProperty(prop.Name).GetValue(hero, null));
        //        }
        //        Console.WriteLine(prop.GetValue(instantiatedObject));
        //    }
        //}
        //public static void MyMethod2(int number) // argument number, its also called something else... starting with a Parameter
        //{
        //    SqlConnection ss = new SqlConnection();
        //    SqlCommand cmd = ss.CreateCommand();
        //    ss.Open();
        //    cmd.ExecuteNonQuery();
        //}        
        //public static void MyMethod4(int number) // argument number, its also called something else... starting with a Parameter
        //{
        //    SqlConnection ss = new SqlConnection();
        //    SqlCommand cmd = ss.CreateCommand();
        //    ss.Open();
        //    cmd.ExecuteNonQuery();
        //}        
        //public static void MyMethod6(int number) // argument number, its also called something else... starting with a Parameter
        //{
        //    SqlConnection ss = new SqlConnection();
        //    SqlCommand cmd = ss.CreateCommand();
        //    ss.Open();
        //    cmd.ExecuteNonQuery();
        //}
    }
}