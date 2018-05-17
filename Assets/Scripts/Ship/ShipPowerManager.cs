using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPowerManager : MonoBehaviour
{
    public static ShipPowerManager Instance;

    public int MaxPower = 10;    
    public int AvailablePower = 0;

    public int DamagedPower = 0;

    public Dictionary<ShipModuleTypes, ModulePowerComponent> ModulePowerLevels { get; private set; }

    public delegate void ModulePowerChangedDelegate(ShipModuleTypes type, int power);
    public ModulePowerChangedDelegate OnModulePowerChanged;

    private void Awake()
    {
        Instance = this;

        ModulePowerLevels = new Dictionary<ShipModuleTypes, ModulePowerComponent>();
        AvailablePower = MaxPower;
    }

    private void Start()
    {
        
    }

    public void AddModule(ShipModuleTypes type, ModulePowerComponent component)
    {
        ModulePowerLevels.Add(type, component);
        AvailablePower -= component.CurrentPower;
    }

    public void SetModulePowerLevel(ShipModuleTypes type, int power)
    {
        AvailablePower += ModulePowerLevels[type].CurrentPower - power;
        ModulePowerLevels[type].CurrentPower = power;

        if (OnModulePowerChanged != null)
            OnModulePowerChanged.Invoke(type, power);   
    }

    public void IncreasePower(ShipModuleTypes type)
    {
        if (AvailablePower == 0)
            return;

        ModulePowerComponent component = ModulePowerLevels[type];
        if (component.CurrentPower + 1 <= component.MaxPower)
        {
            SetModulePowerLevel(type, component.CurrentPower + 1);
        }
    }

    public void DecreasePower(ShipModuleTypes type)
    {
        ModulePowerComponent component = ModulePowerLevels[type];

        if (component.CurrentPower > 0)
        {
            SetModulePowerLevel(type, component.CurrentPower - 1);
        }
    }
}
