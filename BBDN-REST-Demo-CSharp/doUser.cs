using BBDNRESTDemoCSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDN_REST_Demo_CSharp
{
   public  class doUser
    {

       public async Task<DataTable> Getuser()
        {
            Authorizer authorizer = new Authorizer();
            Token token = new Token();
            token = await authorizer.Authorize();
            UserService userService = new UserService(token);
            DataTable user = await userService.ReadAllObject();
            return user;
        }
       public async Task<User> CreateUser(User newUser)
       {
           Authorizer authorizer = new Authorizer();
           Token token = new Token();
           token = await authorizer.Authorize();
           UserService userService = new UserService(token);
           User user = await userService.CreateObject(newUser);
           return user;
       }

       public async Task<DataTable> BulkCreateUser(DataTable dtUsers)
       {

           DataTable dtInsertUser = new DataTable("BBUserLog");

           /*BBUserLogDataTableSchema(dtInsertUser);
           
           // BBID,BBuuid,BBUniqueId,StudentNo,Username,Action,Createdate
           Authorizer authorizer = new Authorizer();
           Token token = new Token();
           token = await authorizer.Authorize();
           UserService userService = new UserService(token);
          

           if (dtUsers.Rows.Count > 0)
           {
               foreach (DataRow dr in dtUsers.Rows)
               {
                   string StudentNo = string.Empty, Username = string.Empty, last_name = string.Empty, first_name = string.Empty;

                   StudentNo = Convert.ToString(dr["StudentNo"]);
                   Username = Convert.ToString(dr["login_id"]);
                   last_name = Convert.ToString(dr["last_name"]);
                   first_name = Convert.ToString(dr["first_name"]);
                   #region "Set Insert User"
                   User newuser = new User();
                   newuser.uuid = string.Empty;
                   newuser.externalId = StudentNo;
                   newuser.password = " ";
                   newuser.userName = Username;
                   newuser.studentId = StudentNo;
                   //user.educationLevel = string.Empty;
                   //user.gender = string.Empty;
                   //user.birthDate = string.Empty;
                   string[] systemrole = { " " };
                   newuser.systemRoleIds = systemrole;
                   UserAvailability availables = new UserAvailability();
                   availables.available = "Yes";
                   newuser.availability = availables;
                   Name name = new Name();
                   name.given = first_name;
                   name.family = last_name;
                   name.middle = last_name;
                   name.other = last_name;
                   name.suffix = last_name;
                   newuser.name = name;
                   Job job = new Job();
                   //job.title = string.Empty;
                   //job.department = string.Empty;
                   //job.company = string.Empty;
                   newuser.job = job;
                   Contact contact = new Contact();
                   //contact.homePhone = string.Empty;
                   //contact.mobilePhone = string.Empty;
                   //contact.businessPhone = string.Empty;
                   //contact.businessFax = string.Empty;
                   //contact.email = string.Empty;
                   //contact.webPage = string.Empty;
                   newuser.contact = contact;
                   Address address = new Address();
                   //address.street1 = string.Empty;
                   //address.street2 = string.Empty;
                   //address.city = string.Empty;
                   //address.state = string.Empty;
                   //address.zipCode = string.Empty;
                   //address.country = string.Empty;
                   newuser.address = address;
                   UserLocale locale = new UserLocale();
                   //locale.id = string.Empty;
                   //locale.calendar = string.Empty;
                   //locale.firstDayOfWeek = string.Empty;
                   newuser.locale = locale;
                   #endregion
                   User  user = await userService.CreateObject(newuser);
                   string status = string.Empty;
                   status = Convert.ToString(Constants.RESPONSERESULT);
                   DataRow dr;     
                    if (status == "Create")
                    {
                        dr = dtInsertUser.NewRow();
                        dr["BBID"] = "Nike";
                        dr["BBuuid"] = "Nike";
                        dr["BBUniqueId"] = "Nike";
                        dr["StudentNo"] = "Nike";
                        dr["Username"] = "Nike";
                        dr["Action"] = "Nike";
                        dr["Createdate"] = DateTime.Now.Date;

                        dtInsertUser.Rows.Add(dr);
                         
                    }
               }
           }*/


           return dtInsertUser;
       }

       private static void BBUserLogDataTableSchema(DataTable dtInsertUser)
       {
           // Create Column 1: BBID
           DataColumn BBIDColumn = new DataColumn();
           BBIDColumn.ColumnName = "BBID";
           // Create Column 2: BBuuid
           DataColumn BBuuidColumn = new DataColumn();
           BBuuidColumn.ColumnName = "BBuuid";
           // Create Column 3: BBUniqueId
           DataColumn BBUniqueIdColumn = new DataColumn();
           BBUniqueIdColumn.ColumnName = "BBUniqueId";

           // Create Column 4: StudentNo
           DataColumn StudentNoColumn = new DataColumn();
           StudentNoColumn.ColumnName = "StudentNo";

           // Create Column 5: Username
           DataColumn UsernameColumn = new DataColumn();
           UsernameColumn.ColumnName = "Username";

           // Create Column 6: Action
           DataColumn ActionColumn = new DataColumn();
           ActionColumn.ColumnName = "Action";

           // Create Column 7: Createdate
           DataColumn CreatedateColumn = new DataColumn();
           CreatedateColumn.DataType = Type.GetType("System.DateTime");
           CreatedateColumn.ColumnName = "Createdate";


           // Add the columns to the (BBUserLog) dtInsertUser DataTable
           dtInsertUser.Columns.Add(BBIDColumn);
           dtInsertUser.Columns.Add(BBuuidColumn);
           dtInsertUser.Columns.Add(BBUniqueIdColumn);
           dtInsertUser.Columns.Add(StudentNoColumn);
           dtInsertUser.Columns.Add(UsernameColumn);
           dtInsertUser.Columns.Add(ActionColumn);
           dtInsertUser.Columns.Add(CreatedateColumn);

       }
     
       public async Task<User> UpdateUser(User newUser)
       {
            Authorizer authorizer = new Authorizer();
            Token token = new Token();
            token = await authorizer.Authorize();
            UserService userService = new UserService(token);
            User user= await userService.UpdateObject(newUser);
            return user;
       }
       
        
    }
}
