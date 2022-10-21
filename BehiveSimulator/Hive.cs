using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehiveSimulator
{
    class Hive
    {
        private const int InitialfBees = 6;
        private const double InitialHoney = 3.2;
        private const double MaximumHoney = 15.0;
        private const double NectarHoneyRatio = .25;
        private const int MaximumBees = 8;
        private const double MinimumHoneyForCreatingBees = 4.0;

        public double Honey { get; private set; }
        private Dictionary<string, Point> locations;
        private int beeCount = 0;

        public Hive()
        {
            Honey = InitialHoney;
            InitializeLocations();
            Random random = new Random();
            for (int i = 0; i < InitialfBees; i++)
            {
                AddBee(random);
            }
        }

        public void InitializeLocations()
        {
            locations = new Dictionary<string, Point>();
            locations.Add("Entrance", new Point(600, 100));
            locations.Add("Nursery", new Point(95, 174));
            locations.Add("HoneyFactory", new Point(157, 98));
            locations.Add("Exit", new Point(194, 213));
        }

        public bool AddHoney(double nectar)
        {
            throw new NotImplementedException("Método em desenvolvimento.");
        }

        public bool ConsumeHoney(double amount)
        {
            throw new NotImplementedException("Método em desenvolvimento.");
        }

        public void AddBee(Random random)
        {
            throw new NotImplementedException("Método em desenvolvimento.");
        }

        public void Go(Random random)
        {
            throw new NotImplementedException("Método em desenvolvimento.");
        }

        public Point GetLocation(string location)
        {
           if (locations.Keys.Contains(location))
            {
                return locations[location];
            }
           else
            {
                throw new ArgumentException("Localização desconhecida: " + location);
            }
        }
    }
}
