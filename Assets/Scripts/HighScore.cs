using UnityEngine;

public static class HighScore
{
    private const string ScoreKey = "BestScore";
    private const string NameKey = "BestScoreName";
    private const string CurrentPlayerKey = "CurrentPlayerName";

    public static void TrySaveScore(int score)
    {
        // El récord predeterminado es 0.
        int bestScore = PlayerPrefs.GetInt(ScoreKey, 0);

        // Solo guardamos si la puntuación nueva supera el récord.
        if (score > bestScore)
        {
            string playerName = PlayerPrefs.GetString(CurrentPlayerKey, "Jugador");

            PlayerPrefs.SetInt(ScoreKey, score);
            PlayerPrefs.SetString(NameKey, playerName);
            PlayerPrefs.Save();
        }
    }

    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt(ScoreKey, 0);
    }

    public static string GetBestScoreName()
    {
        return PlayerPrefs.GetString(NameKey, "Nadie");
    }

    public static void ResetScore()
    {
        PlayerPrefs.DeleteKey(ScoreKey);
        PlayerPrefs.DeleteKey(NameKey);
        PlayerPrefs.Save();
    }
}

