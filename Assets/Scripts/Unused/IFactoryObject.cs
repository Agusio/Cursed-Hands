using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryObject
{
    public string ObjectType { get; }
    public void Initialize();
}
