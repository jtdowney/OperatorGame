using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.DirectX.DirectInput;

namespace OperatorGame
{
    public class Gamepad
    {
        private readonly Device device;
        private JoystickState state;
        private byte[] buttons;

        public Gamepad(Guid deviceID, IntPtr handle)
        {
            this.device = new Device(deviceID);
            this.device.SetCooperativeLevel(handle, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
            this.device.SetDataFormat(DeviceDataFormat.Joystick);
            this.device.Acquire();
        }

        public bool IsButtonPressed { get; private set; }
        public bool HasButtonStateChanged { get; private set; }

        public static IDictionary<Guid, string> Enumerate()
        {
            return Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly)
                          .Cast<DeviceInstance>()
                          .ToDictionary(k => k.InstanceGuid, v => v.InstanceName);
        }

        public void Poll()
        {
            this.device.Poll();
            this.state = this.device.CurrentJoystickState;
            byte[] newButtons = this.state.GetButtons();

            if (this.buttons == null)
            {
                this.buttons = newButtons;
                this.HasButtonStateChanged = true;
                return;
            }

            this.IsButtonPressed = false;
            this.HasButtonStateChanged = false;
            for (int i = 0; i < newButtons.Length; i++)
            {
                if (newButtons[i] != this.buttons[i])
                {
                    this.HasButtonStateChanged = true;
                }

                if (newButtons[i] > 0)
                {
                    this.IsButtonPressed = true;
                }
            }

            if (this.HasButtonStateChanged)
            {
                this.buttons = newButtons;
            }
        }

        public bool GetNumberedButton(int button)
        {
            if (this.buttons.Length > button)
            {
                return this.buttons[button] > 0;
            }

            return false;
        }
    }
}