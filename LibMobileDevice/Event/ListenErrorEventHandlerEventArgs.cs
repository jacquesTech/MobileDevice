﻿using LibMobileDevice.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMobileDevice.Event
{
    public class ListenErrorEventHandlerEventArgs : EventArgs
    {
        private string errorMessage;
        private ListenErrorEventType errorType;

        /// <summary>
        /// 错误消息
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
        }

        /// <summary>
        /// 错误类型
        /// </summary>
        /// <value>The type of the error.</value>
        public ListenErrorEventType ErrorType
        {
            get
            {
                return errorType;
            }
        }

        public ListenErrorEventHandlerEventArgs(string errorMessage, ListenErrorEventType errorType)
        {
            this.errorMessage = errorMessage;
            this.errorType = errorType;
        }
    }
}
