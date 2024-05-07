using System;

namespace GameMagic.Events
{
    public delegate void AttackHandler(object sender, AttackEventArgs e);

    public class AttackEventArgs : EventArgs
    {
        public ISpell Spell { get; }
        public Character Attacker { get; }
        public IDamagebl Target { get; }

        public AttackEventArgs(ISpell spell, Character attacker, IDamagebl target)
        {
            Spell = spell;
            Attacker = attacker;
            Target = target;
        }
    }
}
