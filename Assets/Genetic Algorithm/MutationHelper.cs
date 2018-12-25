using UnityEngine;

public static class MutationHelper
{
    public static void MutatePopulation(Individual[] population)
    {
        for (int i = 0; i < population.Length; i++)
        {
            MutateIndividual(population[i]);
        }
    }

    private static void MutateIndividual(Individual individual)
    {
        int[] currentJumpFrames = individual.dna.jumpFrames;
        int[] newJumpFrames = new int[currentJumpFrames.Length];

        for (int i = 0; i < currentJumpFrames.Length; i++)
        {
            if (Random.Range(0, 10000) < Config.mutationRate * 100)
            {
                newJumpFrames[i] = DNA.GetRandomJumpFrame();
                individual.wasMutated = true;
            }
            else
            {
                newJumpFrames[i] = currentJumpFrames[i];
            }
        }

        individual.dna.jumpFrames = newJumpFrames;
    }
}