using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    #region Database Model
    public class Functions : DLW_Library.MySQL { public Functions() { SetConnection("localhost", "cart", "root", ""); } }
    public class Buyer : Buyer_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string fname = "";
        public string Fname
        {
            get { return fname; }
            set { updateField("fname", value, id); fname = value; }
        }
        string lname = "";
        public string Lname
        {
            get { return lname; }
            set { updateField("lname", value, id); lname = value; }
        }
        string emailAddress = "";
        public string EmailAddress
        {
            get { return emailAddress; }
            set { updateField("emailAddress", value, id); emailAddress = value; }
        }
        string shippingAddress = "";
        public string ShippingAddress
        {
            get { return shippingAddress; }
            set { updateField("shippingAddress", value, id); shippingAddress = value; }
        }
        string billingAddress = "";
        public string BillingAddress
        {
            get { return billingAddress; }
            set { updateField("billingAddress", value, id); billingAddress = value; }
        }
        string phoneNumber = "";
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { updateField("phoneNumber", value, id); phoneNumber = value; }
        }
        public Buyer() { }
        public Buyer(string id) { loadData(id); }
        private Buyer loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `buyer` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.fname = row["fname"].ToString();
                this.lname = row["lname"].ToString();
                this.emailAddress = row["emailAddress"].ToString();
                this.shippingAddress = row["shippingAddress"].ToString();
                this.billingAddress = row["billingAddress"].ToString();
                this.phoneNumber = row["phoneNumber"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.fname = "";
            this.lname = "";
            this.emailAddress = "";
            this.shippingAddress = "";
            this.billingAddress = "";
            this.phoneNumber = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.fname = row["fname"].ToString();
                this.lname = row["lname"].ToString();
                this.emailAddress = row["emailAddress"].ToString();
                this.shippingAddress = row["shippingAddress"].ToString();
                this.billingAddress = row["billingAddress"].ToString();
                this.phoneNumber = row["phoneNumber"].ToString();
            }
        }

        public Buyer Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `buyer` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Buyer Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Buyer updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `buyer` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Buyer updateRow(string id, string fname, string lname, string emailAddress, string shippingAddress, string billingAddress, string phoneNumber)
        {
            string[] pars = { "id", "fname", "lname", "emailAddress", "shippingAddress", "billingAddress", "phoneNumber" };
            string[] values = { id, fname, lname, emailAddress, shippingAddress, billingAddress, phoneNumber };
            db.MysqlPlain("UPDATE `buyer` SET `id` = @id, `fname` = @fname, `lname` = @lname, `emailAddress` = @emailAddress, `shippingAddress` = @shippingAddress, `billingAddress` = @billingAddress, `phoneNumber` = @phoneNumber WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Buyer insert(string fname, string lname, string emailAddress, string shippingAddress, string billingAddress, string phoneNumber)
        {
            string[] pars = { "fname", "lname", "emailAddress", "shippingAddress", "billingAddress", "phoneNumber" };
            string[] values = { fname, lname, emailAddress, shippingAddress, billingAddress, phoneNumber };
            db.MysqlPlain("INSERT INTO `buyer`(`fname`, `lname`, `emailAddress`, `shippingAddress`, `billingAddress`, `phoneNumber`) VALUES(@fname, @lname, @emailAddress, @shippingAddress, @billingAddress, @phoneNumber)", pars, values);
            loadData(db.getMaxID("buyer"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `buyer` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Buyer> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `buyer` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `buyer` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `buyer` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `buyer` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `buyer` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `buyer` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `buyer` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Buyer> getAllRecords()
        {
            string query = "SELECT * FROM `buyer`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Buyer> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `buyer`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Buyer> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `buyer`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Buyer> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `buyer`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Buyer> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `buyer`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Buyer> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `buyer`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Buyer_support
    {
        public List<Buyer> createObjects(System.Data.DataTable table)
        {
            List<Buyer> objects = new List<Buyer>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Buyer instance = new Buyer();
                instance.Id = row["id"].ToString();
                instance.Fname = row["fname"].ToString();
                instance.Lname = row["lname"].ToString();
                instance.EmailAddress = row["emailAddress"].ToString();
                instance.ShippingAddress = row["shippingAddress"].ToString();
                instance.BillingAddress = row["billingAddress"].ToString();
                instance.PhoneNumber = row["phoneNumber"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Fname, Lname, EmailAddress, ShippingAddress, BillingAddress, PhoneNumber }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Fname) { return "fname"; }
            if (column == Column.Lname) { return "lname"; }
            if (column == Column.EmailAddress) { return "emailAddress"; }
            if (column == Column.ShippingAddress) { return "shippingAddress"; }
            if (column == Column.BillingAddress) { return "billingAddress"; }
            if (column == Column.PhoneNumber) { return "phoneNumber"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Buyer> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("fname"); table.Columns.Add("lname"); table.Columns.Add("emailAddress"); table.Columns.Add("shippingAddress"); table.Columns.Add("billingAddress"); table.Columns.Add("phoneNumber"); foreach (Buyer instance in objects) { table.Rows.Add(instance.Id, instance.Fname, instance.Lname, instance.EmailAddress, instance.ShippingAddress, instance.BillingAddress, instance.PhoneNumber); }
            return table;
        }

    }
    public class Category : Category_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string name = "";
        public string Name
        {
            get { return name; }
            set { updateField("name", value, id); name = value; }
        }
        public Category() { }
        public Category(string id) { loadData(id); }
        private Category loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `category` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.name = row["name"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.name = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.name = row["name"].ToString();
            }
        }

        public Category Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `category` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Category Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `category` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Category updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `category` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Category updateRow(string id, string name)
        {
            string[] pars = { "id", "name" };
            string[] values = { id, name };
            db.MysqlPlain("UPDATE `category` SET `id` = @id, `name` = @name WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Category insert(string name)
        {
            string[] pars = { "name" };
            string[] values = { name };
            db.MysqlPlain("INSERT INTO `category`(`name`) VALUES(@name)", pars, values);
            loadData(db.getMaxID("category"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `category` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Category> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `category` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `category` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `category` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `category` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `category` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `category` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `category` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `category` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `category` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `category` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `category` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `category` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `category` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Category> getAllRecords()
        {
            string query = "SELECT * FROM `category`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Category> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `category`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Category> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `category`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Category> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `category`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Category> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `category`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Category> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `category`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Category_support
    {
        public List<Category> createObjects(System.Data.DataTable table)
        {
            List<Category> objects = new List<Category>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Category instance = new Category();
                instance.Id = row["id"].ToString();
                instance.Name = row["name"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Name }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Name) { return "name"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Category> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("name"); foreach (Category instance in objects) { table.Rows.Add(instance.Id, instance.Name); }
            return table;
        }

    }
    public class Item : Item_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string name = "";
        public string Name
        {
            get { return name; }
            set { updateField("name", value, id); name = value; }
        }
        string description = "";
        public string Description
        {
            get { return description; }
            set { updateField("description", value, id); description = value; }
        }
        string price = "";
        public string Price
        {
            get { return price; }
            set { updateField("price", value, id); price = value; }
        }
        string categoryId = "";
        public string CategoryId
        {
            get { return categoryId; }
            set { updateField("categoryId", value, id); categoryId = value; }
        }
        string picture = "";
        public string Picture
        {
            get { return picture; }
            set { updateField("picture", value, id); picture = value; }
        }
        public Item() { }
        public Item(string id) { loadData(id); }
        private Item loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `item` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.name = row["name"].ToString();
                this.description = row["description"].ToString();
                this.price = row["price"].ToString();
                this.categoryId = row["categoryId"].ToString();
                this.picture = row["picture"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.name = "";
            this.description = "";
            this.price = "";
            this.categoryId = "";
            this.picture = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.name = row["name"].ToString();
                this.description = row["description"].ToString();
                this.price = row["price"].ToString();
                this.categoryId = row["categoryId"].ToString();
                this.picture = row["picture"].ToString();
            }
        }

        public Item Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Item Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Item updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `item` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Item updateRow(string id, string name, string description, string price, string categoryId, string picture)
        {
            string[] pars = { "id", "name", "description", "price", "categoryId", "picture" };
            string[] values = { id, name, description, price, categoryId, picture };
            db.MysqlPlain("UPDATE `item` SET `id` = @id, `name` = @name, `description` = @description, `price` = @price, `categoryId` = @categoryId, `picture` = @picture WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Item insert(string name, string description, string price, string categoryId, string picture)
        {
            string[] pars = { "name", "description", "price", "categoryId", "picture" };
            string[] values = { name, description, price, categoryId, picture };
            db.MysqlPlain("INSERT INTO `item`(`name`, `description`, `price`, `categoryId`, `picture`) VALUES(@name, @description, @price, @categoryId, @picture)", pars, values);
            loadData(db.getMaxID("item"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `item` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Item> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item> getAllRecords()
        {
            string query = "SELECT * FROM `item`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Item> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `item`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `item`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `item`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `item`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `item`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Item_support
    {
        public List<Item> createObjects(System.Data.DataTable table)
        {
            List<Item> objects = new List<Item>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Item instance = new Item();
                instance.Id = row["id"].ToString();
                instance.Name = row["name"].ToString();
                instance.Description = row["description"].ToString();
                instance.Price = row["price"].ToString();
                instance.CategoryId = row["categoryId"].ToString();
                instance.Picture = row["picture"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Name, Description, Price, CategoryId, Picture }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Name) { return "name"; }
            if (column == Column.Description) { return "description"; }
            if (column == Column.Price) { return "price"; }
            if (column == Column.CategoryId) { return "categoryId"; }
            if (column == Column.Picture) { return "picture"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Item> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("name"); table.Columns.Add("description"); table.Columns.Add("price"); table.Columns.Add("categoryId"); table.Columns.Add("picture"); foreach (Item instance in objects) { table.Rows.Add(instance.Id, instance.Name, instance.Description, instance.Price, instance.CategoryId, instance.Picture); }
            return table;
        }

    }
    public class Item_view : Item_view_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string description = "";
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string price = "";
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        string categoryId = "";
        public string CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        string picture = "";
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public Item_view() { }
        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.name = "";
            this.description = "";
            this.price = "";
            this.categoryId = "";
            this.picture = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.name = row["name"].ToString();
                this.description = row["description"].ToString();
                this.price = row["price"].ToString();
                this.categoryId = row["categoryId"].ToString();
                this.picture = row["picture"].ToString();
            }
        }

        public Item_view Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item_view` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Item_view Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Item_view insert(string id, string name, string description, string price, string categoryId, string picture)
        {
            string[] pars = { "id", "name", "description", "price", "categoryId", "picture" };
            string[] values = { id, name, description, price, categoryId, picture };
            db.MysqlPlain("INSERT INTO `item_view`(`id`, `name`, `description`, `price`, `categoryId`, `picture`) VALUES(@id, @name, @description, @price, @categoryId, @picture)", pars, values);
            return this;
        }
        public List<Item_view> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item_view` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item_view` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item_view` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item_view` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item_view` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `item_view` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `item_view` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Item_view> getAllRecords()
        {
            string query = "SELECT * FROM `item_view`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Item_view> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `item_view`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item_view> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `item_view`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item_view> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `item_view`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item_view> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `item_view`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Item_view> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `item_view`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Item_view_support
    {
        public List<Item_view> createObjects(System.Data.DataTable table)
        {
            List<Item_view> objects = new List<Item_view>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Item_view instance = new Item_view();
                instance.Id = row["id"].ToString();
                instance.Name = row["name"].ToString();
                instance.Description = row["description"].ToString();
                instance.Price = row["price"].ToString();
                instance.CategoryId = row["categoryId"].ToString();
                instance.Picture = row["picture"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Name, Description, Price, CategoryId, Picture }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Name) { return "name"; }
            if (column == Column.Description) { return "description"; }
            if (column == Column.Price) { return "price"; }
            if (column == Column.CategoryId) { return "categoryId"; }
            if (column == Column.Picture) { return "picture"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Item_view> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("name"); table.Columns.Add("description"); table.Columns.Add("price"); table.Columns.Add("categoryId"); table.Columns.Add("picture"); foreach (Item_view instance in objects) { table.Rows.Add(instance.Id, instance.Name, instance.Description, instance.Price, instance.CategoryId, instance.Picture); }
            return table;
        }

    }
    public class Login : Login_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string username = "";
        public string Username
        {
            get { return username; }
            set { updateField("username", value, id); username = value; }
        }
        string password = "";
        public string Password
        {
            get { return password; }
            set { updateField("password", value, id); password = value; }
        }
        public Login() { }
        public Login(string id) { loadData(id); }
        private Login loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `login` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.username = row["username"].ToString();
                this.password = row["password"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.username = "";
            this.password = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.username = row["username"].ToString();
                this.password = row["password"].ToString();
            }
        }

        public Login Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Login Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Login updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `login` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Login updateRow(string id, string username, string password)
        {
            string[] pars = { "id", "username", "password" };
            string[] values = { id, username, password };
            db.MysqlPlain("UPDATE `login` SET `id` = @id, `username` = @username, `password` = @password WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Login insert(string username, string password)
        {
            string[] pars = { "username", "password" };
            string[] values = { username, password };
            db.MysqlPlain("INSERT INTO `login`(`username`, `password`) VALUES(@username, @password)", pars, values);
            loadData(db.getMaxID("login"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `login` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Login> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login> getAllRecords()
        {
            string query = "SELECT * FROM `login`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Login> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `login`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `login`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `login`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `login`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `login`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Login_support
    {
        public List<Login> createObjects(System.Data.DataTable table)
        {
            List<Login> objects = new List<Login>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Login instance = new Login();
                instance.Id = row["id"].ToString();
                instance.Username = row["username"].ToString();
                instance.Password = row["password"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Username, Password }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Username) { return "username"; }
            if (column == Column.Password) { return "password"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Login> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("username"); table.Columns.Add("password"); foreach (Login instance in objects) { table.Rows.Add(instance.Id, instance.Username, instance.Password); }
            return table;
        }

    }
    public class Login_table : Login_table_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string username = "";
        public string Username
        {
            get { return username; }
            set { updateField("username", value, id); username = value; }
        }
        string password = "";
        public string Password
        {
            get { return password; }
            set { updateField("password", value, id); password = value; }
        }
        public Login_table() { }
        public Login_table(string id) { loadData(id); }
        private Login_table loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `login_table` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.username = row["username"].ToString();
                this.password = row["password"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.username = "";
            this.password = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.username = row["username"].ToString();
                this.password = row["password"].ToString();
            }
        }

        public Login_table Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Login_table Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Login_table updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `login_table` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Login_table updateRow(string id, string username, string password)
        {
            string[] pars = { "id", "username", "password" };
            string[] values = { id, username, password };
            db.MysqlPlain("UPDATE `login_table` SET `id` = @id, `username` = @username, `password` = @password WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Login_table insert(string username, string password)
        {
            string[] pars = { "username", "password" };
            string[] values = { username, password };
            db.MysqlPlain("INSERT INTO `login_table`(`username`, `password`) VALUES(@username, @password)", pars, values);
            loadData(db.getMaxID("login_table"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `login_table` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `login_table` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `login_table` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Login_table> getAllRecords()
        {
            string query = "SELECT * FROM `login_table`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `login_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `login_table`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `login_table`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `login_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Login_table> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `login_table`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Login_table_support
    {
        public List<Login_table> createObjects(System.Data.DataTable table)
        {
            List<Login_table> objects = new List<Login_table>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Login_table instance = new Login_table();
                instance.Id = row["id"].ToString();
                instance.Username = row["username"].ToString();
                instance.Password = row["password"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Username, Password }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Username) { return "username"; }
            if (column == Column.Password) { return "password"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Login_table> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("username"); table.Columns.Add("password"); foreach (Login_table instance in objects) { table.Rows.Add(instance.Id, instance.Username, instance.Password); }
            return table;
        }

    }
    public class Orderitem : Orderitem_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string orderId = "";
        public string OrderId
        {
            get { return orderId; }
            set { updateField("orderId", value, id); orderId = value; }
        }
        string itemId = "";
        public string ItemId
        {
            get { return itemId; }
            set { updateField("itemId", value, id); itemId = value; }
        }
        string quantity = "";
        public string Quantity
        {
            get { return quantity; }
            set { updateField("quantity", value, id); quantity = value; }
        }
        public Orderitem() { }
        public Orderitem(string id) { loadData(id); }
        private Orderitem loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `orderitem` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.orderId = row["orderId"].ToString();
                this.itemId = row["itemId"].ToString();
                this.quantity = row["quantity"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.orderId = "";
            this.itemId = "";
            this.quantity = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.orderId = row["orderId"].ToString();
                this.itemId = row["itemId"].ToString();
                this.quantity = row["quantity"].ToString();
            }
        }

        public Orderitem Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Orderitem Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Orderitem updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `orderitem` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Orderitem updateRow(string id, string orderId, string itemId, string quantity)
        {
            string[] pars = { "id", "orderId", "itemId", "quantity" };
            string[] values = { id, orderId, itemId, quantity };
            db.MysqlPlain("UPDATE `orderitem` SET `id` = @id, `orderId` = @orderId, `itemId` = @itemId, `quantity` = @quantity WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Orderitem insert(string orderId, string itemId, string quantity)
        {
            string[] pars = { "orderId", "itemId", "quantity" };
            string[] values = { orderId, itemId, quantity };
            db.MysqlPlain("INSERT INTO `orderitem`(`orderId`, `itemId`, `quantity`) VALUES(@orderId, @itemId, @quantity)", pars, values);
            loadData(db.getMaxID("orderitem"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `orderitem` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Orderitem> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orderitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orderitem> getAllRecords()
        {
            string query = "SELECT * FROM `orderitem`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Orderitem> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `orderitem`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orderitem> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `orderitem`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orderitem> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `orderitem`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orderitem> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `orderitem`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orderitem> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `orderitem`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Orderitem_support
    {
        public List<Orderitem> createObjects(System.Data.DataTable table)
        {
            List<Orderitem> objects = new List<Orderitem>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Orderitem instance = new Orderitem();
                instance.Id = row["id"].ToString();
                instance.OrderId = row["orderId"].ToString();
                instance.ItemId = row["itemId"].ToString();
                instance.Quantity = row["quantity"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, OrderId, ItemId, Quantity }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.OrderId) { return "orderId"; }
            if (column == Column.ItemId) { return "itemId"; }
            if (column == Column.Quantity) { return "quantity"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Orderitem> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("orderId"); table.Columns.Add("itemId"); table.Columns.Add("quantity"); foreach (Orderitem instance in objects) { table.Rows.Add(instance.Id, instance.OrderId, instance.ItemId, instance.Quantity); }
            return table;
        }

    }
    public class Orders : Orders_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string paymentId = "";
        public string PaymentId
        {
            get { return paymentId; }
            set { updateField("paymentId", value, id); paymentId = value; }
        }
        string buyerId = "";
        public string BuyerId
        {
            get { return buyerId; }
            set { updateField("buyerId", value, id); buyerId = value; }
        }
        string inTransit = "";
        public string InTransit
        {
            get { return inTransit; }
            set { updateField("inTransit", value, id); inTransit = value; }
        }
        public Orders() { }
        public Orders(string id) { loadData(id); }
        private Orders loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `orders` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.paymentId = row["paymentId"].ToString();
                this.buyerId = row["buyerId"].ToString();
                this.inTransit = row["inTransit"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.paymentId = "";
            this.buyerId = "";
            this.inTransit = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.paymentId = row["paymentId"].ToString();
                this.buyerId = row["buyerId"].ToString();
                this.inTransit = row["inTransit"].ToString();
            }
        }

        public Orders Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orders` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Orders Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Orders updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `orders` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Orders updateRow(string id, string paymentId, string buyerId, string inTransit)
        {
            string[] pars = { "id", "paymentId", "buyerId", "inTransit" };
            string[] values = { id, paymentId, buyerId, inTransit };
            db.MysqlPlain("UPDATE `orders` SET `id` = @id, `paymentId` = @paymentId, `buyerId` = @buyerId, `inTransit` = @inTransit WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Orders insert(string paymentId, string buyerId, string inTransit)
        {
            string[] pars = { "paymentId", "buyerId", "inTransit" };
            string[] values = { paymentId, buyerId, inTransit };
            db.MysqlPlain("INSERT INTO `orders`(`paymentId`, `buyerId`, `inTransit`) VALUES(@paymentId, @buyerId, @inTransit)", pars, values);
            loadData(db.getMaxID("orders"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `orders` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Orders> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orders` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orders` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orders` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orders` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orders` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `orders` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `orders` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Orders> getAllRecords()
        {
            string query = "SELECT * FROM `orders`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Orders> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `orders`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orders> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `orders`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orders> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `orders`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orders> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `orders`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Orders> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `orders`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Orders_support
    {
        public List<Orders> createObjects(System.Data.DataTable table)
        {
            List<Orders> objects = new List<Orders>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Orders instance = new Orders();
                instance.Id = row["id"].ToString();
                instance.PaymentId = row["paymentId"].ToString();
                instance.BuyerId = row["buyerId"].ToString();
                instance.InTransit = row["inTransit"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, PaymentId, BuyerId, InTransit }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.PaymentId) { return "paymentId"; }
            if (column == Column.BuyerId) { return "buyerId"; }
            if (column == Column.InTransit) { return "inTransit"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Orders> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("paymentId"); table.Columns.Add("buyerId"); table.Columns.Add("inTransit"); foreach (Orders instance in objects) { table.Rows.Add(instance.Id, instance.PaymentId, instance.BuyerId, instance.InTransit); }
            return table;
        }

    }
    public class Payment : Payment_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string timeStamp = "";
        public string TimeStamp
        {
            get { return timeStamp; }
            set { updateField("timeStamp", value, id); timeStamp = value; }
        }
        string buyerId = "";
        public string BuyerId
        {
            get { return buyerId; }
            set { updateField("buyerId", value, id); buyerId = value; }
        }
        string paymentInfo = "";
        public string PaymentInfo
        {
            get { return paymentInfo; }
            set { updateField("paymentInfo", value, id); paymentInfo = value; }
        }
        public Payment() { }
        public Payment(string id) { loadData(id); }
        private Payment loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `payment` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.timeStamp = row["timeStamp"].ToString();
                this.buyerId = row["buyerId"].ToString();
                this.paymentInfo = row["paymentInfo"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.timeStamp = "";
            this.buyerId = "";
            this.paymentInfo = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.timeStamp = row["timeStamp"].ToString();
                this.buyerId = row["buyerId"].ToString();
                this.paymentInfo = row["paymentInfo"].ToString();
            }
        }

        public Payment Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `payment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Payment Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Payment updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `payment` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Payment updateRow(string id, string timeStamp, string buyerId, string paymentInfo)
        {
            string[] pars = { "id", "timeStamp", "buyerId", "paymentInfo" };
            string[] values = { id, timeStamp, buyerId, paymentInfo };
            db.MysqlPlain("UPDATE `payment` SET `id` = @id, `timeStamp` = @timeStamp, `buyerId` = @buyerId, `paymentInfo` = @paymentInfo WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Payment insert(string timeStamp, string buyerId, string paymentInfo)
        {
            string[] pars = { "timeStamp", "buyerId", "paymentInfo" };
            string[] values = { timeStamp, buyerId, paymentInfo };
            db.MysqlPlain("INSERT INTO `payment`(`timeStamp`, `buyerId`, `paymentInfo`) VALUES(@timeStamp, @buyerId, @paymentInfo)", pars, values);
            loadData(db.getMaxID("payment"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `payment` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Payment> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `payment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `payment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `payment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `payment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `payment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `payment` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `payment` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Payment> getAllRecords()
        {
            string query = "SELECT * FROM `payment`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Payment> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `payment`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Payment> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `payment`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Payment> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `payment`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Payment> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `payment`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Payment> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `payment`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Payment_support
    {
        public List<Payment> createObjects(System.Data.DataTable table)
        {
            List<Payment> objects = new List<Payment>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Payment instance = new Payment();
                instance.Id = row["id"].ToString();
                instance.TimeStamp = row["timeStamp"].ToString();
                instance.BuyerId = row["buyerId"].ToString();
                instance.PaymentInfo = row["paymentInfo"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, TimeStamp, BuyerId, PaymentInfo }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.TimeStamp) { return "timeStamp"; }
            if (column == Column.BuyerId) { return "buyerId"; }
            if (column == Column.PaymentInfo) { return "paymentInfo"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Payment> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("timeStamp"); table.Columns.Add("buyerId"); table.Columns.Add("paymentInfo"); foreach (Payment instance in objects) { table.Rows.Add(instance.Id, instance.TimeStamp, instance.BuyerId, instance.PaymentInfo); }
            return table;
        }

    }
    public class Seller : Seller_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string fname = "";
        public string Fname
        {
            get { return fname; }
            set { updateField("fname", value, id); fname = value; }
        }
        string lname = "";
        public string Lname
        {
            get { return lname; }
            set { updateField("lname", value, id); lname = value; }
        }
        string altername = "";
        public string Altername
        {
            get { return altername; }
            set { updateField("altername", value, id); altername = value; }
        }
        string emailAddress = "";
        public string EmailAddress
        {
            get { return emailAddress; }
            set { updateField("emailAddress", value, id); emailAddress = value; }
        }
        string password = "";
        public string Password
        {
            get { return password; }
            set { updateField("password", value, id); password = value; }
        }
        public Seller() { }
        public Seller(string id) { loadData(id); }
        private Seller loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `seller` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.fname = row["fname"].ToString();
                this.lname = row["lname"].ToString();
                this.altername = row["altername"].ToString();
                this.emailAddress = row["emailAddress"].ToString();
                this.password = row["password"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.fname = "";
            this.lname = "";
            this.altername = "";
            this.emailAddress = "";
            this.password = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.fname = row["fname"].ToString();
                this.lname = row["lname"].ToString();
                this.altername = row["altername"].ToString();
                this.emailAddress = row["emailAddress"].ToString();
                this.password = row["password"].ToString();
            }
        }

        public Seller Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `seller` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Seller Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Seller updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `seller` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Seller updateRow(string id, string fname, string lname, string altername, string emailAddress, string password)
        {
            string[] pars = { "id", "fname", "lname", "altername", "emailAddress", "password" };
            string[] values = { id, fname, lname, altername, emailAddress, password };
            db.MysqlPlain("UPDATE `seller` SET `id` = @id, `fname` = @fname, `lname` = @lname, `altername` = @altername, `emailAddress` = @emailAddress, `password` = @password WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Seller insert(string fname, string lname, string altername, string emailAddress, string password)
        {
            string[] pars = { "fname", "lname", "altername", "emailAddress", "password" };
            string[] values = { fname, lname, altername, emailAddress, password };
            db.MysqlPlain("INSERT INTO `seller`(`fname`, `lname`, `altername`, `emailAddress`, `password`) VALUES(@fname, @lname, @altername, @emailAddress, @password)", pars, values);
            loadData(db.getMaxID("seller"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `seller` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Seller> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `seller` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `seller` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `seller` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `seller` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `seller` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `seller` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `seller` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Seller> getAllRecords()
        {
            string query = "SELECT * FROM `seller`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Seller> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `seller`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Seller> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `seller`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Seller> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `seller`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Seller> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `seller`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Seller> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `seller`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Seller_support
    {
        public List<Seller> createObjects(System.Data.DataTable table)
        {
            List<Seller> objects = new List<Seller>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Seller instance = new Seller();
                instance.Id = row["id"].ToString();
                instance.Fname = row["fname"].ToString();
                instance.Lname = row["lname"].ToString();
                instance.Altername = row["altername"].ToString();
                instance.EmailAddress = row["emailAddress"].ToString();
                instance.Password = row["password"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Fname, Lname, Altername, EmailAddress, Password }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Fname) { return "fname"; }
            if (column == Column.Lname) { return "lname"; }
            if (column == Column.Altername) { return "altername"; }
            if (column == Column.EmailAddress) { return "emailAddress"; }
            if (column == Column.Password) { return "password"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Seller> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("fname"); table.Columns.Add("lname"); table.Columns.Add("altername"); table.Columns.Add("emailAddress"); table.Columns.Add("password"); foreach (Seller instance in objects) { table.Rows.Add(instance.Id, instance.Fname, instance.Lname, instance.Altername, instance.EmailAddress, instance.Password); }
            return table;
        }

    }
    public class Stockitem : Stockitem_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string itemId = "";
        public string ItemId
        {
            get { return itemId; }
            set { updateField("itemId", value, id); itemId = value; }
        }
        string unitId = "";
        public string UnitId
        {
            get { return unitId; }
            set { updateField("unitId", value, id); unitId = value; }
        }
        string unitQuantity = "";
        public string UnitQuantity
        {
            get { return unitQuantity; }
            set { updateField("unitQuantity", value, id); unitQuantity = value; }
        }
        public Stockitem() { }
        public Stockitem(string id) { loadData(id); }
        private Stockitem loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `stockitem` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.itemId = row["itemId"].ToString();
                this.unitId = row["unitId"].ToString();
                this.unitQuantity = row["unitQuantity"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.itemId = "";
            this.unitId = "";
            this.unitQuantity = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.itemId = row["itemId"].ToString();
                this.unitId = row["unitId"].ToString();
                this.unitQuantity = row["unitQuantity"].ToString();
            }
        }

        public Stockitem Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Stockitem Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Stockitem updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `stockitem` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Stockitem updateRow(string id, string itemId, string unitId, string unitQuantity)
        {
            string[] pars = { "id", "itemId", "unitId", "unitQuantity" };
            string[] values = { id, itemId, unitId, unitQuantity };
            db.MysqlPlain("UPDATE `stockitem` SET `id` = @id, `itemId` = @itemId, `unitId` = @unitId, `unitQuantity` = @unitQuantity WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Stockitem insert(string itemId, string unitId, string unitQuantity)
        {
            string[] pars = { "itemId", "unitId", "unitQuantity" };
            string[] values = { itemId, unitId, unitQuantity };
            db.MysqlPlain("INSERT INTO `stockitem`(`itemId`, `unitId`, `unitQuantity`) VALUES(@itemId, @unitId, @unitQuantity)", pars, values);
            loadData(db.getMaxID("stockitem"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `stockitem` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Stockitem> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `stockitem` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Stockitem> getAllRecords()
        {
            string query = "SELECT * FROM `stockitem`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Stockitem> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `stockitem`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Stockitem> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `stockitem`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Stockitem> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `stockitem`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Stockitem> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `stockitem`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Stockitem> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `stockitem`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Stockitem_support
    {
        public List<Stockitem> createObjects(System.Data.DataTable table)
        {
            List<Stockitem> objects = new List<Stockitem>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Stockitem instance = new Stockitem();
                instance.Id = row["id"].ToString();
                instance.ItemId = row["itemId"].ToString();
                instance.UnitId = row["unitId"].ToString();
                instance.UnitQuantity = row["unitQuantity"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, ItemId, UnitId, UnitQuantity }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.ItemId) { return "itemId"; }
            if (column == Column.UnitId) { return "unitId"; }
            if (column == Column.UnitQuantity) { return "unitQuantity"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Stockitem> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("itemId"); table.Columns.Add("unitId"); table.Columns.Add("unitQuantity"); foreach (Stockitem instance in objects) { table.Rows.Add(instance.Id, instance.ItemId, instance.UnitId, instance.UnitQuantity); }
            return table;
        }

    }
    public class Unit : Unit_support
    {
        Functions db = new Functions(); string id = "";
        public string Id
        {
            get { return id; }
            set { updateField("id", value, id); id = value; }
        }
        string unit_number = "";
        public string Unit_number
        {
            get { return unit_number; }
            set { updateField("unit_number", value, id); unit_number = value; }
        }
        string quantutyPerUnit = "";
        public string QuantutyPerUnit
        {
            get { return quantutyPerUnit; }
            set { updateField("quantutyPerUnit", value, id); quantutyPerUnit = value; }
        }
        public Unit() { }
        public Unit(string id) { loadData(id); }
        private Unit loadData(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            foreach (System.Data.DataRow row in db.MysqlMulti("SELECT * FROM `unit` WHERE `id` = @value", pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.unit_number = row["unit_number"].ToString();
                this.quantutyPerUnit = row["quantutyPerUnit"].ToString();
            }
            return this;
        }

        private void load(string query, string[] pars, string[] values)
        {
            this.id = "";
            this.unit_number = "";
            this.quantutyPerUnit = "";
            foreach (System.Data.DataRow row in db.MysqlMulti(query, pars, values).Rows)
            {
                this.id = row["id"].ToString();
                this.unit_number = row["unit_number"].ToString();
                this.quantutyPerUnit = row["quantutyPerUnit"].ToString();
            }
        }

        public Unit Load_record_with(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `unit` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Unit Load_record_with(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            load(query, pars, values);
            return this;
        }
        public Unit updateField(string fieldName, string value, string id)
        {
            string[] pars = { "value" };
            string[] values = { value };
            db.MysqlPlain("UPDATE `unit` SET " + fieldName + " = @value WHERE `id` = " + id + "", pars, values);
            loadData(id); return this;
        }

        public Unit updateRow(string id, string unit_number, string quantutyPerUnit)
        {
            string[] pars = { "id", "unit_number", "quantutyPerUnit" };
            string[] values = { id, unit_number, quantutyPerUnit };
            db.MysqlPlain("UPDATE `unit` SET `id` = @id, `unit_number` = @unit_number, `quantutyPerUnit` = @quantutyPerUnit WHERE `id` = @id", pars, values);
            loadData(id);
            return this;
        }
        public Unit insert(string unit_number, string quantutyPerUnit)
        {
            string[] pars = { "unit_number", "quantutyPerUnit" };
            string[] values = { unit_number, quantutyPerUnit };
            db.MysqlPlain("INSERT INTO `unit`(`unit_number`, `quantutyPerUnit`) VALUES(@unit_number, @quantutyPerUnit)", pars, values);
            loadData(db.getMaxID("unit"));
            return this;
        }
        public void delete(string id)
        {
            string[] pars = { "value" };
            string[] values = { id };
            db.MysqlPlain("DELETE FROM `unit` WHERE `id` = @value", pars, values);
            loadData(id); id = "";
        }
        public List<Unit> Search_For(Column column, LogicalOperator logicalOperator, string value)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `unit` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `unit` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column, LogicalOperator logicalOperator, string value, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `unit` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column, LogicalOperator logicalOperator, string value, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `unit` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int limit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `unit` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int limit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column, LogicalOperator logicalOperator, string value, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName = getEnumColumnDbName(column); string[] pars = { "value" };
            string[] values = { value };
            string query = "";
            if (logicalOperator != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator); query = "SELECT * FROM `unit` WHERE `" + columnName + "` " + op + " @value";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName + "` LIKE CONCAT('%', @value, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> Search_For(Column column1, LogicalOperator logicalOperator1, string value1, Relation relation, Column column2, LogicalOperator logicalOperator2, string value2, Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string columnName1 = getEnumColumnDbName(column1), columnName2 = getEnumColumnDbName(column2); string[] pars = { "value1", "value2" };
            string[] values = { value1, value2 };
            string query = "";
            if (logicalOperator1 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator1); query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` " + op + " @value1";
            }
            else
            {
                query = "SELECT * FROM `unit` WHERE `" + columnName1 + "` LIKE CONCAT('%', @value1, '%')";
            }
            query += " ";
            if (logicalOperator2 != LogicalOperator.LIKE)
            {
                string op = getLogicalOperatorSymbol(logicalOperator2); query += relation.ToString() + " `" + columnName2 + "` " + op + " @value2";
            }
            else
            {
                query += relation.ToString() + " `" + columnName2 + "` LIKE CONCAT('%', @value2, '%')";
            }
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query, pars, values));
        }
        public List<Unit> getAllRecords()
        {
            string query = "SELECT * FROM `unit`";
            return createObjects(db.MysqlMulti(query));
        }
        public List<Unit> getAllRecords(Column order_column, Order order)
        {
            string query = "SELECT * FROM `unit`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Unit> getAllRecords(int limit)
        {
            string query = "SELECT * FROM `unit`";
            query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Unit> getAllRecords(int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `unit`";
            query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Unit> getAllRecords(Column order_column, Order order, int limit)
        {
            string query = "SELECT * FROM `unit`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + limit + ""; return createObjects(db.MysqlMulti(query));
        }
        public List<Unit> getAllRecords(Column order_column, Order order, int lowerLimit, int upperLimit)
        {
            string query = "SELECT * FROM `unit`";
            string orderCol = getEnumColumnDbName(order_column); query += " ORDER BY `" + orderCol + "` " + getOrder(order) + ""; query += " LIMIT " + lowerLimit + ", " + upperLimit + ""; return createObjects(db.MysqlMulti(query));
        }
    }
    public class Unit_support
    {
        public List<Unit> createObjects(System.Data.DataTable table)
        {
            List<Unit> objects = new List<Unit>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                Unit instance = new Unit();
                instance.Id = row["id"].ToString();
                instance.Unit_number = row["unit_number"].ToString();
                instance.QuantutyPerUnit = row["quantutyPerUnit"].ToString();
                objects.Add(instance);
            }
            return objects;
        }

        public enum LogicalOperator { EQUAL_TO, NOT_EQUAL_TO, LESS_THAN, LESS_THAN_OR_EQUAL_TO, GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LIKE }
        public string getLogicalOperatorSymbol(LogicalOperator operatorName)
        {
            if (operatorName == LogicalOperator.EQUAL_TO) { return "="; }
            if (operatorName == LogicalOperator.NOT_EQUAL_TO) { return "!="; }
            if (operatorName == LogicalOperator.LESS_THAN) { return "<"; }
            if (operatorName == LogicalOperator.LESS_THAN_OR_EQUAL_TO) { return "<="; }
            if (operatorName == LogicalOperator.GREATER_THAN) { return ">"; }
            if (operatorName == LogicalOperator.GREATER_THAN_OR_EQUAL_TO) { return ">="; }
            return "";
        }
        public enum Order { ASCENDING, DESCENDING }
        public string getOrder(Order order)
        {
            if (order == Order.ASCENDING) { return "ASC"; }
            if (order == Order.DESCENDING) { return "DESC"; }
            return "ASC";
        }
        public enum Relation { AND, OR }
        public enum Column { Id, Unit_number, QuantutyPerUnit }
        public string getEnumColumnDbName(Column column)
        {
            if (column == Column.Id) { return "id"; }
            if (column == Column.Unit_number) { return "unit_number"; }
            if (column == Column.QuantutyPerUnit) { return "quantutyPerUnit"; }
            return "";
        }
        public System.Data.DataTable createDataTable(List<Unit> objects)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("id"); table.Columns.Add("unit_number"); table.Columns.Add("quantutyPerUnit"); foreach (Unit instance in objects) { table.Rows.Add(instance.Id, instance.Unit_number, instance.QuantutyPerUnit); }
            return table;
        }

    }
    #endregion Database Model
}
