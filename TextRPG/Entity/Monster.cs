using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity
{
    public enum MonsterType
    {
        Slime,
        Goblin,
        Kobold,
        Lich,
        Dragon
    }

    public abstract class Monster : Entity
    {
        public MonsterType Type { get; private set; }
        public int Level { get; private set; }

        protected Monster(MonsterType type, int level)
            : base(0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        {
            Type = type;
            Level = level;
            InitStats();
        }

        protected abstract void InitStats();

        public int CalculateExperience(int characterLevel)
        {
            int baseExp = CalculateBaseExperience();
            int exp = baseExp * Level;

            if (characterLevel > Level)
            {
                exp -= (characterLevel - Level) * 2;
            }

            return Math.Max(exp, 0);
        }

        private int CalculateBaseExperience()
        {
            switch (Type)
            {
                case MonsterType.Slime: return 5;
                case MonsterType.Goblin: return 10;
                case MonsterType.Kobold: return 15;
                case MonsterType.Lich: return 25;
                case MonsterType.Dragon: return 50;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
