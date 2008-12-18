
#region Imports
using System;
using System.Collections.Generic;
using System.Drawing;
using Mono.Cecil;
#endregion

namespace Cecil.Decompiler.Gui.Controls
{
    internal class IconHelper
    {
        #region Fields
        private readonly static Dictionary<Type, System.Delegate> handlers;
        #endregion

        #region Methods 
        static IconHelper()
        {
            // Our lookup
            handlers = new Dictionary<Type, System.Delegate>();
            handlers.Add(typeof(AssemblyDefinition), new GetImageIndexHandler<AssemblyDefinition>(GetAssemblyImageIndex));
            handlers.Add(typeof(ModuleDefinition), new GetImageIndexHandler<ModuleDefinition>(GetModuleImageIndex));
            handlers.Add(typeof(NamespaceWrapper), new GetImageIndexHandler<NamespaceWrapper>(GetNamespaceImageIndex));
            handlers.Add(typeof(TypeDefinition), new GetImageIndexHandler<TypeDefinition>(GetTypeImageIndex));
            handlers.Add(typeof(MethodDefinition), new GetImageIndexHandler<MethodDefinition>(GetMethodImageIndex));
            handlers.Add(typeof(PropertyDefinition), new GetImageIndexHandler<PropertyDefinition>(GetPropertyImageIndex));
            handlers.Add(typeof(FieldDefinition), new GetImageIndexHandler<FieldDefinition>(GetFieldImageIndex));
            handlers.Add(typeof(EventDefinition), new GetImageIndexHandler<EventDefinition>(GetEventImageIndex));
        }

        private delegate Icons GetImageIndexHandler<T>(T obj);
        public static Icons GetImageIndex(object obj)
        {
            // We don't use keys directly to preserve type inheritance
            foreach (Type key in handlers.Keys)
            {
                if (key.IsAssignableFrom(obj.GetType()))
                {
                    return (Icons)handlers[key].DynamicInvoke(obj);
                }
            }

            return Icons.Empty;
        }

        public static Image GetImageStrip()
        {
            return Properties.Resources.icons;
        }

        public static Icons GetTypeImageIndex(TypeDefinition typedef)
        {
            Icons offset = Icons.Empty;

            if (typedef.IsEnum)
            {
                offset = Icons.PublicEnum;
            }
            else if (typedef.IsInterface)
            {
                offset = Icons.PublicInterface;
            }
            else offset = typedef.IsValueType ? Icons.PublicStructure : Icons.PublicClass;

            if ((typedef.Attributes & TypeAttributes.VisibilityMask) < TypeAttributes.Public)
            {
                offset = (Icons)((int)offset + Icons.FriendClass - Icons.PublicClass);
            }
            else
            {
                offset = offset + ScopeOffset(Convert.ToInt32(typedef.Attributes), (int)TypeAttributes.VisibilityMask, (int)TypeAttributes.NestedPublic, (int)TypeAttributes.NestedAssembly, (int)TypeAttributes.NestedFamORAssem, (int)TypeAttributes.NestedFamily, (int)TypeAttributes.NestedPrivate);
            }
            return offset;
        }

        public static Icons GetPropertyImageIndex(PropertyDefinition propdef)
        {
            Icons offset = Icons.Empty;

            if (propdef.GetMethod == null)
            {
                offset = propdef.SetMethod.IsStatic ? Icons.PublicSharedWriteOnlyProperty : Icons.PublicWriteOnlyProperty;
            }
            else if (propdef.SetMethod == null)
            {
                offset = propdef.GetMethod.IsStatic ? Icons.PublicSharedReadOnlyProperty : Icons.PublicReadOnlyProperty;
            }
            else
            {
                offset = propdef.GetMethod.IsStatic ? Icons.PublicSharedProperty : Icons.PublicProperty;
            }
            return offset;
        }

        public static Icons GetMethodImageIndex(MethodDefinition metdef)
        {
            Icons offset = Icons.Empty;

            if (metdef.IsConstructor)
            {
                offset = metdef.IsStatic ? Icons.PublicSharedConstructor : Icons.PublicConstructor;
            }
            else
            {
                if (metdef.IsVirtual)
                {
                    offset = metdef.IsStatic ? Icons.PublicSharedOverrideMethod : Icons.PublicOverrideMethod;
                }
                else
                {
                    offset = metdef.IsStatic ? Icons.PublicSharedMethod : Icons.PublicMethod;
                }
            }
            offset = offset + ScopeOffset((int)metdef.Attributes, (int)MethodAttributes.MemberAccessMask, (int)MethodAttributes.Public, (int)MethodAttributes.Assem, (int)MethodAttributes.FamORAssem, (int)MethodAttributes.Family, (int)MethodAttributes.Private);
            return offset;
        }

        public static Icons GetFieldImageIndex(FieldDefinition field)
        {
            Icons offset = Icons.Empty;

            if (field.IsLiteral && field.IsStatic)
            {
                offset = Icons.PublicEnumValue;
            }
            else
            {
                offset = field.IsStatic ? Icons.PublicSharedField : Icons.PublicField;
            }
            offset = offset + ScopeOffset((int)field.Attributes, (int)FieldAttributes.FieldAccessMask, (int)FieldAttributes.Public, (int)FieldAttributes.Assembly, (int)FieldAttributes.FamORAssem, (int)FieldAttributes.Family, (int)FieldAttributes.Private);
            return offset;
        }

        public static Icons GetModuleImageIndex(ModuleDefinition module)
        {
            return Icons.Module;
        }

        public static Icons GetEventImageIndex(EventDefinition @event)
        {
            return @event.AddMethod.IsStatic ? Icons.PublicSharedEvent : Icons.PublicEvent; ;
        }

        public static Icons GetAssemblyImageIndex(AssemblyDefinition assembly)
        {
            return Icons.Assembly;
        }

        public static Icons GetNamespaceImageIndex(NamespaceWrapper @namespace)
        {
            return Icons.PublicNamespace;
        }

        private static int ScopeOffset(int attributes, int mask, int publicValue, int friendValue, int protectedFriendValue, int protectedValue, int privateValue)
        {
            int[] scopes = new int[] { publicValue, friendValue, protectedFriendValue, protectedValue, privateValue };
            attributes = attributes & mask;

            for (int i = 0; i <= scopes.Length - 1; i++)
            {
                if (attributes == scopes[i])
                    return i;
            }

            return 0;
        }
        #endregion
    }
}
