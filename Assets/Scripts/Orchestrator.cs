using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    void Start()
    {
        Config.SetIndividualsPerPopulation(14);
        Config.SetElite(4);
        Config.SetMutationRate(4.5f);
        Config.SetJumps(30);
        Config.SetMinMaxJumpFrames(0, 80);

        PopulationHelper.Init();
        PopulationHelper.StartIndividual(0);
    }

}