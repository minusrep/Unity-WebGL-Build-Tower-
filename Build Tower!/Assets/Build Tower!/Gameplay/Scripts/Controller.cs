

namespace Gameplay.Core
{
    public abstract class Controller
    {

        public virtual bool isInitialized { get; set; }

        public virtual void Awake()
        {
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public abstract void OnGameStateChange(GameState value);
    }
}