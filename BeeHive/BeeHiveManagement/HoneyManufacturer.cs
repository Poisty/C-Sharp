using System;
using BeehiveManagement;

namespace BeeHiveManagement;

public class HoneyManufacturer : Bee
{
    public HoneyManufacturer() : base("Nectar Collector") { }

    public override decimal CostPerShift
    {
        get { return Constants.NECTAR_COLLECTOR_COST; }
    }

    public override bool WorkTheNextShift()
    {
        HoneyVault.ConvertNectarToHoney(Constants.NECTAR_COLLECTED_PER_SHIFT);
        return base.WorkTheNextShift();
    }
}
