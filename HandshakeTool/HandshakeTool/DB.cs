using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Threading;

namespace HandshakeTool
{
	public static class DB
	{
		/* ************** */
		/*   PROPERTIES	  */
		/* ************** */

		private const int NUM_TABLES = 2;
		public enum Table
		{
			ImageFolder = 0,
			Label,
			Box
		}

		private static readonly string LABEL_TABLE = "Label";
		private static readonly string BOX_TABLE = "Box";

		private static readonly string DB_FOLDER = "./database/";
		private static readonly string TRAIN_FOLDER = "./images/train/";
		private static readonly string TEST_FOLDER = "./images/test/";
		private static readonly string DB_EXT = ".xml";
		private static readonly int MAX_COLUMNS = 6;

		private static readonly string[] DB_FILES = {
			DB_FOLDER + LABEL_TABLE + DB_EXT,
			DB_FOLDER + BOX_TABLE + DB_EXT
		};

		public static readonly int[] NUM_FIELDS = { 2, 6 };

		private static DataTable projectTable = new DataTable(LABEL_TABLE);
		private static DataTable dayTable = new DataTable(BOX_TABLE);


		#region columns


		private static bool[] hasIndex = { true, true, false };


		public enum Label
		{
			id = 0,
			label
		}

		public enum Box
		{
			filename,
			label,
			xmin,
			xmax,
			ymin,
			ymax
		}



		public static readonly string[,] FieldTypes =
		{
			// label table
			{
				"System.Int32",
				"System.String",
				"",
				"",
				"",
				""
			},
			// box table
			{
				"System.String",
				"System.Int32",
				"System.Int32",
				"System.Int32",
				"System.Int32",
				"System.Int32"
			}
		};



		#endregion

		#region init


		/**
		* \brief	Copies the database XML file into memory.
		* 
		* \param	void
		* 
		* \return	void
		*/
		public static void Init()
		{

			DataTable pTable;

			// initilize all tables with correct collumns
			InitTables();

			for (int i = 0; i < NUM_TABLES; ++i)
			{
				// point to right table/set
				pTable = getTable((Table)i);
				//pSet = PointToSet((Table)i);

				// if file exists, store in RAM
				if (File.Exists(DB_FILES[i]))
				{
					pTable.ReadXml(DB_FILES[i]);
				}
				else
				{
					// create database file
					pTable.WriteXml(DB_FILES[i], XmlWriteMode.WriteSchema);
				}
			}
		}


		/**
		* \brief	Creates the tables.
		* 
		* \param	void
		* 
		* \return	void
		*/
		private static void InitTables()
		{
			// create database directory if it doesn't exist
			if (!Directory.Exists(DB_FOLDER))
			{
				Directory.CreateDirectory(DB_FOLDER);
			}

			DataTable pTable;

			// add all columns
			for (int tableIndex = 0; tableIndex < NUM_TABLES; ++tableIndex)
			{
				pTable = getTable((Table)tableIndex);

				bool isUnique = false;

				if (hasIndex[tableIndex])
				{
					isUnique = true;
				}
				pTable.Columns.Add(new DataColumn
				{
					DataType = Type.GetType(FieldTypes[tableIndex, 0]),
					ColumnName = GetFieldEnum((Table)tableIndex, 0),
					ReadOnly = false,
					Unique = isUnique,
				});

				// add first column (might by primary key)
				if (isUnique)
				{
					AssignPrimaryKey(pTable, GetFieldEnum((Table)tableIndex, 0));
				}

				// add non-primary columns
				for (int columnIndex = 1; columnIndex < NUM_FIELDS[tableIndex]; ++columnIndex)
				{
					pTable.Columns.Add(new DataColumn
					{
						DataType = Type.GetType(FieldTypes[tableIndex, columnIndex]),
						ColumnName = GetFieldEnum((Table)tableIndex, columnIndex),
						ReadOnly = false,
						Unique = false
					});
				}
			}



		}


		/**
		* \brief	Assisngs a primary key to the table.
		* 
		* \param	DataTable table: The table to assign the primary key to.
		* \param	string column: The column to assign it it.
		* 
		* \return	void
		*/
		private static void AssignPrimaryKey(DataTable table, string column)
		{
			// make ID primary key
			DataColumn[] key = new DataColumn[1];   // make column
			key[0] = table.Columns[column];    // get reference to column in table
			key[0].AutoIncrement = true;
			key[0].AutoIncrementStep = 1;
			table.PrimaryKey = key;          // set table's column's key to this
		}



		#endregion

		#region pointers


		/**
		* \brief	Points to a table.
		* 
		* \param	The table to point to
		* 
		* \return	Retuns a table
		*/
		private static DataTable getTable(Table table)
		{
			switch (table)
			{
				case Table.Label:
					return projectTable;

				case Table.Box:
					return dayTable;

				default:
					throw new ArgumentException("Tried to point a table that doesn't have an index", "Table whichTable");
			}
		}

		private static string[] getFieldEnums(Table table)
		{
			switch (table)
			{
				case Table.Label:
					return Enum.GetNames(typeof(Label));

				case Table.Box:
					return Enum.GetNames(typeof(Box));

				default:
					throw new ArgumentException("Tried to point a table that doesn't have an index", "Table whichTable");
			}
		}


		public static string GetFieldEnum(Table table, int index)
		{
			switch (table)
			{
				case Table.Label:
					return Enum.GetName(typeof(Label), index);

				case Table.Box:
					return Enum.GetName(typeof(Box), index);

				default:
					throw new ArgumentException("Tried to point a table that doesn't have an index", "Table whichTable");
			}
		}

		#endregion




		#region CRUD


		/**
		* \brief	Gets the column of a table
		* 
		* \param	Table whichTable: the table to get the column index from
		* \param	string column: the column to get the column index from
		* 
		* \return	Returns the column index
		*/
		private static int GetColumnIndex(Table whichTable, string column)
		{
			int tableIndex = (int)whichTable;
			int columnIndex = -1;

			for (int i = 0; i < MAX_COLUMNS; ++i)
			{
				
				if (GetFieldEnum(whichTable, i).Equals(column))
				{
					columnIndex = i;
					break;
				}
			}

			if (columnIndex == -1)
			{
				throw new KeyNotFoundException("Tried to get the index of a column that does not belong to the corresponding table");
			}

			return columnIndex;
		}


		public static int Insert(Table whichTable, string[] columns, string[] values)
		{
			int tableIndex = (int)whichTable;

			// determine number of columns form input
			int smallestLength = Math.Min(columns.Length, values.Length);

			DataTable pTable = getTable(whichTable);

			// create row, put values in it, put in table
			DataRow newRow = pTable.NewRow();

			// put values into new row
			for (int i = 0; i < smallestLength; ++i)
			{
				string datatype = FieldTypes[tableIndex, GetColumnIndex(whichTable, columns[i])];

				if (datatype.Equals("System.String")
					| datatype.Equals("System.Int32")
					| datatype.Equals("System.Double"))
				{
					newRow[columns[i]] = values[i];
				}
				else if (datatype.Equals("System.Boolean"))
				{
					newRow[columns[i]] = bool.Parse(values[i]);
				}
				else
				{
					throw new ArgumentException("Tried to insert a column with a data type that hasn't boon accounted for");
				}
			}

			// put rown in table
			pTable.Rows.Add(newRow);
			pTable.WriteXml(DB_FILES[(int)whichTable], XmlWriteMode.WriteSchema);
			return (pTable.Rows.Count - 1);
		}


		/**
		* \brief	Queries many rows
		* 
		* \param	Table whichTable: The table to query.
		* \param	string keyValueQuery: The query.
		* 
		* \return	Retuns a serialized version of the queried rows.
		*/
		public static DataRow[] SearchMany(Table whichTable, string column, string value)
		{
			// query the database and get records
			return getTable(whichTable).Select(column + " = '" + value + "'");
		}


		/**
		* \brief	Counts number of rows in a table
		* 
		* \param	Table whichTable: The table to query.
		* 
		* \return	Returns the number of rows in a table.
		*/
		public static int CountRows(Table table)
		{
			return getTable(table).Select().Length;
		}


		/**
		* \brief	Queries one record
		* 
		* \param	Table whichTable: The table to query.
		* \param	string primaryKeyValue: The primary key of the row to query.
		* 
		* \return	Retuns a serialized version of the queried row.
		*/
		public static DataRow SearchByKey(Table whichTable, string primaryKeyValue)
		{
			return getTable(whichTable).Rows.Find(primaryKeyValue);
		}


		/**
		* \brief	Updates a row.
		* 
		* \param	Table whichTable: The table to update
		* \param	string primaryKeyValue: the row to update
		* \param	string recordData: the values to update it to
		* 
		* \return	Retuns true if successful, otherwise false is returned.
		*/
		public static void Update(Table whichTable, int id, string[] columns, string[] values)
		{
			int tableIndex = (int)whichTable;
			DataTable pTable = getTable(whichTable);

			// query row
			string queryPair = GetFieldEnum(whichTable, 0) + " = '" + id + "'";
			DataRow foundRow = pTable.Select(queryPair).FirstOrDefault();

			if (foundRow != null)
			{
				int smallerLength = Math.Min(columns.Length, values.Length);
				for (int i = 0; i < smallerLength; ++i)
				{
					foundRow[columns[i]] = values[i];
				}
			}

			pTable.WriteXml(DB_FILES[(int)whichTable], XmlWriteMode.WriteSchema);
		}

		private static string constructQueryString(string[] columns, string[] values)
		{
			string query = "";
			if ((columns != null) & (values != null))
			{
				if ((columns.Length > 0) & (values.Length > 0))
				{
					int smallerLength = Math.Min(columns.Length, values.Length);

					for (int i = 0; i < smallerLength; ++i)
					{
						int validArgCount = 0;
						if (!string.IsNullOrWhiteSpace(columns[i])
							& !string.IsNullOrWhiteSpace(values[i]))
						{
							if (validArgCount > 0)
							{
								query += " AND ";
							}
							query += columns[i] + " = '" + values[i] + "'";
							++validArgCount;
						}
					}
				}
			}
			return query;
		}


		public static void Remove(Table table, string[] columns, string[] values)
		{
			DataTable dataTable = getTable(table);
			string queryString = constructQueryString(columns, values);

			DataRow row = dataTable.Select(queryString).FirstOrDefault();
			if (row != null)
			{
				row.Delete();
				dataTable.AcceptChanges();
				dataTable.WriteXml(DB_FILES[(int)table], XmlWriteMode.WriteSchema);
			}
		}


		#endregion
	}
}
