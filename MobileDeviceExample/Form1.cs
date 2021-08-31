﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobileDevice;
using MobileDevice.Event;

namespace MobileDeviceExample
{
    public partial class Form1 : Form
    {
        private iOSDeviceManager manager = new iOSDeviceManager();
        private iOSDevice currentiOSDevice;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StateLabel.Text = "等待设备连接";
            manager.CommonConnectEvent += CommonConnectDevice;
            manager.RecoveryConnectEvent += RecoveryConnectDevice;
            manager.ListenErrorEvent += ListenError;
            manager.StartListen();
        }

        private void ListenError(object sender, ListenErrorEventHandlerEventArgs args)
        {
            if (args.ErrorType == MobileDevice.Enumerates.ListenErrorEventType.StartListen)
            {
                throw new Exception(args.ErrorMessage);
            }
        }

        private void CommonConnectDevice(object sender, DeviceCommonConnectEventArgs args)
        {
            if (args.Message == MobileDevice.Enumerates.ConnectNotificationMessage.Connected)
            {
                currentiOSDevice = args.Device;
                this.Invoke(new Action(() =>
                {
                    StateLabel.Text = "设备已连接";
                }));
            }
            if (args.Message == MobileDevice.Enumerates.ConnectNotificationMessage.Disconnected)
            {
                this.Invoke(new Action(() =>
                {
                    StateLabel.Text = "设备已断开链接";
                }));
            }
        }

        private void RecoveryConnectDevice(object sender, DeviceRecoveryConnectEventArgs args)
        {
            if (args.Message == MobileDevice.Enumerates.ConnectNotificationMessage.Connected)
            {
                this.Invoke(new Action(() =>
                {
                    StateLabel.Text = "恢复模式设备已连接";
                }));
            }
            if (args.Message == MobileDevice.Enumerates.ConnectNotificationMessage.Disconnected)
            {
                this.Invoke(new Action(() =>
                {
                    StateLabel.Text = "设备已断开链接";
                }));
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (currentiOSDevice != null && currentiOSDevice.IsConnected)
            {
                DrviceName.Text = currentiOSDevice.DeviceName;
                DeviceSerial.Text = currentiOSDevice.SerialNumber;
                DeviceVersion.Text = currentiOSDevice.ProductVersion;
                DeviceModelNumber.Text = currentiOSDevice.ModelNumber;
                ActivationState.Text = currentiOSDevice.ActivationState;
                DeviceBuildVersion.Text = currentiOSDevice.BuildVersion;
                DeviceBasebandBootloaderVersion.Text = currentiOSDevice.BasebandBootloaderVersion;
                DeviceBasebandVersion.Text = currentiOSDevice.BasebandVersion;
                DeviceFirmwareVersion.Text = currentiOSDevice.FirmwareVersion;
                DeviceId.Text = currentiOSDevice.UniqueDeviceID;
                DevicePhoneNumber.Text = currentiOSDevice.PhoneNumber;
                DeviceProductType.Text = currentiOSDevice.ProductType;
                DeviceSIMStatus.Text = currentiOSDevice.SIMStatus;
                DeviceWiFiAddress.Text = currentiOSDevice.WiFiAddress;
                DeviceColor.Text = currentiOSDevice.DeviceColor.ToString();
                lbBattery.Text = currentiOSDevice.GetBatteryCurrentCapacity().ToString();
            }
        }

        private void btnGetDiagnosticsInfo_Click(object sender, EventArgs e)
        {
            var result = currentiOSDevice.GetBatteryInfoFormDiagnostics();
        }
    }
}
