using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Adodz2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				DataSet setCounter = new DataSet();
				DataSet setProduct = new DataSet();
				SqlDataAdapter adapterCounter = new SqlDataAdapter("Select * From Counter; Select * From Product;", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Storage;Integrated Security=True;");
				SqlDataAdapter adapterProduct = new SqlDataAdapter("Select * From Product; Select * From Product;", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Storage;Integrated Security=True;");
				adapterCounter.Fill(setCounter);
				adapterProduct.Fill(setProduct);
				SqlCommandBuilder builderCounter = new SqlCommandBuilder(adapterCounter);
				SqlCommandBuilder builderProduct = new SqlCommandBuilder(adapterProduct);
				adapterCounter.InsertCommand = builderCounter.GetInsertCommand();
				adapterCounter.DeleteCommand = builderCounter.GetDeleteCommand();
				adapterCounter.UpdateCommand = builderCounter.GetUpdateCommand();
				
				adapterProduct.InsertCommand = builderProduct.GetInsertCommand();
				adapterProduct.DeleteCommand = builderProduct.GetDeleteCommand();
				adapterProduct.UpdateCommand = builderProduct.GetUpdateCommand();

				//Console.WriteLine(builderCounter.GetInsertCommand().CommandText);
				//Console.WriteLine(builderCounter.GetUpdateCommand().CommandText);
				//Console.WriteLine(builderCounter.GetDeleteCommand().CommandText);
				
				Console.WriteLine(adapterCounter.InsertCommand);

				//DataRow dr = setCounter.Tables[0].NewRow();
				//dr.SetField(0, 2);
				//dr.SetField(1, "Много пластика");
				//dr.SetField(2, 40);
				//dr.SetField(3, DateTime.Now);
				//setCounter.Tables[0].Rows.Add(dr);
				//adapterCounter.Update(setCounter);

				
				for (int i = 4; i < 100; i++)
				{
					
					setCounter.Tables[0].Rows.Add(i, "Много пластика", 40, DateTime.Now);
				}
				adapterCounter.Update(setCounter);
				
			}
			catch (Exception ex)
			{ 
				Console.WriteLine(ex.Message);
			}
			Console.ReadLine();
		}
	}
}
