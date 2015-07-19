﻿using System.Web.Optimization;
using Ilaro.Admin.Infrastructure;

namespace Ilaro.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.VirtualPathProvider = new EmbeddedVirtualPathProvider();
            bundles.Add(new ScriptBundle("~/ira/jquery").Include(
                        "~/ira/jquery-2.1.0.min.js"));
            bundles.Add(new ScriptBundle("~/ira/scripts").Include(
                        "~/ira/jquery.validate.min.js",
                        "~/ira/jquery.validate.unobtrusive.min.js",
                        "~/ira/chosen.jquery.min.js",
                        "~/ira/moment.min.js",
                        "~/ira/bootstrap-datetimepicker.min.js",
                        "~/ira/bootstrap.min.js",
                        "~/ira/bootstrap-spinedit.js",
                        "~/ira/marked.min.js",
                        "~/ira/bootstrap-markdown.js",
                        "~/ira/summernote.min.js",
                        "~/ira/jquery.bootstrap-duallistbox.min.js",
                        "~/ira/bootstrap.file-input.js",
                        "~/ira/ilaro.js"));

            bundles.Add(new StyleBundle("~/ira/css").Include(
                      "~/ira/bootstrap.min.css",
                      "~/ira/font-awesome.min.css",
                      "~/ira/bootstrap-datetimepicker.min.css",
                      "~/ira/chosen.min.css",
                      "~/ira/bootstrap-spinedit.css",
                      "~/ira/bootstrap-markdown.min.css",
                      "~/ira/summernote.css",
                      "~/ira/bootstrap-duallistbox.min.css",
                      "~/ira/site.css"));
        }
    }
}