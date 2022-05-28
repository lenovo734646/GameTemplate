using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class AssemblyCommon_IShowDownloadProgress_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(AssemblyCommon.IShowDownloadProgress);
            args = new Type[]{typeof(System.String)};
            method = type.GetMethod("Desc", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Desc_0);
            args = new Type[]{typeof(UnityEngine.GameObject)};
            method = type.GetMethod("SetUIRoot", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SetUIRoot_1);

            field = type.GetField("isDestoryed", flag);
            app.RegisterCLRFieldGetter(field, get_isDestoryed_0);
            app.RegisterCLRFieldSetter(field, set_isDestoryed_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_isDestoryed_0, AssignFromStack_isDestoryed_0);


        }


        static StackObject* Desc_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.String @desc = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            AssemblyCommon.IShowDownloadProgress instance_of_this_method = (AssemblyCommon.IShowDownloadProgress)typeof(AssemblyCommon.IShowDownloadProgress).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Desc(@desc);

            return __ret;
        }

        static StackObject* SetUIRoot_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            UnityEngine.GameObject @obj = (UnityEngine.GameObject)typeof(UnityEngine.GameObject).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            AssemblyCommon.IShowDownloadProgress instance_of_this_method = (AssemblyCommon.IShowDownloadProgress)typeof(AssemblyCommon.IShowDownloadProgress).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack), (CLR.Utils.Extensions.TypeFlags)0);
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SetUIRoot(@obj);

            return __ret;
        }


        static object get_isDestoryed_0(ref object o)
        {
            return ((AssemblyCommon.IShowDownloadProgress)o).isDestoryed;
        }

        static StackObject* CopyToStack_isDestoryed_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((AssemblyCommon.IShowDownloadProgress)o).isDestoryed;
            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static void set_isDestoryed_0(ref object o, object v)
        {
            ((AssemblyCommon.IShowDownloadProgress)o).isDestoryed = (System.Boolean)v;
        }

        static StackObject* AssignFromStack_isDestoryed_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Boolean @isDestoryed = ptr_of_this_method->Value == 1;
            ((AssemblyCommon.IShowDownloadProgress)o).isDestoryed = @isDestoryed;
            return ptr_of_this_method;
        }



    }
}
