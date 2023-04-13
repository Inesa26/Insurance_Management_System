using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Management_System
{
    internal class Customer : Person
    {
        private static int lastCustomerId = 0;
        private int CustomerId;
       
        public Customer(string idnp, string name, string surname, DateTime birthdate, string address, string phoneNumber)
            : base(idnp, name, surname, birthdate, address, phoneNumber) {
            lastCustomerId++;
            this.CustomerId = lastCustomerId;
        }

        public override string ToString()
        {
            return $"\nCustomerId: {CustomerId},\n{base.ToString()}";
        }


    }
}

