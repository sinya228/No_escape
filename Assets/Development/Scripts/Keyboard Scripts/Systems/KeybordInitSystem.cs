using Assets.Development.Scripts.MainCode.LibraryDefaultValues;
using Leopotam.Ecs;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

sealed class KeybordInitSystem : IEcsInitSystem
{
    private readonly EcsFilter<KeyboardComponent> keybordFilter = null;
    public void Init()
    {
        foreach (var i in keybordFilter)
        {
            DefaultValueKeybord defaultValueKeybord = new DefaultValueKeybord();
            ref var keyComponent = ref keybordFilter.Get1(i);
            Dictionary<string, string> keyborDictionaryDefault = defaultValueKeybord.DefaultKeybordValue();
            if (keyComponent.keyborDictionary == null)
                keyComponent.keyborDictionary = keyborDictionaryDefault;
            else
            {
                foreach (var anotherElement in keyborDictionaryDefault)
                {
                    if (!keyComponent.keyborDictionary.ContainsKey(anotherElement.Key))
                        keyComponent.keyborDictionary.Add(anotherElement.Key, anotherElement.Value);
                }
            }
        }
    }
}

