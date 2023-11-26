using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TextRPG.Entity;

namespace TextRPG.DataManager
{
    class GameData
    {
        public List<Character> characters { get; set; }

        public GameData()
        {
            characters = new List<Character>();
        }

        public void SaveGame(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(this, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"저장 중 오류 발생: {ex.Message}");
            }
        }

        public static GameData LoadGameData()
        {
            try
            {
                string jsonString = File.ReadAllText("TextRPG_SaveData.json");
                return JsonSerializer.Deserialize<GameData>(jsonString);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"로드 중 오류 발생: {ex.Message}");
                // 파일이 없거나 읽기 실패 시, null을 반환
                return null;
            }
        }
    }
}
