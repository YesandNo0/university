namespace GameMagic.Spells
{
    public abstract class Spell : ISpell
    {
        private int _damage;
        private int _price;

        public int Damage
        {
            get => _damage;
            internal set => _damage = value;
        }

        public int Price
        {
            get => _price;
            internal set => _price = value;
        }

        public void CauseDamage(IDamagebl damagebl)
        {
            damagebl.TakeDamage(_damage);
        }
    }
}
