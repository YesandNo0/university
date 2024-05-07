
namespace GameMagic
{
    public interface IDamagebl
    {
        int Hp { get; set; }
        void TakeDamage(int damage);
    }
}
