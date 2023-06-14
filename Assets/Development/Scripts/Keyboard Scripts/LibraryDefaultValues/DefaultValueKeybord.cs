using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Development.Scripts.MainCode.LibraryDefaultValues
{
    public class DefaultValueKeybord
    {

        public Dictionary<string, string> DefaultKeybordValue()
        {
            Dictionary<string, string> keyborDictionaryDefault;
            keyborDictionaryDefault = new Dictionary<string, string>
            {
                { "cursorMod", "p" }
            };

            return keyborDictionaryDefault;
        }
    }
}
