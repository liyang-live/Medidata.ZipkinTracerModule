﻿using System;
using System.Collections.Generic;
using Microsoft.Owin;

namespace Medidata.ZipkinTracer.Core
{
    public interface IZipkinConfig
    {
        bool Enable { get; set; }
        Uri ZipkinBaseUri { get; set; }
        Uri Domain { get; set; }
        uint SpanProcessorBatchSize { get; set; }
        IList<string> ExcludedPathList { get; set; }
        double SampleRate { get; set; }
        IList<string> NotToBeDisplayedDomainList { get; set; }
        bool ShouldBeSampled(IOwinContext context, string sampled);
        void Validate();
    }
}