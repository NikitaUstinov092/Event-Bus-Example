
    using Zenject;

    namespace Level
    {
        public sealed class LevelMap
        {
            public EntityMap Entities { get; private set; }
        
            public TileMap Tiles { get; private set;}

            [Inject]
            public void Construct(EntityMap entities, TileMap tiles)
            {
                Entities = entities;
                Tiles = tiles;
            }
        }
    }
