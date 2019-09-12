using UnityEngine;
using Zenject;
using Cinemachine;
using Assets.Infrastructure.Scripts.CQRS;
using Assets.Infrastructure.MessageBusImplementations.UniRx;
using AlirezaTarahomi.FightingGame.CameraSystem;
using AlirezaTarahomi.FightingGame.InputSystem;
using AlirezaTarahomi.FightingGame.Player;
using Infrastructure.Factory;
using Infrastructure.ObjectPool;

public class GeneralInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Canvas>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MainCameraController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CinemachineTargetGroup>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerSideDetector>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PoolSystem>().FromComponentInHierarchy().AsSingle();

        Container.Bind<TargetGroupController>().AsSingle().NonLazy();
        Container.Bind<InputManager>().To<UnityInputManager>().AsSingle().NonLazy();
        Container.Bind<IMessageBus>().To<UniRxMessageBus>().AsSingle();
        Container.Bind<StateMachine>().AsSingle().NonLazy();
        Container.Bind<IResourceFactory>().To<ZenjectResourceFactory>().AsSingle().NonLazy();
    }
}