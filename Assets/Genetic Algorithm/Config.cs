public static class Config
{

    //genetic algorithm
    public static int nIndividualsPerPopulation;
    public static int nElite;
    public static float mutationRate; //percentage

    //dna
    public static int nJumps;
    public static int minJumpFrame;
    public static int maxJumpFrame;

    //genetic algorithm
    public static void SetIndividualsPerPopulation(int nIndividuals)
    {
        nIndividualsPerPopulation = nIndividuals;
    }
    public static void SetElite(int elite)
    {
        nElite = elite;
    }
    public static void SetMutationRate(float newMutationRate)
    {
        mutationRate = newMutationRate;
    }

    //dna
    public static void SetJumps(int jumps)
    {
        nJumps = jumps;
    }
    public static void SetMinMaxJumpFrames(int min, int max)
    {
        minJumpFrame = min;
        maxJumpFrame = max;
    }
}