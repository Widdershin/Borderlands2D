using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Borderlands2D.ECS
{
    sealed public class SystemsRegistry
    {
        private static readonly Dictionary<Type[], List<EntitySystem>> TYPE_TO_SYSTEM_MAPINGS = new Dictionary<Type[], List<EntitySystem>>(); 
        private static readonly List<EntitySystem> SYSTEMS = new List<EntitySystem>(); 

        public static void Register(EntitySystem system, Type[] types)
        {
            SYSTEMS.Add(system);
            if(!TYPE_TO_SYSTEM_MAPINGS.ContainsKey(types))
                TYPE_TO_SYSTEM_MAPINGS[types] = new List<EntitySystem>();
                
            TYPE_TO_SYSTEM_MAPINGS[types].Add(system);
        }

        public static void Update(GameTime time)
        {
            SYSTEMS.ForEach(sys => sys.Update(time));
        }

        public static void AddEntity(Entity e)
        {
            RetrieveSystemsForEntity(e).ForEach(sys => sys.AddEntity(e));
        }

        private static List<EntitySystem> RetrieveSystemsForEntity(Entity e)
        {
            var systems = new List<EntitySystem>();
            var types = e.Components.Select(comp => comp.GetType()).ToArray();
            var acceptableSystem = true;
            foreach (var ts in TYPE_TO_SYSTEM_MAPINGS.Keys)
            {
                if (ts.Any(type => !types.Contains(type)))
                    acceptableSystem = false;
                if(acceptableSystem)
                    systems.AddRange(TYPE_TO_SYSTEM_MAPINGS[ts]);
                acceptableSystem = true;
            }
            if (systems.Count == 0)
                throw new ArgumentException("Entity type is not bound to any Systems!", "e");
            return systems;
        }

        public static void RemoveEntity(Entity e)
        {
            RetrieveSystemsForEntity(e).ForEach(sys => sys.RemoveEntity(e));    
        }
    }
}
