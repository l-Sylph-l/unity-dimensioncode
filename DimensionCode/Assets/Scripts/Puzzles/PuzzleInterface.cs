using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PuzzleInterface
{
    string GetPart();
    string GetLevel();
    void ChangeToEndState();
}
