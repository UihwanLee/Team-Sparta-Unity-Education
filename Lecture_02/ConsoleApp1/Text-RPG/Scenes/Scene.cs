using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Scenes
{
    internal class Scene
    {
        protected int index;

        // Scene에서 표시할 모든 오브젝트
        protected List<IGameObject> gameObjects = new List<IGameObject>();

        public Scene(int index)
        {
            this.index = index;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }
    }
}
