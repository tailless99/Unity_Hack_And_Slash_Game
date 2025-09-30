using UnityEngine;

public class CharacterUtility
{
    public static float GetDistanceToGround(Vector3 position, LayerMask layermask, float maxDistance) {
        if(Physics.Raycast(position, Vector3.down, out RaycastHit hit, maxDistance, layermask)) {
            return hit.distance;
        }
        else
            return maxDistance;
    }
}
