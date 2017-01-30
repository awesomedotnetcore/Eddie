﻿// <eddie_source_header>
// This file is part of Eddie/AirVPN software.
// Copyright (C)2014-2016 AirVPN (support@airvpn.org) / https://airvpn.org
//
// Eddie is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Eddie is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Eddie. If not, see <http://www.gnu.org/licenses/>.
// </eddie_source_header>

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Eddie.Core
{
	public class WebClientEx : System.Net.WebClient
	{
        public string CustomHost = "";

		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest w = base.GetWebRequest(address);
			HttpWebRequest wHttp = w as HttpWebRequest;
			if (wHttp != null)
			{
				wHttp.KeepAlive = false;				
			}
			wHttp.ServicePoint.Expect100Continue = false; // 2.10.1
			wHttp.AllowAutoRedirect = false; // 2.9

#if !EDDIENET20
            // Look the comment in TrustCertificatePolicy.cs
            if (CustomHost != "")
                wHttp.Host = CustomHost;
#endif
            w.Timeout = 10000;		
			
			return w;
		}
	}
}
