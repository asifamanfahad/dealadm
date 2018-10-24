using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for AppDataContract
/// </summary>
[DataContract]
public class AppDataContract
{
    [DataMember]
    public string DealId { set; get; }
    [DataMember]
    public string DealTitle { set; get; }
    
    
}