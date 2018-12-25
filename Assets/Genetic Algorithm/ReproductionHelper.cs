using UnityEngine;

public static class ReproductionHelper
{
    public static Individual[] GetChildrenIndividuals(Individual[] population, int nChildren)
    {
        Individual[] childrenIndividuals = new Individual[nChildren];

        for (int i = 0; i < nChildren; i++)
        {
            Individual parent1 = SpinRoulette(population);
            Individual parent2 = SpinRoulette(population, parent1);
            childrenIndividuals[i] = Crossover(parent1, parent2);
        }

        return childrenIndividuals;
    }

    private static Individual Crossover(Individual parent1, Individual parent2)
    {
        Individual child = new Individual();
        child.dna = new DNA();

        for (int i = 0; i < parent1.dna.jumpFrames.Length; i++)
        {
            child.dna.jumpFrames[i] = (i % 2 == 0) ? parent1.dna.jumpFrames[i] : parent2.dna.jumpFrames[i];
        }

        return child;
    }

    private static Individual SpinRoulette(Individual[] population, Individual alreadySelectedIndividual = null)
    {
        float totalFitness = FitnessHelper.GetPopulationTotalFitness(population);
        float rouletteResult = Random.Range(0, totalFitness);
        float portionCounter = 0;

        for (int i = 0; i < population.Length; i++)
        {
            portionCounter += population[i].fitness;

            if (portionCounter > rouletteResult)
            {
                return (alreadySelectedIndividual == population[i]) ? SpinRoulette(population, alreadySelectedIndividual) : population[i];
            }
        }

        Debug.LogError("roulette error: " + totalFitness + " | " + rouletteResult);
        return null;
    }
}