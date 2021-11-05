using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace AngularDemo.Models
{
	public class DAL
	{

		public static MySqlConnection DB;

		public static List<Character> allChars = new List<Character>();


		public static void GetChars() => allChars = DB.GetAll<Character>().ToList();



		public static IEnumerable<Character> GetAll() => DB.GetAll<Character>();
		public static Character  GetChar(int cid) => DB.Get<Character>(cid);


		public static void Add(Character c) => DB.Insert(c);

		public static bool Delete(int cid) => DB.Delete(new { id = cid });







	}
}
