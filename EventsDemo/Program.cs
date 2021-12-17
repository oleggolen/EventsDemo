using EventsDemo;
using EventsDemo.EventArgs;

void HeroDied(object sender, HeroDiedEventArgs args)
{
    if (!(sender is Hero hero))
        return;
    Console.WriteLine($"{hero.Name} is dead");
}

void Lose(object sender, HeroDiedEventArgs args)
{
    Console.WriteLine($"{(sender as Hero)?.Name} lose");
}
var knight = new Hero("Knight");
knight.HeroDied += HeroDied;
knight.HeroDied += Lose;
var archer = new Hero("Archer");
archer.HeroDied += HeroDied;
archer.HeroDied += Lose;
while (knight.Hp > 0 && archer.Hp > 0)
{
    knight.Attack(archer);
    archer.Attack(knight);
}