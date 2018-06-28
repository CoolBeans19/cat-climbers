using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CheckWall {

    public static bool med(Vector3 pos)
    {
        Collider2D c = Physics2D.OverlapCircle(pos, 0.3f, LayerMask.GetMask("Rock"));
        if (c != null)
        {
            return true;
        }
        return false;
    }
}
