using Entity.Player;
using GamePlay;
using GamePlay.Input;
using Level;
using Tasks.Turn;
using Tasks.Visual;
using Turn;
using TurnSystem;
using TurnSystem.Handlers;
using TurnSystem.Handlers.Effect;
using TurnSystem.Handlers.Visual;
using Zenject;

namespace DI
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        public override void InstallBindings()
        {
            ConfigureLevel();
            ConfigurePlayer();
            ConfigureHandlers();
            ConfigureTurn();
           // ConfigureVisual();
            
            Container.Bind<PlayerTurnTask>().AsSingle();
          //  Container.Bind<VisualTurnTask>().AsSingle();
        }

        private void ConfigureLevel()
        {
            Container.Bind<TileMap>().FromComponentInHierarchy().AsSingle();;
            Container.Bind<EntityMap>().AsSingle();;
            Container.Bind<LevelMap>().AsSingle();;
        }

        private void ConfigurePlayer()
        {
            Container.Bind<KeyboardInput>().FromComponentInHierarchy().AsSingle();;
            Container.BindInterfacesAndSelfTo<PlayerService>().FromComponentInHierarchy().AsSingle();
        }

        private void ConfigureHandlers()
        {
            Container.Bind<EventBus>().AsSingle();

            Container.BindInterfacesAndSelfTo<ApplyDirectionHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ForceDirectionHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollideHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyHandler>().AsSingle();

            Container.BindInterfacesAndSelfTo<DealDamageEffectHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PushEffectHandler>().AsSingle();
        }

        private void ConfigureTurn()
        {
            Container.Bind<TurnPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle();
            Container.Bind<TurnRunner>().FromComponentInHierarchy().AsSingle();;
        }

        private void ConfigureVisual()
        {
            Container.Bind<VisualPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveVisualHandler>().AsSingle();
            Container.Bind<DestroyVisualHandler>().AsSingle();
            Container.Bind<DealDamageVisualHandler>().AsSingle();
            Container.Bind<AttackVisualHandler>().AsSingle();
        }
    }
}
