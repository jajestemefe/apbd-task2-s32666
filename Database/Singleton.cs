using System.Collections.Generic;
using APBD_TASK2.Models;

namespace APBD_TASK2.Database
{
    public class Singleton
    {
        private static Singleton? _instance;
        public static Singleton Instance
        {
            get
            {
                _instance ??= new Singleton();
                return _instance;
            }
        }

        private Singleton() { }
        
        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}