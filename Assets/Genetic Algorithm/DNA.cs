using UnityEngine;

public class DNA
{
    public int[] jumpFrames;

    public DNA()
    {
        jumpFrames = GetRandomJumpFrames();
    }

    private static int[] GetRandomJumpFrames()
    {
        int[] jumpFrames = new int[Config.nJumps];

        for (int i = 0; i < jumpFrames.Length; i++)
        {
            jumpFrames[i] = GetRandomJumpFrame();
        }

        return jumpFrames;
    }

    public static int GetRandomJumpFrame()
    {
        return Random.Range(Config.minJumpFrame, Config.maxJumpFrame);
    }
}