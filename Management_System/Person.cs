using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Management_System
{
    public class Person
    {
        private string idnp;
        private string name;
        private string surname;
        private DateTime birthdate;
        private string address;
        private string phoneNumber;

       
        public Person(string idnp, string name, string surname, DateTime birthdate, string address, string phoneNumber)
        {
            this.idnp = idnp;
            this.name = name;
            this.surname = surname;
            this.birthdate = birthdate;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public string Idnp
        {
            get { return idnp; }
            set { idnp = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }


        public static T CreatePerson <T>() where T : Person
        {
            string name = SetName();
            string surname = SetSurname();
            string idnp = SetIdnp();
            DateTime birthdate = SetBirthdate();    
            string address = SetAddress();
            string phoneNumber = SetPhone();

            Console.WriteLine("The data has been successfully saved!");

            if (typeof(T) == typeof(Customer))

            { return (T)(object)new Customer(idnp, name, surname, birthdate, address, phoneNumber); }

            else { return (T)(object)new Agent(idnp, name, surname, birthdate, address, phoneNumber); }
           
        }

        public static void ViewPerson<T>(List<T> persons) where T : Person
        {
            T toView = FindByIdnp(persons);
            if (toView == null)
            {
                Console.WriteLine("\nData cannot be displayed. There is no person with that identification number.");
            }
            else
            {
                Console.WriteLine("\n"+toView.ToString());
            }
        }

        public static void UpdatePerson<T>(T person) where T : Person
        {
            bool correctNr;
            do
            {
                correctNr = true;
                switch (Menu.PersonalDataEditing())
                {
                    case 1:
                        Console.WriteLine("Changing name from " + person.name);
                        person.Name = SetName();
                        break;
                    case 2:
                        Console.WriteLine("Changing surname from " + person.surname);
                        person.Surname = SetSurname();
                        break;
                    case 3:
                        Console.WriteLine("Changing identification number from " + person.idnp);
                        person.Idnp = SetIdnp();
                        break;
                    case 4:
                        Console.WriteLine("Changing birthdate from " + person.birthdate);
                        person.Birthdate = SetBirthdate();
                        break;
                    case 5:
                        Console.WriteLine("Changing address from " + person.address);
                        person.Address = SetAddress();
                        break;
                    case 6:
                        Console.WriteLine("Changing phoneNumber from " + person.phoneNumber);
                        person.PhoneNumber = SetPhone();
                        break;
                    default:
                        Console.WriteLine("The field with selected number doesn't exist. Please try again.");
                        correctNr = false; break;
                }
            } while (!correctNr);
        }
      


                public static void DeletePerson<T>(List<T> persons) where T : Person
        {
            T toDelete = FindByIdnp(persons);
            persons.Remove(toDelete);
        }

        public static String SetName() {
            Console.WriteLine("Enter person's name:\n" +
                    "Make sure that the name starts with a capital letter, followed by lowercase letters." +
                    "Only alphabetical characters are allowed.");
            string name = Console.ReadLine();
            Regex reg = new Regex(@"^[A-Z][a-z]{1,15}$");
            while (!reg.IsMatch(name))
            {
                Console.WriteLine("Name written incorrectly. Please write it again");
                name = Console.ReadLine();
            }
            return name;
        }

        public static String SetSurname()
        {
            Console.WriteLine("Enter person's surname:\n" +
                   "Make sure that the name starts with a capital letter, followed by lowercase letters." +
                   "Only alphabetical characters are allowed.");
            string surname = Console.ReadLine();
            Regex reg = new Regex(@"^[A-Z][a-z]{1,15}$");
            while (!reg.IsMatch(surname))
            {
                Console.WriteLine("Surname written incorrectly.Please write it again");
                surname = Console.ReadLine();
            }
            return surname;
        }

        public static String SetIdnp()
        {
            Console.WriteLine("Enter identification number of person:\n" +
                 "Include exactly 13 numerical digits, in the correct order, without including any non - numerical characters."
             );
            Regex reg = new Regex(@"^[0-9]{13}$");
            string idnp = Console.ReadLine();
            while (!reg.IsMatch(idnp))
            {
                Console.WriteLine("Identification number written incorrectly. Please write it again");
                idnp = Console.ReadLine();
            }
            return idnp;
        }

        public static DateTime SetBirthdate()
        {
            Console.WriteLine("Enter person's birth date:\n" +
                  "Make shure that the format is dd/MM/yyyy (e.g. 31/12/1990)" );
            Regex reg = new Regex(@"^\d{2}/\d{2}/\d{4}$");
            string birth = Console.ReadLine();
            while (!reg.IsMatch(birth))
            {
                Console.WriteLine("Birth date written incorrectly. Please write it again");
                birth = Console.ReadLine();
            }
            DateTime birthdate = DateTime.Parse(birth);
            return birthdate;
        }
        public static String SetAddress()
        {
            Console.WriteLine("Enter person's address:\n" +
               "Include a street name and number, unit number (if applicable), and \"ap.\" or \"apt.\" followed by a apartment number.\n" +
               "Make sure that the street name includes alphanumeric characters and spaces, and that the street number and unit or apartment numbers (if applicable) are numerical digits. ");
            Regex reg = new Regex(@"^([a-zA-Z0-9\s]{1,}){1,}\s\d+(\/\d+)?\s(ap|apt)\.\d+$");
            string address = Console.ReadLine();
            while (!reg.IsMatch(address))
            {
                Console.WriteLine("Address written incorrectly. Please write it again");
                address = Console.ReadLine();
            }
            return address;
        }

        public static String SetPhone()
        {
            Console.WriteLine("Enter person's phone number:\n" +
                  "Include a plus sign (+) followed by the country code \"373\" and eight numerical digits with no spaces or other characters in between."
              );
            Regex reg = new Regex(@"^\+373\d{8}$");
            string phoneNumber = Console.ReadLine();
            while (!reg.IsMatch(phoneNumber))
            {
                Console.WriteLine("Phone number written incorrectly. Please write it again");
                phoneNumber = Console.ReadLine();
            }
            return phoneNumber;
        }
        public static T FindByIdnp<T>(List<T> persons) where T : Person
        {
            T found = null;
            Console.WriteLine("Enter person's identification number");
            Regex reg2 = new Regex(@"^[0-9]{13}$");
            string idnp = Console.ReadLine();
            while (!reg2.IsMatch(idnp))
            {
                Console.WriteLine("Identification number written incorrectly. Please write it again");
                idnp = Console.ReadLine();
            }
            foreach (T person in persons)
            {
                if (person.idnp == idnp)
                {
                    found = person;
                    break;
                }
            }

            return found;
        } 

        public override string ToString()
        {
            return $"Idnp: {idnp},\nName: {name},\nSurname: {surname},\nBirthday: {birthdate.ToShortDateString()},\nAddress: {address},\nPhone Number: {phoneNumber}";
        }

     
    }
}
