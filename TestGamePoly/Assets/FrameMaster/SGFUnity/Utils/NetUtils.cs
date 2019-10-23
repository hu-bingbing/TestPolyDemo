/*
 * Copyright (C) 2018 Slicol Tang. All rights reserved.
 * 
 * Licensed under the MIT License (the "License"); 
 * you may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, 
 * software distributed under the License is distributed on an "AS IS" BASIS, 
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
 * either express or implied. 
 * See the License for the specific language governing permissions and limitations under the License.
*/


using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine;

namespace SGF.Unity.Utils
{
    public class NetUtils
    {
        public static bool IsWifi()
        {
            return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
        }


        public static bool IsAvailable()
        {
            return Application.internetReachability != NetworkReachability.NotReachable;
        }


        public static string SelfIP
        {
            get { return m_selfIpAddress; }
        }

        public enum AddressFam
        {
            IPv4, IPv6
        }

        private static string m_selfIpAddress = "";
        public static void CheckSelfIPAddress(AddressFam Addfam = AddressFam.IPv4)
        {
            //m_selfIpAddress = UnityEngine.Network.player.ipAddress;

            if (Addfam == AddressFam.IPv6 && !Socket.OSSupportsIPv6)
            {
                m_selfIpAddress = null;
            }

            string output = "";

            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
                NetworkInterfaceType _type1 = NetworkInterfaceType.Wireless80211;
                NetworkInterfaceType _type2 = NetworkInterfaceType.Ethernet;

                if ((item.NetworkInterfaceType == _type1 || item.NetworkInterfaceType == _type2) && item.OperationalStatus == OperationalStatus.Up)
#endif
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        //IPv4
                        if (Addfam == AddressFam.IPv4)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                output = ip.Address.ToString();
                            }
                        }

                        //IPv6
                        else if (Addfam == AddressFam.IPv6)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                            {
                                output = ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            m_selfIpAddress = output;
        }

    }
}
