using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;

namespace Sheetrock
{
	public static class JwtMasterKeyManager
	{
		public static byte[] GetEncodedMasterKey()
		{
			var sha256 = new SHA256Managed();
			var secretBytes = System.Text.Encoding.UTF8.GetBytes(WebConfigurationManager.AppSettings["MasterKey"] + "JWTSig");
			byte[] signingKey = sha256.ComputeHash(secretBytes);

			return signingKey;
		}
	}
}