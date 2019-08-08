using System.ComponentModel.DataAnnotations;

namespace Data.Rbac
{
    public enum ContentTypes : sbyte
    {
        /// <summary>網頁</summary>
        [Display(Name = "網頁")]
        網頁 = 1,
        /// <summary>檔案</summary>
        [Display(Name = "檔案")]
        檔案 = 2
    }
}
