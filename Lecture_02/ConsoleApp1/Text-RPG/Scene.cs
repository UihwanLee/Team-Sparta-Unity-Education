using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    internal class Scene
    {
        protected int index;
        protected UIManager uiManager;

        public Scene(int index, UIManager uIManager)
        {
            this.index = index;
            this.uiManager = uIManager;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }
    }
}
