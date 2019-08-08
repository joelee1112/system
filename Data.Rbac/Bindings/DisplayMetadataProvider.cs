using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Data.Rbac.Bindings
{
    public class DisplayMetadataProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.Attributes.Any(a => a.GetType() == typeof(HideForEditAttribute))) context.DisplayMetadata.ShowForEdit = false;
            if (context.Attributes.Any(a => a.GetType() == typeof(HideForDisplayAttribute))) context.DisplayMetadata.ShowForDisplay = false;
            if (context.Attributes.Any(a => a.GetType() == typeof(LayoutAttribute)))
            {
                var attr = context.Attributes.FirstOrDefault(a => a.GetType() == typeof(LayoutAttribute)) as LayoutAttribute;

                if (attr != null)
                {
                    context.DisplayMetadata.DataTypeName = "Layout";
                    context.DisplayMetadata.AdditionalValues.Add("layoutName", attr.name);
                }
            }
        }
    }
}
