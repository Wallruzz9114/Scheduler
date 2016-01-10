using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DHTMLX.Scheduler;

namespace Scheduler {
    public partial class _Default : System.Web.UI.Page {
        public DHXScheduler Scheduler { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            this.Scheduler = new DHXScheduler();

            Scheduler.InitialDate = new DateTime(2016, 01, 01);// the initial data of Scheduler

            Scheduler.Config.first_hour = 8;//the minimum value of the hour scale
            Scheduler.Config.last_hour = 19;//the maximum value of the hour scale
            Scheduler.Config.time_step = 30;//the scale interval for the time selector in the lightbox
            Scheduler.Config.limit_time_select = true;// sets the max and min values for the time selector in the lightbox to the values of the last_hour and first_hour options

            Scheduler.DataAction = this.ResolveUrl("~/Data.ashx");// the handler which defines loading data to Scheduler
            Scheduler.SaveAction = this.ResolveUrl("~/Save.ashx");// the handler which defines create/update/delete logic
            Scheduler.LoadData = true;
            Scheduler.EnableDataprocessor = true;

        }
    }
}
