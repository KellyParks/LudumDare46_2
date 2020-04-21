using System;
using UnityEngine;

public class ClampCam2D : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    float nextTimeToSearch = 0f;

    void Update()
    {
        if(targetToFollow == null)
        {
            FindPlayer();
            return;
        }

        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -11.51f, 29f),
            Mathf.Clamp(targetToFollow.position.y, -7f, 4.95f),
            transform.position.z);
    }

    void FindPlayer()
    {
        if(nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if(searchResult != null)
            {
                Debug.Log("camera bug", searchResult);
                targetToFollow = searchResult.transform;
            }
            nextTimeToSearch = Time.time + 0.5f;
        }
    }
}
