using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;
using DataMappingSample;

namespace MasaSam.Data.Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
            UserItem userItem;
            var extendedUserItem = Program.InitExtendedUserItem();
            var _map = DataMapper.Resolve<ExtendedUserItem, UserItem>();
            userItem = DataMapper.Map<ExtendedUserItem, UserItem>(extendedUserItem);
            Compare(extendedUserItem, userItem);
            Console.WriteLine("BreakPoint Stop...");
            #region NewPerson

            //// source instance
           // Person person = new Person()
           // {
           //     Name = "Mickey Mouse",
           //     Age = 85,
           //     EyeColor = "Blue",
           //     Sex = "Male",
           //     Company = new Company()
           //     {
           //         Name = "Disney"
           //     }
           // };

            #endregion
           // User user; //// destination instance
           // var map = DataMapper.Resolve<Person, User>(); //// default map to map between properties with same name
           // user = DataMapper.Map<Person, User>(person); //// conversion
           // //Compare(person, user);
           // map.Add<Person, User>(p => p.Sex, u => u.Gender);//// add mapping between properties with different name, but same meaning
           // user = DataMapper.Map<Person, User>(person);//// conversion
           // //Compare(person, user);
           // map.Add<Person, User>("EyeColor", "SetEyeColor"); //// map property to setter method
           // user = DataMapper.Map<Person, User>(person); //// conversion
           // //Compare(person, user);
           // map.Ignore<User>(u => u.Age); //// ignore mapping
           // user = DataMapper.Map<Person, User>(person); //// conversion
           // //Compare(person, user);
           // map.Unignore<User>(u => u.Age);  //// unignore
           // user = DataMapper.Map<Person, User>(person);
           // //Compare(person, user);
           // map.Complex<Person, User>(p => p.Company, u => u.Employer); //// complex
           // user = DataMapper.Map<Person, User>(person);
           //// Compare(person, user);
           // map.Remove("Company");//// remove
           // user = DataMapper.Map<Person, User>(person);
           // Compare(person, user);
            Performance(1000); //// performance

            Console.ReadKey();
        }

        public UserItem InitUserItem() => new UserItem();
        public static ExtendedUserItem InitExtendedUserItem() => new ExtendedUserItem()
        {
            Id = 1,
            UserId = Guid.NewGuid(),
            ModelNumber = "ExtendedItemModelNumber1",
            Description = "Sample Extended User Item",
            ImageUrl = "https://imageurl.com",
            SerialNumber = "123454321",
            ToolNumber = "5544332211",
            PurchaseLocation = "Location",
            OrderInformationImageUrl = "https://orderinformationimageurl.com",
            ItemizationImageUrl = "https://itemizationimageurl.com",
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow,
            Price = 100,
            PurchasedOn = DateTime.UtcNow,
            LastSeen = DateTime.UtcNow,
            IsDeleted = false,
            IsMissing = false,
        };
        static void Compare(ExtendedUserItem extendedUserItem, UserItem userItem)
        {
            Console.WriteLine("\nconversion result:\n");

            Console.WriteLine("source: {0} destination: {1}", extendedUserItem.Description, userItem.Description);
        }
        //static void Compare(Person person, User user)
        //{
        //    Console.WriteLine("\nConversion result:\n");

        //    Console.WriteLine("P.Name =  {0}, U.Name =  {1}", person.Name, user.Name);
        //    Console.WriteLine("P.Age  =  {0}, U.Age  =  {1}", person.Age, user.Age);
        //    Console.WriteLine("P.Sex  =  {0}, U.Sex  =  {1}", person.Sex, user.Gender);
        //    Console.WriteLine("P.Color = {0}, U.Color = {1}", person.EyeColor, user.EyeColor.Name);
        //    Console.WriteLine("P.Comp =  {0}, U.Comp  = {1}", person.Company.Name, user.Employer.Name);
        //}

        static void Performance(int count)
        {
            //var persons = GetPersons(count);
            var extendedItems = GetExtendedItems(count);

            DataMapper.RemoveMap<ExtendedUserItem, UserItem>();

            var map = DataMapper.Resolve<ExtendedUserItem, UserItem>();
            map.Add<ExtendedUserItem, UserItem>("EyeColor", "SetEyeColor");
            map.Complex<ExtendedUserItem, UserItem>(p => p.UserCategory, u => u.UserCategory);

            var sw = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < count; i++)
            {
                var user = DataMapper.Map<ExtendedUserItem,UserItem>(extendedItems[i]);
            }

            sw.Stop();

            Console.WriteLine("\nMapping {0} instances took {1} ms. Average = {2}\n", count, sw.ElapsedMilliseconds, sw.Elapsed.TotalMilliseconds / count);
        }

        static List<ExtendedUserItem> GetExtendedItems(int count)
        {
            var extendedItems = new List<ExtendedUserItem>();
            for (int i = 0; i < count; i++)
            {
                extendedItems.Add(new ExtendedUserItem()
                {
                    Id = i + i,
                    UserId = Guid.NewGuid(),
                    ModelNumber = "ExtendedItemModelNumber1",
                    Description = "Sample Extended User Item",
                    ImageUrl = "https://imageurl.com",
                    SerialNumber = "123454321",
                    ToolNumber = "5544332211",
                    PurchaseLocation = "Location",
                    OrderInformationImageUrl = "https://orderinformationimageurl.com",
                    ItemizationImageUrl = "https://itemizationimageurl.com",
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    Price = 100,
                    PurchasedOn = DateTime.UtcNow,
                    LastSeen = DateTime.UtcNow,
                    IsDeleted = false,
                    IsMissing = false,
                });
            }

            return extendedItems;
        }

        static List<Person> GetPersons(int count)
        {
            List<Person> persons = new List<Person>(count);

            for (int i = 0; i < count; i++)
            {
                persons.Add(new Person()
                {
                    Name = "Donald Duck",
                    Age = i + 1,
                    Sex = "Male",
                    EyeColor = "Red",
                    Company = new Company() { Name = "Disney" }
                });
            }

            return persons;
        }
    }

    public class Comparison<Tsource, Tdestination>
    {
        public static Type GetSourceType(Tsource source)
        {
            return source.GetType();
        }
    }
    public class Person
    {
        private int value = 16;

        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public string EyeColor { get; set; }

        public Company Company { get; set; }

        public int GetValue()
        {
            return value;
        }
    }

    public class User
    {
        public User()
        {
            this.EyeColor = Color.Transparent;
            this.Gender = Mapping.Gender.Female;
            this.Employer = new Employer() { Name = "" };
        }

        public string Name { get; set; }

        public double Age { get; set; }

        public Gender Gender { get; set; }

        public Employer Employer { get; set; }

        public Color EyeColor
        {
            get;
            private set;
        }

        public void SetEyeColor(Color color)
        {
            this.EyeColor = color;
        }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public class Company
    {
        public string Name { get; set; }
    }

    public class Employer
    {
        public string Name { get; set; }
    }


}
