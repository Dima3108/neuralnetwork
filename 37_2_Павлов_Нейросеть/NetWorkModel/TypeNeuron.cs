﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_2_Павлов_Нейросеть.NetWorkModel
{
    public enum TypeNeuron
    {
        HiddenNeuron=0,
        OutputNeuron=1
#if DEBUG
            ,InputNeuron=-1
#endif
    };
    public enum MemoryMode
    {
        INIT=0,
        SET=1,
        GET=2
    };
}
