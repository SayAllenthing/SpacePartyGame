using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StationStatus
{
    Working,
    Damaged,
    Offline
}

public class StationController : MonoBehaviour
{
    public StationStatus Status;

    public float CurrentHealth;
    public float MaxHealth;

    public int PlayerCount;

    public ProgressBar Bar;

	// Use this for initialization
	void Start ()
    {
        CurrentHealth = MaxHealth;
        Bar.SetProgress(CurrentHealth / MaxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PlayerCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            PlayerCount--;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && PlayerCount > 0)
        {
            Heal(10);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(25);
        }        
    }

    public void Heal(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + damage, 0, MaxHealth);
        Bar.SetProgress(CurrentHealth / MaxHealth);

        if (CurrentHealth == MaxHealth)
            Bar.Hide();
    }    

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        Bar.SetProgress(CurrentHealth / MaxHealth);

        if (CurrentHealth != MaxHealth)
            Bar.Show();
    }
}
