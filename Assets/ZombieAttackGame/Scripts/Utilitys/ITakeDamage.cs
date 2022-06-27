using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilitys
{
    public interface ITakeDamage
    {
        public void InitializeTakeDamage(); //NOTIFY: Responsibility for setting layer,call this func in start or setup layer in inspector
        public int TakeDamage(int damage);
    }
}