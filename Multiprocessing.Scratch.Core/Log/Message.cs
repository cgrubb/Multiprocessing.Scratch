namespace Multiprocessing.Scratch.Core.Log
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Message
  {
   /// <summary>
   /// Gets or sets log message
   /// </summary>
    public string LogMessage { get; set; }

    /// <summary>
    /// Gets or sets the created time
    /// </summary>
    public DateTime? Created { get; set; }
  }
}
