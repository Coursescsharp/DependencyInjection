using Serilog;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Module2.Aop.Aspects;

public class ErrorHandlingAspect : IInterceptionBehavior
{
    public bool WillExecute => true;

    public IEnumerable<Type> GetRequiredInterfaces()
    {
        throw new NotImplementedException();
    }

    public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    {
        try
        {
            // Execute the method
            var result = getNext()(input, getNext);

            // If the method throws an exception, log the error
            if (result.Exception != null)
            {
                Log.Error($"Error occurred in method {input.MethodBase.Name}: {result.Exception}");
            }

            return result;
        }
        catch (Exception ex)
        {
            Log.Error($"Error occurred in method {input.MethodBase.Name}: {ex}");
            throw; // Rethrow the exception after logging
        }
    }
}
