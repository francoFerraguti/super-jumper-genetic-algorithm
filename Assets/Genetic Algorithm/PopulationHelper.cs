using UnityEngine;

public static class PopulationHelper
{
    public static Individual[] population;

    private static int generationsFinished = 0;
    private static int individualsFinished = 0;

    public static void Init()
    {
        population = new Individual[Config.nIndividualsPerPopulation];

        for (int i = 0; i < population.Length; i++)
        {
            Individual individual = new Individual();
            individual.dna = new DNA();
            population[i] = individual;
        }
    }

    public static void Advance()
    {
        if (individualsFinished >= Config.nIndividualsPerPopulation - 1)
        {
            Debug.Log("just finished generation " + generationsFinished);
            Print(population);
            AdvanceGeneration();
        }
        else
        {
            individualsFinished++;
            StartIndividual(individualsFinished);
        }
    }

    private static void AdvanceGeneration()
    {
        Individual[] nextPopulation = new Individual[Config.nIndividualsPerPopulation];
        Individual[] orderedIndividuals = FitnessHelper.GetOrderedIndividuals(population);

        for (int i = 0; i < Config.nElite; i++)
        {
            nextPopulation[i] = orderedIndividuals[i];
            nextPopulation[i].wasElite = true;
        }
        Debug.Log("ordered generation " + generationsFinished);
        Print(orderedIndividuals);

        //sacar el promedio de fitness, y hacer que la mutación pase empezando por el promedio ese dividido 2 (por ejemplo, si el fitness promedio es 4, empezás a mutar desde el frame 2)
        //y aumentás el mutationRate un toque

        Individual[] childrenIndividuals = ReproductionHelper.GetChildrenIndividuals(population, Config.nIndividualsPerPopulation - Config.nElite);
        MutationHelper.MutatePopulation(childrenIndividuals);

        for (int i = Config.nElite; i < childrenIndividuals.Length + Config.nElite; i++)
        {
            nextPopulation[i] = childrenIndividuals[i - Config.nElite];
        }

        Debug.Log("next generation " + generationsFinished + 1);
        Print(nextPopulation);


        generationsFinished++;
        individualsFinished = 0;
        population = (Individual[])nextPopulation.Clone();
        StartIndividual(0);
    }

    public static void StartIndividual(int index)
    {
        GameObject.Find("Jumper").GetComponent<Jumper>().SetIndividual(population[index]);
        Globals.isPaused = false;
    }

    private static void Print(Individual[] populationToPrint)
    {
        for (int i = 0; i < populationToPrint.Length; i++)
        {
            string dna = "[";

            for (int j = 0; j < populationToPrint[i].dna.jumpFrames.Length; j++)
            {
                dna += populationToPrint[i].dna.jumpFrames[j].ToString("0.00") + ", ";
            }

            dna += "]";

            Debug.Log("E=" + populationToPrint[i].wasElite + ", M=" + populationToPrint[i].wasMutated + ", F=" + populationToPrint[i].fitness + ", DNA=" + dna);
        }
    }


}