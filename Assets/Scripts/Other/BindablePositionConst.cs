using UnityEngine;

public static class BindablePositionConst
{
    public static BindablePositionPreset Pigeon = new BindablePositionPreset(
        Enums.Direction.TopLeft, new Vector3(5.75f, 0f, 0f));

    public static BindablePositionPreset DeadZoneTop = new BindablePositionPreset(
        Enums.Direction.Top, new Vector3(0f, 0.5f, 0f));

    public static BindablePositionPreset DeadZoneBottom = new BindablePositionPreset(
        Enums.Direction.Bottom, new Vector3(0f, -0.5f, 0f));
}