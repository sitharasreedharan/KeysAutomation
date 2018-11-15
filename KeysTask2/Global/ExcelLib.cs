using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using NUnit.Framework;

namespace KeysTask2.Global
{
    public class ExcelLib
    {
        static List<Datacollection> dataCol = new List<Datacollection>();
        public static DataTable ExcelToDataTable(string fileName,string sheetName)
        {
            //open file and returns as Stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //Createopenxmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx            
            //excelReader.IsFirstRowAsColumnNames = true;    //Set the First Row as Column Name   
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            //Return as DataSet
            DataSet result = excelReader.AsDataSet(conf);
            //Get all the Tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            DataTable resultTable = table[sheetName];
           
            table.Clear();
            result.Clear();
            excelReader.Close();
            stream.Dispose();

            return resultTable;
        }
        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        public static void ClearData()
        {
            dataCol.Clear();
        }

        public static void PopulateInCollection(string fileName,string sheetName)
        {
            ClearData();
            DataTable table = ExcelToDataTable(fileName, sheetName);            
            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col <= table.Columns.Count-1; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                    
                }
            }
            
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();


                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured.Exception is " + e.ToString());
                return null;
            }
        }
    }

}
