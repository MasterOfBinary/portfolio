﻿//
// Copyright (c) Vaughn Friesen
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barbell_Domination
{
    class Weight
    {
        public Weight(float Pounds, int NumberOfWeights)
        {
            this.Pounds = Pounds;
            this.NumberOfWeights = NumberOfWeights;
        }

        public float Pounds;
        public int NumberOfWeights;
    }
}