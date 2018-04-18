using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public List<GameObject> ActivePlayers = new List<GameObject>();

    bool Open = false;

    public Transform DoorLeft;
    public Transform DoorRight;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ActivePlayers.Add(other.gameObject);
            ReconcilePlayers();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ActivePlayers.Remove(other.gameObject);
            ReconcilePlayers();
        }
    }

    private void ReconcilePlayers()
    {
        if(!Open && ActivePlayers.Count > 0)
        {
            StartCoroutine(OpenDoor());
        }
        else if(Open && ActivePlayers.Count == 0)
        {
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        Open = true;

        float startTime = Time.time;
        float endTime = startTime + (DoorRight.localScale.x / 2);

        float startScale = DoorLeft.transform.localScale.x;

        while (Time.time < endTime && Open)
        {
            float progress = (Time.time - startTime) / (endTime - startTime);

            Vector3 scale = DoorLeft.transform.localScale;
            scale.x = Mathf.Lerp(startScale, 0, progress);

            DoorLeft.transform.localScale = scale;
            DoorRight.transform.localScale = scale;

            yield return new WaitForEndOfFrame();
        }

        if (Open)
        {
            Vector3 finalScale = DoorLeft.transform.localScale;
            finalScale.x = 0;

            DoorLeft.transform.localScale = finalScale;
            DoorRight.transform.localScale = finalScale;
        }

        yield return null;
    }

    IEnumerator CloseDoor()
    {
        Open = false;

        float startTime = Time.time;
        float endTime = startTime + (0.5f - DoorRight.localScale.x);

        float startScale = DoorLeft.transform.localScale.x;

        while (Time.time < endTime && !Open)
        {
            float progress = (Time.time - startTime) / (endTime - startTime);

            Vector3 scale = DoorLeft.transform.localScale;
            scale.x = Mathf.Lerp(startScale, 1, progress);

            DoorLeft.transform.localScale = scale;
            DoorRight.transform.localScale = scale;

            yield return new WaitForEndOfFrame();
        }

        if (!Open)
        {
            Vector3 finalScale = DoorLeft.transform.localScale;
            finalScale.x = 1;

            DoorLeft.transform.localScale = finalScale;
            DoorRight.transform.localScale = finalScale;
        }

        yield return null;
    }
}
