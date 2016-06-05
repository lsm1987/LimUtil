﻿using System;

/// <summary>
/// 아이템 식별자
/// </summary>
public struct ItemId : IComparable<ItemId>, IEquatable<ItemId>
{
    private readonly uint value;

    public static readonly ItemId InvalidId = new ItemId();

    public ItemId(string value)
    {
        this.value = Convert.ToUInt32(value);
    }

    public ItemId(uint value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public uint ToUInt32()
    {
        return value;
    }

    public override int GetHashCode()
    {
        return value.GetHashCode();
    }

    public bool Equals(ItemId other)
    {
        return this == other;
    }

    public override bool Equals(object obj)
    {
        return (obj is ItemId) && this == (ItemId)obj;
    }

    public static bool operator ==(ItemId a, ItemId b)
    {
        return a.value == b.value;
    }

    public static bool operator !=(ItemId a, ItemId b)
    {
        return !(a == b);
    }

    public int CompareTo(ItemId other)
    {
        if (value < other.value)
        {
            return -1;
        }
        else if (value > other.value)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}