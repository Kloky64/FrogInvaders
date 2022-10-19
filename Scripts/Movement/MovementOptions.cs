using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class MovementOptions
{
    static public void DescendAtNextLine(GameObject gameObject, float lineShift, ref int linesShifted)
    {
        ++linesShifted;
        gameObject.transform.position += -gameObject.transform.up * lineShift;
        
    }
    static public void MoveHorizontally(GameObject gameObject, ref Vector3 movement, int sign)
    {
        movement += sign * gameObject.transform.right;
        
    }
    
    static public void MoveVertically(GameObject gameObject, ref Vector3 movement, int sign)
    {
        movement += sign * gameObject.transform.up;
        
    }
}