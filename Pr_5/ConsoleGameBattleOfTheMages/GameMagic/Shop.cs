using GameMagic.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMagic
{
    public class Shop
    {
        private static List<ISpell> _availableSpells;

        private static int _minimalPrice;

        public Shop()
        {
            _availableSpells = new List<ISpell>
            {
            new FireballLevel1(20, 30),
            new FireballLevel2(40, 50),
            new HealingSpell(-20, 30)
            };

            _minimalPrice = 30;
        }

        public static int MinimalPrice
        {
            get => _minimalPrice;
        }

        public IReadOnlyList<ISpell> AvailableSpells => _availableSpells.AsReadOnly();

        public static void ShowAvailableSpells()
        {
            Console.WriteLine("\nСписок доступних спелів в магазині:");
            for (int i = 0; i < _availableSpells.Count; i++)
            {
                Console.Write($"{i + 1}. {_availableSpells[i].GetType().Name}: ");
                if(((Spell)_availableSpells[i]).Damage < 0)
                {
                    Console.Write($"heal = {-((Spell)_availableSpells[i]).Damage} hp, ");
                } else
                {
                    Console.Write($"damage = {((Spell)_availableSpells[i]).Damage} hp, ");
                }
                Console.WriteLine($"price = {((Spell)_availableSpells[i]).Price} coins.");
            }
        }
    }
}
