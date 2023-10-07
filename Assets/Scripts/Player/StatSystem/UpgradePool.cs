using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade Pool", fileName = "New Upgrade Pool")]
public class UpgradePool : ScriptableObject
{
    public List<UpgradeBase> PoolItems = new();
}
