using UnityEngine;

[CreateAssetMenu(fileName = "New Bloc", menuName = "Block")]
public class Block_SO : ScriptableObject
{
    public char indx;
    public bool spawnPrefab;
    public GameObject prefab;
}
