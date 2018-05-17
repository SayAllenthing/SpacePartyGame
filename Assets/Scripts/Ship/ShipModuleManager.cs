using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModuleManager : MonoBehaviour
{
    public static ShipModuleManager Instance;

    public List<ShipModule> Modules = new List<ShipModule>();

    private void Awake()
    {
        Instance = this;        
    }

    private void Start()
    {
        ShipPowerManager powerManager = ShipPowerManager.Instance;

        foreach(ShipModule module in Modules)
        {
            powerManager.AddModule(module.Type, module.PowerComponent);
        }        
    }

    public ShipModule GetModule(ShipModuleTypes Type)
    {
        return Modules.Find(m => m.Type == Type);
    }
}

[System.Serializable]
public class ShipModule
{
    public ShipModuleTypes Type;
    public ModulePowerComponent PowerComponent = new ModulePowerComponent();
}

[System.Serializable]
public class ModulePowerComponent
{
    public int MaxPower = 1;
    public int CurrentPower = 0;

    public int Damage = 0;

    public void OnPowerChanged(int power)
    {
        CurrentPower = power;
    }
}
