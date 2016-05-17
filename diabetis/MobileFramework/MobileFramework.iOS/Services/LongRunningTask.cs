using MobileFramework.Helpers.Messages;
using MobileFramework.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace MobileFramework.iOS.Services
{
    class LongRunningTask
    {
        nint _taskId;
        CancellationTokenSource _cts;

        public async Task StartLongRunningTask(FunctionPassingToNativeBackground obj)
        {
            
            _cts = new CancellationTokenSource();

            _taskId = UIApplication.SharedApplication.BeginBackgroundTask("LongRunningTask", OnExpiration);

            try
            {
                
                //INVOKE THE SHARED CODE
                var tmp = obj.ClassObject;
                Type type = tmp.GetType();
                MethodInfo method = type.GetMethod(obj.FunctionName);
                await (Task) method.Invoke(tmp, obj.Params.ToArray());
              

            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                if (_cts.IsCancellationRequested)
                {
                    var message = new CancelledMessage();
                    Device.BeginInvokeOnMainThread(
                        () => MessagingCenter.Send(message, "CancelledMessage")
                    );
                }
            }

            UIApplication.SharedApplication.EndBackgroundTask(_taskId);
        }

       
        public void Stop()
        {
            _cts.Cancel();
        }

        void OnExpiration()
        {
            _cts.Cancel();
        }
    }
}
