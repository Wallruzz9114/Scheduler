using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DHTMLX.Common;
using System.Globalization;

namespace Scheduler {
    /// <summary>
    /// Summary description for Save
    /// </summary>
    public class Save : IHttpHandler {
        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/xml";// the data is passed in XML format

            var action = new DataAction(context.Request.Form);
            var data = new SchedulerDataContext();

            try {
                var changedEvent = (Event)DHXEventsHelper.Bind(typeof(Event), context.Request.Form);

                switch (action.Type) {
                    case DataActionTypes.Insert: // Insert logic
                        data.Events.InsertOnSubmit(changedEvent);
                        break;
                    case DataActionTypes.Delete: // Delete logic
                        changedEvent = data.Events.SingleOrDefault(ev => ev.EventID == action.SourceId);
                        data.Events.DeleteOnSubmit(changedEvent);
                        break;
                    default:// "update" // Update logic
                        var updated = data.Events.SingleOrDefault(ev => ev.EventID == action.SourceId);
                        DHXEventsHelper.Update(updated, changedEvent, new List<string>() { "EventID" });
                        break;
                }
                data.SubmitChanges();
                action.TargetId = changedEvent.EventID;
            } catch (Exception) {
                action.Type = DataActionTypes.Error;
            }

            context.Response.Write(new AjaxSaveResponse(action));
        }

        public bool IsReusable { get { return false; } }
    }
}