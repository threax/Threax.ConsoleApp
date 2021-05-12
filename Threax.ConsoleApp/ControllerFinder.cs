using System;
using System.Collections.Generic;
using System.Reflection;

namespace Threax.ConsoleApp
{
    public class ControllerFinder<IControllerType, CommandNotFoundType>
    {
        /// <summary>
        /// List all controller types from the given assembly. The name must be an exact match or NameController and the type must extend the specified controller type.
        /// </summary>
        /// <param name="name">The name of the controller.</param>
        public Type GetControllerType(String name)
        {
            return GetControllerType(name, Assembly.GetEntryAssembly());
        }

        /// <summary>
        /// List all controller types from the given assembly. The name must be an exact match or NameController and the type must extend the specified controller type.
        /// </summary>
        /// <param name="name">The name of the controller.</param>
        /// <param name="assembly">The assembly to scan.</param>
        /// <returns>An enumerable over the matching controller types.</returns>
        public Type GetControllerType(String name, Assembly assembly)
        {
            foreach (var type in GetControllerTypes(assembly))
            {
                if (type.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) || type.Name.Equals($"{name}Controller", StringComparison.InvariantCultureIgnoreCase))
                {
                    return type;
                }
            }

            return typeof(CommandNotFoundType);
        }

        /// <summary>
        /// List all controller types from the given assembly.
        /// </summary>
        /// <param name="assembly">The assembly to scan.</param>
        /// <returns>An enumerable over the matching controller types.</returns>
        private IEnumerable<Type> GetControllerTypes(Assembly assembly)
        {
            var iContollerType = typeof(IControllerType);
            foreach (var type in assembly.GetTypes())
            {
                if (iContollerType.IsAssignableFrom(type) && type != iContollerType)
                {
                    yield return type;
                }
            }
        }
    }
}
