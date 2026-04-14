using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions
{
    //these are literally just for Delegates lol
    public static float Add(float iOne, float iTwo) { return iOne + iTwo; }
    public static float Subtract(float iOne, float iTwo) { return iOne - iTwo; }
    public static float Multiply(float iOne, float iTwo) { return iOne * iTwo; }
    public static float Divide(float iOne, float iTwo) { return iOne / iTwo; }

    public static Vector2 RandomVectorAdjustment(Vector2 startingVector, float severity)
    {
        Vector2 output;
        float offsetX = UnityEngine.Random.Range(severity * -1, severity);
        float offsetY = UnityEngine.Random.Range(severity * -1, severity);

        output = new Vector2(startingVector.x + offsetX, startingVector.y + offsetY);

        return output;
    }

    public static int SafeAddition(int startNum, int increment, int maxValue, int minValue = 0, bool wrapAround = false)
    {
        int output = startNum + increment;

        while (output > maxValue)
        {
            if (wrapAround)
                output = minValue <= 0 ? (output % maxValue) - 1 : (output % maxValue);
            else
                output = maxValue;

        }
        while (output < minValue)
        {
            if (wrapAround)
                output = minValue <= 0 ? output + maxValue + 1 : output + maxValue;
            else
                output = minValue;
        }
        return output;
    }

    public static T[] RemoveElementFromArray<T>(T[] array, int index, bool preserveLength = true)
    {
        T[] output = new T[preserveLength ? array.Length : array.Length - 1];

        for(int i = 0; i < array.Length; i++)
        {
            if (i < index)
                output[i] = array[i];
            else if (i > index)
            {
                output[i - 1] = array[i];
            }
        }

        return output;

    }

    public static T[] GroupNonNullArrayEntries<T>(T[] startingArray, int length)
    {
        T[] output = new T[length];
        int j = 0;
        for (int i = 0; i < startingArray.Length; i++)
        {
            if (startingArray[i] == null)
            {
                continue;
            }
            else
            {
                output[j] = startingArray[i];
                j++;
            }
        }

        return output;
    }

    public static T[] RemoveNullEntriesFromArray<T>(T[] startingArray)
    {
        T[] output = new T[0];

        for (int i = 0; i < startingArray.Length; i++)
        {
            if (startingArray[i] == null)
            {
                continue;
            }
            else
            {
                output = output.Append(startingArray[i]).ToArray();
            }
        }

        return output;
    }

}
