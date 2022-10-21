using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehiveSimulator
{
    enum BeeState
    {
        Idle,
        FlyingToFlower,
        GetheringNectar,
        ReturningToHive,
        MakingHoney,
        Retired
    }

    class Bee
    {
        private const double HoneyConsumed = 0.5;
        private const int MoveRate = 3;
        private const double MinimumFlowerNectar = 1.5;
        private const int CareerSpan = 1000;

        public int Age { get; private set; }
        public bool InsideHive { get; private set; }
        public double NectarCollected { get; private set; }

        private Point location;
        public Point Location { get { return location; } }

        private int ID;
        private Flower destinationFlower;

        public BeeState CurrentState { get; private set; }
        
        public Bee(int id, Point location)
        {
            ID = id;
            Age = 0;
            this.location = location;
            InsideHive = true;
            CurrentState = BeeState.Idle;
            destinationFlower = null;
            NectarCollected = 0;
        }

        public void Go(Random rand)
        {
            Age++;
            switch (CurrentState)
            {
                case BeeState.Idle:
                    if (Age > CareerSpan)
                    {
                        CurrentState = BeeState.Retired;
                    }
                    else
                    {
                        // TODO
                    }
                    break;
                case BeeState.FlyingToFlower:
                    // TODO 
                    break;
                case BeeState.GetheringNectar:
                    double nectar = destinationFlower.HarvestNectar();
                    if (nectar > 0)
                    {
                        NectarCollected += nectar;
                    }
                    else
                    {
                        CurrentState = BeeState.ReturningToHive;
                    }
                    break;
                case BeeState.MakingHoney:
                    if (NectarCollected < 0.5)
                    {
                        NectarCollected = 0;
                        CurrentState = BeeState.Idle;
                    }
                    else
                    {
                        // TODO 
                    }
                    break;
                case BeeState.Retired:
                    // TODO: inclomplete
                    break;
            }
        }

        private bool MoveTowardsLocation(Point destination)
        {
            if (Math.Abs(destination.X - location.X) <= MoveRate &&
                Math.Abs(destination.Y - location.Y) <= MoveRate)
            {
                return true;
            }

            if (destination.X > location.X)
            {
                location.X += MoveRate;
            }
            else if (destination.X < location.X)
            {
                location.X -= MoveRate;
            }

            if (destination.Y > location.Y)
            {
                location.Y += MoveRate;
            }
            else if (destination.Y < location.Y)
            {
                location.Y -= MoveRate;
            }
            return false;
        }
    }
}
