using System;

public static class Enums
{
    public enum KeyPlayerPrefs
    {
        highScore,
        music,
        sound,
        ui,
        learning
    }

    public enum ConflictZones
    {
        isDamage,
        isAddEnergy,
        isDamageAndAddEnergy,
    }

    public enum Direction
    {
        Top,
        Right,
        Bottom,
        Left
    }

    public enum TypeEvents
    {
        player,
        conflictZones
    }

    public enum TypeMove
    {
        move,
        localMove,
        moveAnchor
    }

    public enum TypeLoopMove
    {
        RandomMove,
        RandomMoveAnchor,
        LoopRandomRotate,
        LoopRotate
    }

    [Flags]
    public enum PlayerEvents
    {
        healthOnDecrease = 1 << 0,
        healthOnIncrease = 1 << 1,
        healthOnZeroing = 1 << 2,
        energyOnDecrease = 1 << 3,
        energyOnIncrease = 1 << 4,
        energyOnZeroing = 1 << 5,
    }

    public enum TypeStat
    {
        Health,
        Energy
    }
}