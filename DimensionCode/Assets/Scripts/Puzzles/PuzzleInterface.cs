using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PuzzleInterface
{
    string GetPart();
    string GetLevel();
    Vector3 GetSpawnPosition();
    Vector3 GetSpawnRotation();
    void ChangeToEndState();
}
