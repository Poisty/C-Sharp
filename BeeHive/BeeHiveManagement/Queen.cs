using System;
using BeehiveManagement;

namespace BeeHiveManagement;

public class Queen : Bee
{
    private Bee[] workers = new Bee[0];
    private decimal eggs = 0;
    private decimal unassignedWorkers = 3;

    public bool CanAssignWorkers { get { return unassignedWorkers >= 1; } }
    public string StatusReport { get; private set; } = string.Empty;

    public override decimal CostPerShift
    {
        get { return Constants.QUEEN_COST_PER_SHIFT; }
    }

    public Queen() : base("Queen")
    {
        AssignBee("Nectar Collector");
        AssignBee("Honey Manufacturer");
        AssignBee("Egg Care");
    }

    public void AssignBee(string? job)
    {
        switch (job)
        {
            case "Nectar Collector":
                AddWorker(new NectarCollector());
                break;
            case "Honey Manufacturer":
                AddWorker(new HoneyManufacturer());
                break;
            case "Egg Care":
                AddWorker(new EggCare(this));
                break;
        }
        UpdateStatusReport(true);
    }

    private void AddWorker(Bee worker)
    {
        if (unassignedWorkers >= 1)
        {
            unassignedWorkers--;
            Array.Resize(ref workers, workers.Length + 1);
            workers[workers.Length - 1] = worker;
        }
    }
    
    private void UpdateStatusReport(bool allWorkersDidTheirJobs)
    {
        StatusReport = $"Vault report: \n {HoneyVault.StatusReport}\n" + 
        $"Egg count: {eggs:0.00}\nUnassigned workers: {unassignedWorkers:0.00}\n" +
        $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}\n" +
        $"{WorkerStatus("Egg Care")}\nTOTAL WORKERS: {workers.Length}";

        if (!allWorkersDidTheirJobs)
        {
            StatusReport += "\nWARNING: NOT ALL WORKERS DID THEIR JOBS!";
        }
    }

    private string WorkerStatus(string job)
    {
        int count = 0;
        foreach (Bee worker in workers)
        {
            if (worker.Job == job)
            {
                count++;
            }
        }
        string s = count == 1 ? "" : "s";
        return $"{count} {job} bee{s}";
    }

    public void ReportEggConversion(decimal eggsToConvert)
    {
        if (eggs >= eggsToConvert)
        {
            eggs -= eggsToConvert;
            unassignedWorkers += eggsToConvert;
        }
    }

    public override bool WorkTheNextShift()
    {
        eggs += Constants.EGGS_PER_SHIFT;
        bool allWorkersDidTheirJobs = true;
        foreach (Bee worker in workers)
        {
            if (!worker.WorkTheNextShift())
            {
                allWorkersDidTheirJobs = false;
            }
        }
        HoneyVault.ConsumeHoney(unassignedWorkers * Constants.HONEY_PER_UNASSIGNED_WORKER);
        UpdateStatusReport(allWorkersDidTheirJobs);
        return base.WorkTheNextShift();
    }
}
