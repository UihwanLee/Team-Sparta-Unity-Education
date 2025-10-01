using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal interface IGameObject
    {
        void Start();
        void Update(float elapsed);
        void Render();
    }
}

