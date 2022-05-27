using System;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

namespace ILRuntimeCrossbindAdapter
{   
    public class IShowDownloadProgressAdapter : CrossBindingAdaptor
    {
        public override Type BaseCLRType
        {
            get
            {
                return typeof(AssemblyCommon.IShowDownloadProgress);
            }
        }

        public override Type AdaptorType
        {
            get
            {
                return typeof(Adapter);
            }
        }

        public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adapter(appdomain, instance);
        }

        public class Adapter : AssemblyCommon.IShowDownloadProgress, CrossBindingAdaptorType
        {
            CrossBindingMethodInfo<System.Int64, System.Int64> mProgress_0 = new CrossBindingMethodInfo<System.Int64, System.Int64>("Progress");
            CrossBindingMethodInfo<System.String> mDesc_1 = new CrossBindingMethodInfo<System.String>("Desc");
            CrossBindingMethodInfo<AssemblyCommon.DownloadState> mSetState_2 = new CrossBindingMethodInfo<AssemblyCommon.DownloadState>("SetState");

            bool isInvokingToString;
            ILTypeInstance instance;
            ILRuntime.Runtime.Enviorment.AppDomain appdomain;

            public Adapter()
            {

            }

            public Adapter(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance { get { return instance; } }

            public override void Progress(System.Int64 downed, System.Int64 totalLength)
            {
                mProgress_0.Invoke(this.instance, downed, totalLength);
            }

            public override void Desc(System.String desc)
            {
                mDesc_1.Invoke(this.instance, desc);
            }

            public override void SetState(AssemblyCommon.DownloadState st)
            {
                mSetState_2.Invoke(this.instance, st);
            }

            public override string ToString()
            {
                IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
                m = instance.Type.GetVirtualMethod(m);
                if (m == null || m is ILMethod)
                {
                    if (!isInvokingToString)
                    {
                        isInvokingToString = true;
                        string res = instance.ToString();
                        isInvokingToString = false;
                        return res;
                    }
                    else
                        return instance.Type.FullName;
                }
                else
                    return instance.Type.FullName;
            }
        }
    }
}

