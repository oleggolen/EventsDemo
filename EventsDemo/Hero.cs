using EventsDemo.EventArgs;
using EventsDemo.EventHandlers;

namespace EventsDemo
{
    public class Hero
    {
        public int Hp { get; private set; }
        public string Name { get; set; }

        public event HeroDiedEventHandler? HeroDied;

        public Hero(string name)
        {
            Hp = 10;
            Name = name;
        }

        public void Attack(Hero hero)
        {
            if (hero.Hp <= 0)
            {
                if(HeroDied!=null)
                    HeroDied(this, new HeroDiedEventArgs());
                return;
            }

            if (Hp <= 0)
            {
                HeroDied?.Invoke(this, new HeroDiedEventArgs());
                return;
            }

            hero.ReceiveDamage();
                
        }

        private void ReceiveDamage()
        {
            Hp -= 2;

        }
    }
}