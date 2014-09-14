//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using Game.MVC;
//
//
//
////  UIEvent.cs
////  Author: Lu Zexi
////  2014-07-06
//
//
//namespace Game.MVC
//{
//    /// <summary>
//    /// ui event.
//    /// </summary>
//    public class UIEvent : MonoBehaviour
//    {
//        public delegate void OnCallBack(INPUT_INFO info, params object[] arg);
//        public OnCallBack m_cEvent;
//        public object[] m_vecArg;
//
//        /// <summary>
//        /// OnHover
//        /// </summary>
//        /// <param name="isOver"></param>
//        protected void OnHover(bool isOver)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.HOVER;
//            info.m_bDone = isOver;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// OnPress
//        /// </summary>
//        /// <param name="isDown"></param>
//        protected void OnPress(bool isDown)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.PRESS;
//            info.m_bDone = isDown;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// on select
//        /// </summary>
//        /// <param name="isSelected"></param>
//        protected void OnSelect(bool isSelected)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.SELECT;
//            info.m_bDone = isSelected;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// click
//        /// </summary>
//        protected void OnClick()
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.CLICK;
//            CallEvent(info);
//        }
//
//
//        /// <summary>
//        /// double click
//        /// </summary>
//        protected void OnDoubleClick()
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.DOUBLE_CLICK;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// on drag
//        /// </summary>
//        /// <param name="delta"></param>
//        protected void OnDrag(Vector2 delta)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.DRAG;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// on drop
//        /// </summary>
//        /// <param name="target"></param>
//        protected void OnDrop(GameObject target)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.DROP;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// input
//        /// </summary>
//        /// <param name="text"></param>
//        protected void OnInput(string text)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.INPUT;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// On tool tip
//        /// </summary>
//        /// <param name="show"></param>
//        protected void OnTooltip(bool show)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.TOOLTIP;
//            info.m_bDone = show;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// on scroll
//        /// </summary>
//        /// <param name="delta"></param>
//        protected void OnScroll(float delta)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.SCROLL;
//            info.m_fDelta = delta;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// on key
//        /// </summary>
//        /// <param name="key"></param>
//        protected void OnKey(KeyCode key)
//        {
//            INPUT_INFO info = new INPUT_INFO();
//            info.m_eType = INPUT_TYPE.KEY;
//            info.m_eKey = key;
//            CallEvent(info);
//        }
//
//        /// <summary>
//        /// call the event
//        /// </summary>
//        /// <param name="info"></param>
//        protected void CallEvent(INPUT_INFO info)
//        {
//            if (this.m_cEvent != null)
//            {
//                this.m_cEvent(info, this.m_vecArg);
//            }
//        }
//    }
//}
