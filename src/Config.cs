// Name: Config.cs
// Date: 2006 08 18
// Author: Stjepan Glavina
// Email: stjepang AT gmail DOT com
// 
// Copyright 2006 Stjepan Glavina
// 
// This file is part of Stjerm.
//
// Stjerm is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// Stjerm is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Stjerm; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

using System;
using System.IO;

namespace Stjerm
{
	public class Config
	{
		private string filename = "/home/" +
								  System.Environment.UserName.ToString() +
								  "/.stjermrc";
		
		public Config()
		{
			FileInfo fi = new FileInfo(filename);
			if (!fi.Exists || fi.Length < 20) // if doesn't exist or if empty
			{
				GenerateFile();
			}
		}
		
		public string GetOption(string opt)
		{
			string val = "";
			StreamReader sr = new StreamReader(filename);
			
			try
			{
				/*string line = sr.ReadLine();
				while (line != null)
				{
					line = sr.ReadLine();
					if (line.StartsWith(opt))
					{
						val = line.Substring(opt.Length + 1);
					}
				}*/
			}
			catch (System.Exception e)
			{
				Console.Error.WriteLine("ERROR: Can't read file " +
										filename.ToString() +
										"\nError message: " +
										e.Message);
				AppStjerm.Exit(2);
			}
			finally
			{
				sr.Close();
			}
			
			return val;
		}
		
		private void GenerateFile()
		{
			StreamWriter sw = new StreamWriter(filename);
			string contents = "# DO NOT EDIT THIS FILE! EDITING THIS FILE MAY CAUSE STJERM CRASH!\n" +
							  "sticky=1\n" +
							  "allworkspaces=1\n" +
							  "showdeco=0\n";
			try
			{
				sw.Write(contents);
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("ERROR: Can't write to file " +
										filename.ToString() +
										"\nError message: " +
										e.Message);
				AppStjerm.Exit(3);
			}
			finally
			{
				sw.Close();
			}
		}
	}
}
