using DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks.Luxoft;

namespace DotNetExamplesAndNotes.ConsoleApp.ProgrammingTasks;

public static class ProgrammingTaskLuxoft
{
    /// <summary>
    /// Create an interface called Stack with methods Push(), Pop() and property Length.
    /// Create a class that implements this interface. Use an array to implement stack
    /// data structure.
    /// </summary>
    public static void TestMethod()
    {
        IStack<int> st = new MyStack<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, });
        var x = st.Pop();
    }
}

/*
 * Below C# code generates below SQL statement, which, when executing throws exception given at the bottom.
 * Luxoft/DXC 
 * 
protected void Application_Start(object sender, EventArgs e)
{
    Application["OnlineUsers"] = 0;

    OnlineUsers.Update_SessionEnd_And_Online(
        DateTime.Now,
        false);

    AddTask("DoStuff", 10);
}

ALTER Procedure [dbo].[sp_OnlineUsers_Update_SessionEnd_And_Online]
    @Session_End datetime,
    @Online bit
As
Begin
    Update OnlineUsers
    SET
        [Session_End] = @Session_End,
        [Online] = @Online
 
End

[SqlException (0x80131904): Timeout expired. The timeout period elapsed prior to completion of the operation or the server is not responding.
    The statement has been terminated.]

System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection) +404
System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning() +412
System.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj) +1363
System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString) +6387741
System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async) +6389442
System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, DbAsyncResult result) +538
System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(DbAsyncResult result, String methodName, Boolean sendToPipe) +689
System.Data.SqlClient.SqlCommand.ExecuteNonQuery() +327
NovinMedia.Data.DbObject.RunProcedure(String storedProcName, IDataParameter[] parameters, Int32& rowsAffected) +209
DataLayer.OnlineUsers.Update_SessionEnd_And_Online(Object Session_End, Boolean Online) +440
NiceFileExplorer.Global.Application_Start(Object sender, EventArgs e) +163
[HttpException (0x80004005): Timeout expired. The timeout period elapsed prior to completion of the operation or the server is not responding. The statement has been terminated.]
System.Web.HttpApplicationFactory.EnsureAppStartCalledForIntegratedMode(HttpContext context, HttpApplication app) +4052053
System.Web.HttpApplication.RegisterEventSubscriptionsWithIIS(IntPtr appContext, HttpContext context, MethodInfo[] handlers) +191
System.Web.HttpApplication.InitSpecial(HttpApplicationState state, MethodInfo[] handlers, IntPtr appContext, HttpContext context) +352
System.Web.HttpApplicationFactory.GetSpecialApplicationInstance(IntPtr appContext, HttpContext context) +407
System.Web.Hosting.PipelineRuntime.InitializeApplication(IntPtr appContext) +375
[HttpException (0x80004005): Timeout expired. The timeout period elapsed prior to completion of the operation or the server is not responding. The statement has been terminated.]
System.Web.HttpRuntime.FirstRequestInit(HttpContext context) +11686928 System.Web.HttpRuntime.EnsureFirstRequestInit(HttpContext context) +141 System.Web.HttpRuntime.ProcessRequestNotificationPrivate(IIS7WorkerRequest wr, HttpContext context) +4863749

 */
