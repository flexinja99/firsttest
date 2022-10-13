using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISpeed
{
    float speed { get; set; }
    float speedOrigin { get; }
    event Action<float> OnSpeedChanged;
    
    
}
