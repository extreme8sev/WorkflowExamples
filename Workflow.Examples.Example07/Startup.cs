#region Usings

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Workflow.Examples.Example03;
using Workflow.Examples.Example04;
using WorkflowCore.Interface;
using MyDataClass03 = Workflow.Examples.Example03.MyDataClass;
using MyDataClass04 = Workflow.Examples.Example04.MyDataClass;

#endregion

namespace Workflow.Examples.Example07
{
    public class Startup
    {
        #region  Public Methods

        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env)
        {
            var host = app.ApplicationServices.GetService<IWorkflowHost>();
            host.RegisterWorkflow<PassingDataWorkflow, MyDataClass03>();
            host.RegisterWorkflow<EventSampleWorkflow, MyDataClass04>();

            host.Start();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddWorkflow();
            services.AddMvc();
        }

        #endregion
    }
}