using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Atlassian;
using Atlassian.Jira;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace JIRABot_Application.Modal
{
    [Serializable]
    public class JiraConnection: IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(GetTasks);
        }
        public async Task GetTasks(IDialogContext context, IAwaitable<object> result)
        {
            var actvity = await result as Activity;
            // create a connection to JIRA using the Rest client
           

            // use LINQ syntax to retrieve issues
            var issues = from i in jira.Issues.Queryable
                         where i.Assignee == "Shanky Jain"
                         orderby i.Created
                         select i;

            var abc = string.Empty;
            foreach (var a in issues) {
                abc = a.Key +", "+ abc;
            }
           // var abc = Convert.ToString(issues.Count());

            await context.PostAsync(abc);
            //await context.PostAsync("hello"); // issues
            context.Wait(GetTasks);
            
            //string jqlString = PrepareJqlbyDates("2014-03-01", "2014-03-31");
            //IEnumerable < Atlassian.Jira.Issue >< atlassian.jira.issue >
            //        jiraIssues = jiraConn.GetIssuesFromJql(jqlString, 999);

            //foreach (var issue in jiraIssues)
            //{
            //    System.Console.WriteLine(issue.Key.Value + " -- " + issue.summary);
            //}
        }
        //static string PrepareJqlbyDates(string beginDate, string endDate)
        //{
        //    string jqlString = "project = PRJ AND status = Closed AND 
        //    resolved >= "+beginDate+" AND resolved <= "+ endDate;
        //    return jqlString;
        //}
    }

}