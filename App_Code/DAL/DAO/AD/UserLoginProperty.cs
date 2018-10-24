using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserLoginProperty
/// </summary>
public class UserLoginProperty
{
    public UserLoginProperty()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    public int UserId { get; set; }
    public string UserFullName { get; set; }
    public int AdminType { get; set; }

}
