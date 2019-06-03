using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggegeManagment
{
    public class Passenger
    {
        public string surname { get; set; }       //Фамилия
        public string name{ get; set; }           //Имя     
        public string patronymic { get; set; }    //Отчество
        public string flightnumber { get; set; }  //Номер рейса
        public string laggagenumber { get; set; } //Номер багажной квитанции
        public int amountofplaces { get; set; }   //Количество мест багажа
        public double sumweight { get; set; }     //Суммарный вес багажа пассажира

    }
}
