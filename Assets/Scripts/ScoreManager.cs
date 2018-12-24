using UnityEngine;
using UnityEngine.UI;

public static class ScoreManager
{
    private static int score = 0;

    public static void Add(int value)
    {
        score += value;
        Refresh();
    }

    public static void Reset()
    {
        score = 0;
        Refresh();
    }

    static void Refresh()
    {
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
    }
}