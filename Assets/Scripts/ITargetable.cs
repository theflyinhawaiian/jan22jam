using UnityEngine;

public interface ITargetable
{
	float GetSpawnBlockingRadius();

	Transform transform { get; }
}
