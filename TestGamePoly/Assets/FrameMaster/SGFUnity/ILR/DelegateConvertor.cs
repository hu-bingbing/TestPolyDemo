﻿/*
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

using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace SGF.Unity.ILR
{
    public class DelegateConvertor
    {
        public static void Init(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterMethodDelegate<int>();
            appdomain.DelegateManager.RegisterMethodDelegate<float>();
            appdomain.DelegateManager.RegisterMethodDelegate<object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object>();




        }
    }
}