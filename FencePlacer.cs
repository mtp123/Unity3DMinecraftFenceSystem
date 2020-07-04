using System.Collections.Generic;
using UnityEngine;

public class FencePlacer : MonoBehaviour
{
    public WorldManager World;

    public GameObject ItemFenceNew;

    public GameObject PlaceFence(Vector3 newPosition)
    {
        var newFence = Instantiate(ItemFenceNew, newPosition, Quaternion.identity);
        var newFenceFenceScript = newFence.GetComponent<Fence>();

        var surroundingFences = GetSurroundingFences(newPosition);

        var existingFence = default(GameObject);
        var position = default(FencePosition);

        foreach (var fence in surroundingFences)
        {
            position = fence.Key;
            existingFence = fence.Value;

            // Enable plank on new fence.
            newFenceFenceScript.SetPlank(position, true);

            // Enable opposite plank on existing fence.
            position = position.GetOpposite();
            existingFence.GetComponent<Fence>().SetPlank(position, true);
        }

        return newFence;
    }

    private Dictionary<FencePosition, GameObject> GetSurroundingFences(Vector3 centerPosition)
    {
        var surroundingFences = new Dictionary<FencePosition, GameObject>();

        var checkingPosition = default(Vector3);

        // Up
        if (HasFenceUp(centerPosition, out checkingPosition))
        {
            surroundingFences.Add(FencePosition.Up, World.AllPlaceables[checkingPosition]);
        }

        // Down
        if (HasFenceDown(centerPosition, out checkingPosition))
        {
            surroundingFences.Add(FencePosition.Down, World.AllPlaceables[checkingPosition]);
        }

        // Left
        if (HasFenceLeft(centerPosition, out checkingPosition))
        {
            surroundingFences.Add(FencePosition.Left, World.AllPlaceables[checkingPosition]);
        }

        // Right
        if (HasFenceRight(centerPosition, out checkingPosition))
        {
            surroundingFences.Add(FencePosition.Right, World.AllPlaceables[checkingPosition]);
        }

        return surroundingFences;
    }

    // Examine return value.
    // If true, use "position" out variable.
    private bool HasFenceLeft(Vector3 currentPosition, out Vector3 position)
    {
        var inspectingPosition = currentPosition;

        inspectingPosition.x = currentPosition.x - 1;

        // Returned
        position = inspectingPosition;

        return World.AllPlaceables.ContainsKey(inspectingPosition);
    }

    private bool HasFenceRight(Vector3 currentPosition, out Vector3 position)
    {
        var inspectingPosition = currentPosition;

        inspectingPosition.x = currentPosition.x + 1;

        // Returned
        position = inspectingPosition;

        return World.AllPlaceables.ContainsKey(inspectingPosition);
    }

    private bool HasFenceUp(Vector3 currentPosition, out Vector3 position)
    {
        var inspectingPosition = currentPosition;

        inspectingPosition.z = currentPosition.z + 1;

        // Returned
        position = inspectingPosition;

        return World.AllPlaceables.ContainsKey(inspectingPosition);
    }

    private bool HasFenceDown(Vector3 currentPosition, out Vector3 position)
    {
        var inspectingPosition = currentPosition;

        inspectingPosition.z = currentPosition.z - 1;

        // Returned
        position = inspectingPosition;

        return World.AllPlaceables.ContainsKey(inspectingPosition);
    }
}