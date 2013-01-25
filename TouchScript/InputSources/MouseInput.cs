﻿/*
 * Copyright (C) 2012 Interactive Lab
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the 
 * 
 */

using UnityEngine;

namespace TouchScript.InputSources {
    /// <summary>
    /// Input source to grab mouse presses as touch points.
    /// </summary>
    [AddComponentMenu("TouchScript/Input Sources/Mouse Input")]
    public class MouseInput : InputSource {
        #region Private variables

        private int mousePointId = -1;
        private Vector3 mousePointPos = Vector3.zero;

        #endregion

        #region Unity

        protected override void Update() {
            base.Update();

            var upHandled = false;
            if (Input.GetMouseButtonUp(0)) {
                if (mousePointId != -1) {
                    endTouch(mousePointId);
                    mousePointId = -1;
                    upHandled = true;
                }
            }

            if (Input.GetMouseButtonDown(0)) {
                var pos = Input.mousePosition;
                mousePointId = beginTouch(new Vector2(pos.x, pos.y));
            } else if (Input.GetMouseButton(0)) {
                var pos = Input.mousePosition;
                if (mousePointPos != pos) {
                    mousePointPos = pos;
                    moveTouch(mousePointId, new Vector2(pos.x, pos.y));
                }
            }

            if (Input.GetMouseButtonUp(0) && !upHandled) {
                endTouch(mousePointId);
                mousePointId = -1;
            }
        }

        #endregion
    }
}