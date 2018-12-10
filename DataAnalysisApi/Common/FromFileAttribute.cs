using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace DataAnalysisApi.Common
{
    public class FromFileAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => BindingSource.FormFile;
    }
}
