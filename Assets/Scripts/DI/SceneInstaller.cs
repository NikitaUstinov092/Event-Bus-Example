using Entity;
using Entity.Enemy;
using GamePlay;
using GamePlay.Input;
using Level;
using Tasks.Turn;
using Tasks.Turn.Common;
using Tasks.Visual;
using Turn;
using TurnSystem;
using TurnSystem.Events;
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
            ConfigureCommon();
            ConfigureLevel();
            ConfigurePlayer();
            ConfigureEnemies();
            ConfigureHandlers();
            ConfigureTurn();
            ConfigureTasks();
            ConfigureVisual();
        }
        private void ConfigureCommon()
        {
            Container.Bind<EntityInstaller>().FromComponentInHierarchy().AsSingle();
        }

        private void ConfigureTasks()
        {
            Container.Bind<PlayerTurnTask>().AsSingle();
            Container.Bind<VisualTurnTask>().AsSingle();
            Container.Bind<ZombieTaskInstaller>().AsSingle();
            Container.Bind<ZombieSpawnerTask>().AsSingle();
        }

        private void ConfigureLevel()
        {
            Container.Bind<TileMap>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EntityMap>().AsSingle();
            Container.Bind<LevelMap>().AsSingle();
        }

        private void ConfigurePlayer()
        {
            Container.BindInterfacesTo<KeyboardInput>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerService>().FromComponentInHierarchy().AsSingle();
        }
        
        private void ConfigureEnemies()
        {
            Container.Bind<EnemyStorage>().AsSingle();
            Container.Bind<ZombieSpawner>().FromComponentInHierarchy().AsSingle();
        }
        
        private void ConfigureHandlers()
        {
            Container.Bind<EventBus>().AsSingle();

            Container.BindInterfacesTo<ApplyDirectionHandler>().AsSingle();
            Container.BindInterfacesTo<ForceDirectionHandler>().AsSingle();
            Container.BindInterfacesTo<MeleeCombatHandler>().AsSingle();
            Container.BindInterfacesTo<CollideHandler>().AsSingle();
            Container.BindInterfacesTo<DealDamageHandler>().AsSingle();
            Container.BindInterfacesTo<DeathHandler>().AsSingle();
            Container.BindInterfacesTo<ExplodeHandler>().AsSingle();
            Container.BindInterfacesTo<MoveHandler>().AsSingle();
            Container.BindInterfacesTo<ShootHandler>().AsSingle();
            Container.BindInterfacesTo<DealDamageEffectHandler>().AsSingle();
            Container.BindInterfacesTo<BulletAttackHandler>().AsSingle();
            Container.BindInterfacesTo<PushEffectHandler>().AsSingle();
        }

        private void ConfigureTurn()
        {
            Container.Bind<TurnPipeline>().AsSingle();
            Container.Bind<PipelineTaskManager>().AsSingle();
            Container.BindInterfacesTo<PipelineTaskRunner>().AsSingle();
        }

        private void ConfigureVisual()
        {
            Container.Bind<VisualPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MeleeCombatVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollideVisualHandler>().AsSingle();
            Container.BindInterfacesTo<ExplodeVisualHandler>().AsSingle();
        }
    }
}
