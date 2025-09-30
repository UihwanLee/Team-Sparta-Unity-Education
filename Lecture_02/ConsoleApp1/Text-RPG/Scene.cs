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

        // Scene에서 표시할 모든 오브젝트
        protected List<IGameObject> gameObjects = new List<IGameObject>();

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
