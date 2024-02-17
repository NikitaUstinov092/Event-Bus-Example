
    using Entity.Components;
    using TurnSystem.Events;
    using TurnSystem.Events.Effect;

    namespace TurnSystem.Handlers.Effect
     {
         public sealed class PushEffectHandler : BaseHandler<PushEffectEvent>
         {
             protected override void HandleEvent(PushEffectEvent evt)
             {
                 var coordinates = evt.Source.Get<CoordinatesComponent>();
                 foreach (var entity in evt.Targets)
                 {
                     var targetCoordinates = entity.Get<CoordinatesComponent>();
                     var direction = targetCoordinates.Value - coordinates.Value;
                     EventBus.RaiseEvent(new ForceDirectionEvent(entity, direction));
                 }
                
             }
         }
     }
