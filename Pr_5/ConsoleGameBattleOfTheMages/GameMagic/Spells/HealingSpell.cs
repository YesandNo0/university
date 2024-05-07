namespace GameMagic.Spells
{
    public class HealingSpell : Spell
    {
        public HealingSpell(int heal, int price)
        {
            Damage = heal;
            Price = price;
        }
    }
}
