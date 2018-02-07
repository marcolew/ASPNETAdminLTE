using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETAdminLTE.Helper
{
    public class PanelContainer : IDisposable
    {

            private readonly TextWriter _writer;

            public PanelContainer(TextWriter writer)
            {
                _writer = writer;
            }

            public void Dispose()
            {
                _writer.Write("</div></div></div>");
            }
        
    }
}
