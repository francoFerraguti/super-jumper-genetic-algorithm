using System.Collections.Generic;
using UnityEngine;

public static class FitnessHelper
{
    public static float GetPopulationTotalFitness(Individual[] population)
    {
        float totalFitness = 0;

        for (int i = 0; i < population.Length; i++)
        {
            totalFitness += population[i].fitness;
        }

        return totalFitness;
    }

    public static Individual[] GetOrderedIndividuals(Individual[] population)
    {
        Individual[] bestIndividuals = (Individual[])population.Clone();

        for (int i = 0; i < bestIndividuals.Length - 1; i++)
        {
            for (int j = i + 1; j < bestIndividuals.Length; j++)
            {
                if (bestIndividuals[j].fitness > bestIndividuals[i].fitness)
                {
                    Individual swapIndividual = bestIndividuals[i];
                    bestIndividuals[i] = bestIndividuals[j];
                    bestIndividuals[j] = swapIndividual;
                }
            }
        }

        return bestIndividuals;
    }
}