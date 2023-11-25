using System.Diagnostics.Tracing;
using System.Xml.Serialization;
using Microsoft.Extensions.Primitives;

namespace onemilliontry
{
    

    

    public interface ITimer
    {
        string Time {get;}
    }
    public class Timer : ITimer{
        public Timer(){
            Time = DateTime.Now.ToLongTimeString();
        }
        public string Time{get;}
    }
    public class TimeService
    {
        private ITimer timer;
        public TimeService(ITimer timer)
        {
            this.timer = timer;
        }
        public string GetTime()=> timer.Time;
    }
    //

    // interface IUser{
        
    // }
    //
    interface IGenerator
    {
        int GenerateValue();
    }
    interface IReader
    {
        int ReadValue();
    }
    class ValueStorage : IGenerator, IReader
    {
        int value;
        public int GenerateValue()
        {
            value = new Random().Next();
            return value;
        }
        public int ReadValue()=> value;
    }

    public interface IConfiguration
    {
        string this[string key]{get;set;}
        IEnumerable<IConfigurationSection>GetChildren();
        IChangeToken GetReloadToken();
        IConfigurationSection GetcSection(string key);
    }
    public interface IConfigurationRoot: IConfiguration
    {
        IEnumerable<IConfigurationProvider>Providers{get;}
        CodeIdentifier Reload();
    }
    
}

        