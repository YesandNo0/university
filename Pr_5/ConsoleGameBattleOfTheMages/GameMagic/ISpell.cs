
namespace GameMagic
{
    public interface ISpell
    {
        int Damage { get; }
        int Price { get; }

        void CauseDamage(IDamagebl damagebl);
    }
}
