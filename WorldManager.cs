using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public FencePlacer FencePlacer;

    public Dictionary<Vector3, GameObject> AllPlaceables = new Dictionary<Vector3, GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        var position = new Vector3(0, 0, 0);

        Place(position);

        var position2 = new Vector3(0, 0, 1);
        var position3 = new Vector3(0, 0, 2);
        var position4 = new Vector3(1, 0, 2);

        Place(position2);
        Place(position3);
        Place(position4);
    }

    private void Place(Vector3 position)
    {
        if (!AllPlaceables.ContainsKey(position))
        {
            var newFence = FencePlacer.PlaceFence(position);

            AllPlaceables[position] = newFence;
        }
    }
}