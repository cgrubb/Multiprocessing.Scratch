namespace MultiProcessing.Scratch.Logger
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;
  using NetMQ;

  public class Program
  {
    /// <summary>
    /// Logger main method
    /// </summary>
    /// <param name="args">Command line arguments</param>
    public static void Main(string[] args)
    {
      var address = "tcp://localhost:9000";
      //// Parse arguments
      if (args.Length > 0)
      {
        address = args.Last();
      }
      
      using (var context = NetMQContext.Create())
      {
        using (var listener = context.CreateSubscriberSocket())
        {
          //// Phone home with our address
          using (var publisher = context.CreatePushSocket())
          {
            publisher.Connect(address);
            var ourPort = listener.BindRandomPort("tcp://*");
            var message = string.Format("logger:{0}", listener.Options.LastEndpoint);
            publisher.SendMoreFrame("logger").SendFrame(message);
          }
          while (true)
          {
            var msgs = new List<string>();
            var timeout = new TimeSpan(0, 0, 0, 0, 100);
            if (listener.TryReceiveMultipartStrings(timeout, ref msgs))
            {

            }              
          }
        }
        
      } 
    }
  }
}
