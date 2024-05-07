
using GameMagic.Spells;
using GameMagic.Events;

namespace GameMagic
{
    public abstract class Character : IDamagebl
    {
        public event HealthChangedHandler OnHealthChanged;
        public event CoinsChangedHandler OnCoinsChanged;
        public event AttackHandler OnAttack;

        private int _hp;
        private string _name;
        private int _coins;

        protected Character(string name)
        {
            _name = name;
        }

        public int Coins
        {
            get => _coins;
            set
            {
                if (_coins != value)
                {
                    int oldCoins = _coins;
                    _coins = value;
                    OnCoinsChanged?.Invoke(this, new CoinsChangedEventArgs(_coins, oldCoins));
                }
            }
        }

        public int Hp
        {
            get => _hp;
            set
            {
                if (_hp != value)
                {
                    int oldHp = _hp;
                    _hp = value;
                    OnHealthChanged?.Invoke(this, new HealthChangedEventArgs(_hp, oldHp));
                }
            }
        }
        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            if ( damage < 0)
            {
                Console.WriteLine($"Оп, зловив аптечку! Кричить {Name}");
            } else
            {
                Console.WriteLine($"Ай, больно! Кричить {Name}");
            }
        }

        public abstract void Attack(IDamagebl damagebl, int spellIndex);
        public abstract void ShowSpellsInfo();
        public abstract int SpellsAmount();
        public abstract void BuySpell(int spellIndex);
    }
}
