using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleController : MonoBehaviour
{
    public ShipModuleTypes Type;

    public MenuBase Menu;
    public ShipModule Module;

    private void Start()
    {
        Module = ShipModuleManager.Instance.GetModule(Type);
    }

    public void Toggle()
    {
        Menu.GetComponent<ModuleGeneratorPanel>().Init(Type);
        Menu.Toggle();
    }
}
