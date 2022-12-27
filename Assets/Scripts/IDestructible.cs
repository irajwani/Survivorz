using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructible
{
    public void TakeDamage(int damage);
}