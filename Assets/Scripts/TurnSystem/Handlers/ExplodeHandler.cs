using System.Collections.Generic;
using Entity;
using Entity.Components;
using Level;
using TurnSystem.Handlers;
using UnityEngine;
using Zenject;

namespace TurnSystem.Events
{
    public class ExplodeHandler: BaseHandler<ExplodeEvent>
    {
        [Inject]
        private readonly LevelMap _levelMap;
        protected override void HandleEvent(ExplodeEvent evt)
        {
            if (evt.Entity.TryGet(out ExplodeComponent explodeComponent))
            {
                explodeComponent.Explode();
            }
            var explodeSourceCoordinates = _levelMap.Entities.GetEntityCoordinates(evt.Entity);
            
            var coordinatesAround = new CoordinatesAroundDetector().GetCoordinatesAround(explodeSourceCoordinates);
            var entitiesAround = new ClosedEntitySearcher(_levelMap).GetClosedEntities(coordinatesAround);
            
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            _levelMap.Entities.RemoveEntity(coordinates.Value);
            
            foreach (var effect in evt.PostDeathEffect.Effects)
            {
                effect.Source = evt.Entity;
                effect.Targets = entitiesAround;
                EventBus.RaiseEvent(effect);
            }
        }
    }
}


public class CoordinatesAroundDetector
{
    public Vector2Int[] GetCoordinatesAround(Vector2Int currentCoordinates)
    {
        var x = currentCoordinates.x;
        var y = currentCoordinates.y;
            
        var left =  new Vector2Int(x - 1, y);
        var right =  new Vector2Int(x + 1, y);
        var up = new Vector2Int(x, 1 + y);
        var down =  new Vector2Int(x, y - 1);
           
        var topLeftCorner = new Vector2Int(x - 1, y + 1);
        var topRightCorner = new Vector2Int(x + 1, y + 1);
        var bottomLeftCorner = new Vector2Int(x - 1, y - 1);
        var bottomRightCorner = new Vector2Int(x + 1, y - 1);

        var coordinates = new Vector2Int[]
            { left, right, up, down, topLeftCorner, topRightCorner, bottomLeftCorner, bottomRightCorner };
        return coordinates;
    }
}

public class ClosedEntitySearcher
{
    private readonly LevelMap _levelMap;
    public ClosedEntitySearcher(LevelMap levelMap)
    {
        _levelMap = levelMap;
    }
    
    public IEntity[] GetClosedEntities(Vector2Int[] currentCoordinates)
    {
        var entities = new List<IEntity>();

        foreach (var coordinate in currentCoordinates)
        {
            var entity = _levelMap.Entities.GetEntity(coordinate);
            if (entity!= null)
            {
                entities.Add(entity);
            }
        }
        return entities.ToArray();
    }
}