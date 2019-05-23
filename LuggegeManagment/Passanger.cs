using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggegeManagment
{
    class Passenger
    {
        public string surname;
        public string name;
        public string patronymic;
        public string flightnumber;
        public string laggagenumber;
        public int amountofplaces;
        public double sumweight;

        public Passenger(string s, string n, string p, string f, string l, int a, double sum)
        {
            surname = s;
            name = n;
            patronymic = p;
            flightnumber = f;
            laggagenumber = l;
            amountofplaces = a;
            sumweight = sum;
        }
    }
}
