using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ModuleGeneratorPanel : MenuBase
{
    public TMP_Text ModuleNameText;
    public TMP_Text ReactorPowerText;
    public TMP_Text ModulePowerText;

    ShipModuleTypes Type;

    public void Init(ShipModuleTypes type)
    {
        Type = type;
    }

    protected override void OnShow()
    {
        base.OnShow();

        ModuleNameText.text = ShipUtils.GetModuleName(Type);

        ReactorPowerText.text = ShipPowerManager.Instance.AvailablePower.ToString();
        ModulePowerText.text = ShipPowerManager.Instance.ModulePowerLevels[Type].CurrentPower.ToString();

        ShipPowerManager.Instance.OnModulePowerChanged += OnModulePowerChanged;
    }

    private void OnModulePowerChanged(ShipModuleTypes type, int power)
    {
        if(type == Type)
        {
            ReactorPowerText.text = ShipPowerManager.Instance.AvailablePower.ToString();
            ModulePowerText.text = ShipPowerManager.Instance.ModulePowerLevels[Type].CurrentPower.ToString();
        }        
    }

    protected override void OnHide()
    {
        base.OnHide();

        ShipPowerManager.Instance.OnModulePowerChanged -= OnModulePowerChanged;
    }

    public void IncreasePower()
    {
        ShipPowerManager.Instance.IncreasePower(Type);
    }

    public void DecreasePower()
    {
        ShipPowerManager.Instance.DecreasePower(Type);
    }
}
