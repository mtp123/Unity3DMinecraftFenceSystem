using UnityEngine;

/*
 * X    S    X
 *
 * S    C    s
 *
 * X    S    X
 *
 * C - central fence.
 * S / s - side fences.
 *
 * FencePosition represents S / s position relative to C.
 * eg. s position is RightOfCenter
 */

public enum FencePosition
{
    Up = 0,
    Down = 1 << 0,
    Right = 1 << 1,
    Left = 1 << 2
}

public static class FencePositionExtension
{
    public static FencePosition GetOpposite(this FencePosition position)
    {
        var oppositePosition = FencePosition.Up;

        if (position == FencePosition.Up)
        {
            oppositePosition = FencePosition.Down;
        }
        else if (position == FencePosition.Down)
        {
            oppositePosition = FencePosition.Up;
        }
        else if (position == FencePosition.Left)
        {
            oppositePosition = FencePosition.Right;
        }
        else if (position == FencePosition.Right)
        {
            oppositePosition = FencePosition.Left;
        }

        return oppositePosition;
    }
}

public class Fence : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;

    public void SetPlank(FencePosition position, bool value)
    {
        switch (position)
        {
            case FencePosition.Up:
                this.up.SetActive(value);
                break;

            case FencePosition.Down:
                this.down.SetActive(value);
                break;

            case FencePosition.Right:
                this.right.SetActive(value);
                break;

            case FencePosition.Left:
                this.left.SetActive(value);
                break;

            default:
                break;
        }
    }
}