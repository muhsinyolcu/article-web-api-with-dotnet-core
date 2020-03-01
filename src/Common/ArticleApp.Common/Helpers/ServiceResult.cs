﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArticleApp.Common.Helpers
{
    [Serializable]
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            ValidationMessages = new List<string>();
        }
        public bool HasError { get; set; }
        [XmlIgnore]
        public Exception Exception { get; set; }
        public int ErrorCode { get; set; }
        public string InfoMessage { get; set; }
        public List<string> ValidationMessages { get; set; }
        public int AffectRow { get; set; }
        public T Result { get; set; }
        public int TotalItemCount { get; set; }
    }
}
