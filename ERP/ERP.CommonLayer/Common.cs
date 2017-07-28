using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.CommonLayer
{
	public static class Common
	{
		/// <summary>
		/// Get all user path
		/// </summary>
		/// <returns></returns>
		public static string GetAllUserPath()
		{
			string allUserPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			allUserPath = Path.Combine(allUserPath, "ERP");
			allUserPath = Path.Combine(allUserPath, "default");
			return allUserPath;
		}

		/// <summary>
		/// Get all user AppPath Alone
		/// </summary>
		/// <returns></returns>
		public static string GetAllUserAppPath()
		{
			string allUserPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			return allUserPath;
		}


	}
}
