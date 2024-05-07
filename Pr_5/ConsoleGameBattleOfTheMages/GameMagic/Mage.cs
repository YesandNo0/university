using System;
using GameMagic.Spells;
using GameMagic.Events;

namespace GameMagic
{
    public class Mage : Character
    {
        public event AttackHandler OnAttack;

        private List<ISpell> _spells;
        private Shop _shop;


        public Mage(string name, int hp, int coins) : base(name)
        {
            Hp = hp;
            Coins = coins;
            _spells = new List<ISpell>();
            _shop = new Shop();
        }

        public override int SpellsAmount()
        {
            return _spells.Count;
        }
        public override void ShowSpellsInfo()
        {
            Console.WriteLine("Список доступних спелів:");
            if(_spells.Count > 0)
            {
                for (int i = 0; i < _spells.Count; i++)
                {
                    Console.Write($"{i + 1}. {_spells[i].GetType().Name}: ");
                    if (((Spell)_spells[i]).Damage < 0)
                    {
                        Console.Write($"heal = {-((Spell)_spells[i]).Damage} hp, ");
                    }
                    else
                    {
                        Console.Write($"damage = {((Spell)_spells[i]).Damage} hp, ");
                    }
                    Console.WriteLine($"price = {((Spell)_spells[i]).Price} coins.");
                }
            } else
            {
                Console.WriteLine("Спели відсутні!");
            }

        }

        public override void BuySpell(int spellIndex)
        {
            if(Coins >= _shop.AvailableSpells[spellIndex].Price)
            {
                _spells.Add(_shop.AvailableSpells[spellIndex]);
                Coins -= _shop.AvailableSpells[spellIndex].Price;
            } else
            {
                Console.WriteLine($"Вам недостатньо монет на цей спел. Ви маєте [{Coins}] монет.");
            }
        }

        public override void Attack(IDamagebl damagebl, int spellIndex)
        {
            if (_spells[spellIndex].Damage < 0)
                damagebl = this;

            OnAttack?.Invoke(this, new AttackEventArgs(_spells[spellIndex], this, damagebl));

            _spells[spellIndex].CauseDamage(damagebl);
            Mage mage = (Mage)damagebl;
            if(_spells[spellIndex].Damage < 0)
            {
                Console.WriteLine($"[{Name} підлікувався.]");
            }
            else
            {
                Console.WriteLine($"[{Name} надамажив мага: {mage.Name}]");
            }


            _spells.Remove(_spells[spellIndex]);
        }
    }
}
