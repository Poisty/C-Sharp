using System;
using BeehiveManagement;

namespace BeeHiveManagement;

public class HoneyManufacturer : Bee
{
    public HoneyManufacturer() : base("Honey Manufacturer") { }

    public override decimal CostPerShift
    {
        get { return Constants.HONEY_MANUFACTURER_COST; }
    }

    public override bool WorkTheNextShift()
    {
        HoneyVault.ConvertNectarToHoney(Constants.NECTAR_COLLECTED_PER_SHIFT);
        return base.WorkTheNextShift();
    }
}
