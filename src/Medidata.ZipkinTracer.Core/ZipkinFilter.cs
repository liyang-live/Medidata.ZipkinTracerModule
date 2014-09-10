﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medidata.ZipkinTracer.Core
{
    public class ZipkinFilter
    {
        private static Random random = new Random();
 
        private readonly List<string> dontSampleList;
        private readonly float sampleRate;
      
        public ZipkinFilter(List<string> dontSampleList, float sampleRate)
        {
            this.dontSampleList = dontSampleList;
            this.sampleRate = sampleRate;
        }

        internal bool IsInDontSampleList(string path)
        {
            if (path != null)
            {
                if (dontSampleList.Any(uri => path.StartsWith(uri, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool ShouldBeSampled(string path)
        {
            if ( ! IsInDontSampleList(path))
            {
                var randomNumber = random.Next(10);
                
                if ( (float) (randomNumber * 0.1) <= sampleRate )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
