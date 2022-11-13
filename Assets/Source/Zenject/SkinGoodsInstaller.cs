using Source;
using Source.Model.Storage;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = nameof(SkinGoodsInstaller))]
public class SkinGoodsInstaller : ScriptableObjectInstaller
{
    public override void InstallBindings() => 
        Container.BindInstance((IStorage<Mesh>)new MeshStorage(nameof(CharacterSkin)));
}
