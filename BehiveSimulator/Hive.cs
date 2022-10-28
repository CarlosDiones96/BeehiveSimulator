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
        private const int InitialBees = 6;
        private const double InitialHoney = 3.2;
        private const double MaximumHoney = 15.0;
        private const double NectarHoneyRatio = .25;
        private const int MaximumBees = 8;
        private const double MinimumHoneyForCreatingBees = 4.0;

        public double Honey { get; private set; }
        private Dictionary<string, Point> locations;
        private int beeCount = 0;

        private World world;

        public BeeMessage MessageSender;

        public Hive(World world, BeeMessage MessageSender)
        {
            this.MessageSender = MessageSender;
            this.world = world;
            Honey = InitialHoney;
            InitializeLocations();
            Random random = new Random();
            for (int i = 0; i < InitialBees; i++)
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
            double honeyToAdd = nectar * NectarHoneyRatio;
            if (honeyToAdd + Honey > MaximumHoney)
            {
                return false;
            }
            Honey += honeyToAdd;
            return true;
        }

        public bool ConsumeHoney(double amount)
        {
            if (amount > Honey)
            {
                return false;
            }
            else
            {
                Honey -= amount;
                return true;
            }
        }

        public void AddBee(Random random)
        {
            beeCount++;
            int r1 = random.Next(100) - 50;
            int r2 = random.Next(100) - 50;
            Point startPoint = new Point(locations["Nursery"].X + r1,
                                         locations["Nursery"].Y + r2);
            Bee newBee = new Bee(beeCount, startPoint, world, this);
            newBee.MessageSender += this.MessageSender;
            world.Bees.Add(newBee);
        }

        public void Go(Random random)
        {
            if (world.Bees.Count < MaximumBees 
                && Honey > MinimumHoneyForCreatingBees 
                && random.Next(10) == 1)
            {
                AddBee(random);
            }
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
