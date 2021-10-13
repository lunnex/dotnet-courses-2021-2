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

    abstract class GameObject
    {
        public float Xpos;
        public float Ypos;

        public GameObject(int x, int y)
        {
            Xpos = x;
            Ypos = y;
        }
    }

     abstract class Hero : GameObject , IMoveable
    {
        public float speedOfWalking { get; set; }
        public float speedOfRunning { get; set; }

        public float healthPoints { get; set; }
        public void Birth() { }
        public void Death() { }
        public abstract void Walk();
        public abstract void Run();
        public abstract void Teleportation();
        public void Stop() { }

        public Hero (int x, int y): base (x, y)
        {

        }
    }

    abstract class Enemy : Hero
    {
        public void FindPlayer() { }
        public void BypassingObstacles() { }
        public Enemy(int x, int y) : base (x,y)
        {

        }

    }

    class Wolf : Enemy
    {
        public override void Walk() { }
        public override  void Run() { }
        public override void Teleportation() { }
        public Wolf(int x, int y) : base(x, y)
        {

        }
    }

    class Bear : Enemy
    {
        public override void Walk() { }
        public override void Run() { }
        public override void Teleportation() { }
        public Bear(int x, int y) : base(x, y)
        {

        }
    }

    class ClawofTheDeath : Enemy
    {
        public override void Walk() { }
        public override void Run() { }
        public override void Teleportation() { }
        public ClawofTheDeath(int x, int y) : base(x, y)
        {

        }
    }


    class Player : Hero
    {
        public override void Run() { }
        public override void Walk() { }
        public override void Teleportation() { }
        public Player(int x, int y) : base(x, y)
        {

        }
    }


    class Bonus: GameObject
    {
        public void Appearance() { }
        public void Disppearance() { }
        public Bonus(int x, int y) : base(x, y)
        {

        }
    }

    class Apple : Bonus
    {
        public Apple(int x, int y) : base(x, y)
        {

        }
    }

    class Cherry : Bonus
    {
        public Cherry(int x, int y) : base(x, y)
        {

        }
    }


    class Obstacle : GameObject
    {
        public float PosX { get; set; }
        public float PosY { get; set; }
        public void Appearance() { }
        public Obstacle(int x, int y) : base(x, y)
        {

        }
    }

    class Tree : Obstacle
    {
        public Tree(int x, int y) : base(x, y)
        {

        }
    }

    class Stone : Obstacle
    {
        public Stone(int x, int y) : base(x, y)
        {

        }
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
