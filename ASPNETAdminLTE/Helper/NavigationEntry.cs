using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETAdminLTE.Helper
{
    public class NavigationEntry
    {
        public NavigationEntry(string linkText, string actionName, string controllerName, string faIcon)
        {
            LinkText = linkText;
            ActionName = actionName;
            ControllerName = controllerName;
            FaIncon = faIcon;
        }

        public NavigationEntry(string linkText, string actionName, string controllerName, string faIcon, List<NavigationEntry> children)
        {
            LinkText = linkText;
            ActionName = actionName;
            ControllerName = controllerName;
            FaIncon = faIcon;
            this.children = children;
        }

        public string LinkText { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string FaIncon { get; set; }

        private List<NavigationEntry> children = new List<NavigationEntry>();

        public List<NavigationEntry> Children
        { get
            { return children; }
        }
    }
}
