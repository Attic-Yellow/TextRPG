using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity.Characters
{
    public class ExperienceManager
    {
        public static void GainExperience(Character character, int amount)
        {
            character.Experience += amount;
            CheckLevelUp(character);
        }

        private static void CheckLevelUp(Character character)
        {
            // 경험치에 따른 레벨업 로직
            // 예: 100 경험치마다 레벨업
            while (character.Experience >= 100 * character.Level)
            {
                character.Experience -= 100 * character.Level;
                CharacterStatsManager.LevelUp(character); 
            }
        }
    }
}
