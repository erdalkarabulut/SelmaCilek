using System.ComponentModel;

namespace Bps.Core.AttributeHelpers
{
    public class CsDisplayNameAttribute : DisplayNameAttribute
    {
        private readonly string resourceName;
        public CsDisplayNameAttribute(string resourceName)
            : base()
        {
            this.resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                var name = Resources.Resources.ResourceManager.GetString(this.resourceName);
                return string.IsNullOrEmpty(name) ? "?" : name;
            }
        }
    }
}