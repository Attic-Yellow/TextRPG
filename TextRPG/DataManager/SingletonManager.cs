using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.DataManager
{
    public class SingletonManager
    {
        private static PlayerData instance;

        private SingletonManager() { }

        public static PlayerData GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerData();
            }
            return instance;
        }

        public static void SetInstance(PlayerData playerData)
        {
            instance = playerData;
        }
    }
}
