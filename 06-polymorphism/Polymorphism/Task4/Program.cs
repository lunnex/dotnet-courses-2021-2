using System;

namespace Task4
{

    interface IMoveable
    {
        public void Walk();
        public void Run();
        public void Teleportation();
        public void Stop();
    }

    class Hero : IMoveable
    {
        public float speedOfWalking { get; set; }
        public float speedOfRunning { get; set; }
        public float posX { get; set; }
        public float posY { get; set; }
        public float healthPoints { get; set; }
        public void Birth() { }
        public void Death() { }
        public virtual void Walk() { }
        public virtual void Run() { }
        public virtual void Teleportation() { }
        public void Stop() { }
    }

    class Enemy : Hero
    {
        public void FindPlayer() { }
        public override void Run() { }
        public override void Walk() { }
        public override void Teleportation() { }
        public void BypassingObstacles() { }

    }

    class Wolf : Enemy
    {

    }

    class Bear : Enemy
    {

    }

    class ClawofTheDeath : Enemy
    {

    }


    class Player : Hero
    {
        public override void Run() { }
        public override void Walk() { }
        public override void Teleportation() { }
    }


    class Bonus
    {
        public void Appearance() { }
        public void Disppearance() { }
    }

    class Apple : Bonus
    {

    }

    class Cherry : Bonus
    {

    }


    class Obstacle
    {
        public float posX { get; set; }
        public float posY { get; set; }
        public void Appearance() { }
    }

    class Tree : Obstacle
    {

    }

    class Stone : Obstacle
    {

    }

    class Field
    {
        private int _width = 800;
        private int _height = 600;

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
