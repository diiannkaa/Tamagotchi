using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public PetController pet;
    public float petMoveTimer, originalpetMoveTimer;
    public Transform[] waypoints;
    public NeedsController needsController;
    public static PetManager instance;
    private void Awake()
    {
        originalpetMoveTimer = petMoveTimer;
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetManager in the Scene");
    }
    private void Update()
    {
        if (petMoveTimer > 0)
            petMoveTimer -= Time.deltaTime;
        else
        {
            MovePetToRandomWaypoint();
            petMoveTimer = originalpetMoveTimer;
        }
    }
    private void MovePetToRandomWaypoint()
    {
        int randomWaypoint = Random.Range(0, waypoints.Length);
        pet.Move(waypoints[randomWaypoint].position);
    }
    public void Die()
    {

    }
}
