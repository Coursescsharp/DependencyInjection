using Serilog;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Module2.Aop.Aspects;

public class LoggingAspect : IInterceptionBehavior
{
    public bool WillExecute => true;

    public IEnumerable<Type> GetRequiredInterfaces()
    {
        throw new NotImplementedException();
    }

    public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
    {
        // Pre-processing logic (before the actual method call)
        Log.Information($"Calling method: {input.MethodBase.Name} - BEGIN");

        // Execute the method
        var result = getNext()(input, getNext);

        // Post-processing logic (afther the method call)
        Log.Information($"Calling method: {input.MethodBase.Name} - END");

        return result;
    }
}
