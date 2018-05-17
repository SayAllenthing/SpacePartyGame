using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipModuleTypes
{
    LifeSupport,
    Engines,
    MedBay,
    Shields,
    Weapons,
    FTL
}

public class ShipUtils
{
    public static string GetModuleName(ShipModuleTypes type)
    {
        switch (type)
        {
            case ShipModuleTypes.LifeSupport: return "Life Support";
            case ShipModuleTypes.Engines: return "Engines";
            case ShipModuleTypes.MedBay: return "Medical Bay";
            case ShipModuleTypes.Shields: return "Shields";
            case ShipModuleTypes.Weapons: return "Weapons";
            case ShipModuleTypes.FTL: return "FTL";
        }

        return "No Module";
    }
}
