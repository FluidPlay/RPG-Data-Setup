using System.Linq;
using Syrinj.Attributes;
using Syrinj.Injection;
using UnityEngine;

namespace Syrinj.Resolvers
{
    public class FindResourceOfTypeResolver : IResolver
    {
        public object Resolve(Injectable injectable)
        {
            var attribute = (FindResourceOfTypeAttribute)injectable.Attribute;
            if (attribute.ComponentType == null)
            {
                return Resources.LoadAll("", injectable.Type).FirstOrDefault();
            }
            //else
                return Resources.LoadAll("", attribute.ComponentType).FirstOrDefault();
        }        
    }
}