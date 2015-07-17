// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System;
using System.Collections.Generic;

namespace HammercLib.Notification
{
    /// <summary>
    /// 消息通知中心.
    /// </summary>
    public class NotificationCenter
    {
        private static NotificationCenter _instance;

        /// <summary>
        /// 获取单例.
        /// </summary>
        /// <returns>单例.</returns>
        public static NotificationCenter GetInstance()
        {
            if(_instance == null)
            {
                _instance = new NotificationCenter();
            }
            return _instance;
        }

        private Dictionary<string, Notifier> _eventMap;

        /// <summary>
        /// 构造函数.
        /// </summary>
        private NotificationCenter()
        {
            _eventMap = new Dictionary<string, Notifier>();
        }

        /// <summary>
        /// 添加一个消息监听.
        /// </summary>
        /// <param name="name">消息名称.</param>
        /// <param name="handler">监听方法.</param>
        public void AddNotificationHandler(string name, EventHandler handler)
        {
            if(!_eventMap.ContainsKey(name))
            {
                _eventMap[name] = new Notifier();
            }
            _eventMap[name].AddEventHandler(handler);
        }

        /// <summary>
        /// 发送一个消息.
        /// </summary>
        /// <param name="name">消息名称.</param>
        public void SendNotification(string name)
        {
            this.SendNotification(name, null, EventArgs.Empty);
        }

        /// <summary>
        /// 发送一个消息.
        /// </summary>
        /// <param name="name">消息名称.</param>
        /// <param name="sender">消息发送者.</param>
        public void SendNotification(string name, object sender)
        {
            this.SendNotification(name, sender, EventArgs.Empty);
        }

        /// <summary>
        /// 发送一个消息.
        /// </summary>
        /// <param name="name">消息名称.</param>
        /// <param name="sender">消息发送者.</param>
        /// <param name="eventArgs">消息参数.</param>
        public void SendNotification(string name, object sender, EventArgs eventArgs)
        {
            if(_eventMap.ContainsKey(name))
            {
                _eventMap[name].Execute(sender, eventArgs);
            }
        }

        /// <summary>
        /// 移除一个消息监听.
        /// </summary>
        /// <param name="name">消息名称.</param>
        /// <param name="handler">监听方法.</param>
        public void RemoveNotificationHandler(string name, EventHandler handler)
        {
            if(_eventMap.ContainsKey(name))
            {
                _eventMap[name].RemoveEventHandler(handler);
            }
        }

        /// <summary>
        /// 如果一个特定名称的消息已经不会再使用同时没有任何监听, 可以调用该方法清除其占用的内存.
        /// </summary>
        /// <param name="name">消息名称.</param>
        public void ClearNotificationByName(string name)
        {
            if(_eventMap.ContainsKey(name))
            {
                _eventMap.Remove(name);
            }
        }
    }

    /// <summary>
    /// 消息发送执行类.
    /// </summary>
    public class Notifier
    {
        private event EventHandler _handler;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public Notifier()
        {
        }

        /// <summary>
        /// 添加一个监听.
        /// </summary>
        /// <param name="handler">监听方法.</param>
        public void AddEventHandler(EventHandler handler)
        {
            _handler += handler;
        }

        /// <summary>
        /// 执行监听.
        /// </summary>
        /// <param name="sender">消息发送者.</param>
        /// <param name="eventArgs">消息参数.</param>
        public void Execute(object sender, EventArgs eventArgs)
        {
            if(_handler != null)
            {
                _handler(sender, eventArgs);
            }
        }

        /// <summary>
        /// 移除一个监听.
        /// </summary>
        /// <param name="handler">监听方法.</param>
        public void RemoveEventHandler(EventHandler handler)
        {
            _handler -= handler;
        }
    }
}
