using Entity;
using Entity.Components;
using UnityEngine;

public class EntityObjectDestroyer : MonoBehaviour
{
   public void DestroyDeadObjects()
   {
     var entities =  GetComponentsInChildren<IEntity>();

     foreach (var entity in entities)
     {
         if (entity.TryGet(out HitPointsComponent hpComponent))
         {
             if(hpComponent.Value > 0)
                 continue;
         }
         
         if (entity.TryGet(out DestroyComponent destroyComponent))
         {
             destroyComponent.Destroy();
         }
     }
   }
}
